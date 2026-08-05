// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
#pragma warning disable CA1510 // Use ArgumentNullException throw helper
using System.ComponentModel;

namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for working with <see cref="Task"/> and <see cref="Task{TResult}"/>
/// objects, enabling additional functionality such as converting tasks to synchronous or asynchronous
/// void methods, handling exceptions, and retrieving results safely.
/// </summary>
/// <remarks>
/// These methods are designed to simplify task handling in scenarios where synchronous or void-returning
/// behavior is required. Use caution when blocking threads or converting tasks to void, as this can lead
/// to potential deadlocks or performance issues in certain environments, such as UI applications.
/// Prefer SafeFireAndForget over async void for observable, testable fire-and-forget semantics.
/// </remarks>
public static class TaskExtensions
{
	/// <summary>
	/// Executes the provided <paramref name="task"/> asynchronously and returns <see langword="void"/>.
	/// The <paramref name="onException"/> can be used, if an <see cref="Exception"/> occurs.
	/// </summary>
	/// <param name="task">The task to execute.</param>
	/// <param name="onCompletion">The action to invoke if the task has been completed.</param>
	/// <param name="onException">The action to invoke if an exception occurs.</param>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("ToAsyncVoid is risky. Prefer TaskExtensions.SafeFireAndForget for observable fire-and-forget semantics.")]
	public static async void ToAsyncVoid(this Task task, Action? onCompletion = null, Action<Exception>? onException = null)
	{
		try
		{
			await task.ConfigureAwait(false);
		}
		catch (Exception ex)
		{
			onException?.Invoke(ex);
		}
		finally
		{
			onCompletion?.Invoke();
		}
	}

	/// <summary>
	/// Executes the provided <paramref name="task"/> synchronously and returns <see langword="void"/>.
	/// The <paramref name="onException"/> can be used, if an <see cref="Exception"/> occurs.
	/// </summary>
	/// <param name="task">The task to await.</param>
	/// <param name="onCompletion">The action to invoke if the task has been completed.</param>
	/// <param name="onException">The action to invoke if an exception occurs.</param>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("ToSyncVoid is risky. Prefer TaskExtensions.ToSafeSync for safer synchronous wait patterns.")]
	public static void ToSyncVoid(this Task task, Action? onCompletion = null, Action<Exception>? onException = null)
	{
		try
		{
			task.GetAwaiter()
				.GetResult();
		}
		catch (Exception ex)
		{
			onException?.Invoke(ex);
		}
		finally
		{
			onCompletion?.Invoke();
		}
	}

	/// <summary>
	/// Runs the provided <paramref name="task"/> and returns the result of type <typeparamref name="T"/>.
	/// The <paramref name="onException"/> can be used, if an <see cref="Exception"/> occurs.
	/// </summary>
	/// <typeparam name="T">The type to work with.</typeparam>
	/// <param name="task">The task to get the result for.</param>
	/// <param name="onCompletion">The action to invoke if the task has been completed.</param>
	/// <param name="onException">The action to invoke if an exception occurs.</param>
	/// <param name="timeout">
	/// Optional timeout after which a <see cref="TimeoutException"/> is raised and handled by <paramref name="onException"/>.
	/// </param>
	/// <returns>The result <typeparamref name="T"/> or <see langword="null"/></returns>
	public static T ToSafeSync<T>(this Task<T> task, Action? onCompletion = null, Action<Exception>? onException = null, TimeSpan? timeout = null)
	{
		try
		{
			if (timeout.HasValue)
			{
				if (!task.Wait(timeout.Value))
					throw new TimeoutException();
			}

			return task.GetAwaiter()
				.GetResult();
		}
		catch (Exception ex)
		{
			onException?.Invoke(ex);
			return default!;
		}
		finally
		{
			onCompletion?.Invoke();
		}
	}

	/// <summary>
	/// Executes the provided <paramref name="task"/> synchronously and handles exceptions safely.
	/// </summary>
	/// <param name="task">The task to await.</param>
	/// <param name="onCompletion">The action to invoke if the task has been completed.</param>
	/// <param name="onException">The action to invoke if an exception occurs.</param>
	/// <param name="timeout">
	/// Optional timeout after which a <see cref="TimeoutException"/> is raised and handled by <paramref name="onException"/>.
	/// </param>
	public static void ToSafeSync(this Task task, Action? onCompletion = null, Action<Exception>? onException = null, TimeSpan? timeout = null)
	{
		try
		{
			if (timeout.HasValue)
			{
				if (!task.Wait(timeout.Value))
					throw new TimeoutException();
			}
			else
			{
				// ensure any exception is rethrown and can be observed by the caller of onException
				task.GetAwaiter().GetResult();
			}
		}
		catch (Exception ex)
		{
			onException?.Invoke(ex);
		}
		finally
		{
			onCompletion?.Invoke();
		}
	}

	/// <summary>
	/// Executes the specified asynchronous task synchronously and returns its result.
	/// </summary>
	/// <remarks>
	/// This method blocks the calling thread until the task completes. Use with caution in environments
	/// where blocking the thread may lead to deadlocks or performance issues, such as UI applications.
	/// </remarks>
	/// <typeparam name="T">The type of the result produced by the task.</typeparam>
	/// <param name="task">The task to execute synchronously. Cannot be <see langword="null"/>.</param>
	/// <returns>The result produced by the completed task.</returns>
	public static T AsSync<T>(this Task<T> task)
		=> task.GetAwaiter().GetResult();

	/// <summary>
	/// Safely fire-and-forget a <see cref="Task"/> without using <c>async void</c>.
	/// The task's completion and faulting are observed by continuations so exceptions can be handled.
	/// </summary>
	/// <param name="task">The task to run fire-and-forget.</param>
	/// <param name="onCompletion">Optional action invoked after the task completes (successful or failed).</param>
	/// <param name="onException">Optional action invoked when the task faults with an exception.</param>
	public static void SafeFireAndForget(this Task task, Action? onCompletion = null, Action<Exception>? onException = null)
	{
		if (task is null)
			throw new ArgumentNullException(nameof(task));

		_ = task.ContinueWith(t =>
		{
			try
			{
				if (t.IsFaulted)
					onException?.Invoke(t.Exception!.GetBaseException());
			}
			finally
			{
				onCompletion?.Invoke();
			}
		}, TaskScheduler.Default);
	}
}
