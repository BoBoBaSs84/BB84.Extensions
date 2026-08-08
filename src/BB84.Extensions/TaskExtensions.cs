// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.Extensions.Common;

namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for working with <see cref="Task"/> and <see cref="Task{TResult}"/>
/// objects, enabling additional functionality such as running tasks synchronously, handling
/// exceptions, and retrieving results safely.
/// </summary>
/// <remarks>
/// These methods are designed to simplify task handling in scenarios where synchronous behavior is
/// required. Use caution when blocking threads, as this can lead to potential deadlocks or
/// performance issues in certain environments, such as UI applications. Prefer
/// <see cref="SafeFireAndForget"/> over <c>async void</c> for observable, testable
/// fire-and-forget semantics.
/// </remarks>
public static class TaskExtensions
{
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
	/// <returns>
	/// The result of the task, or the default of <typeparamref name="T"/> if it faulted or timed out.
	/// </returns>
	/// <exception cref="ArgumentNullException">
	/// Thrown if <paramref name="task"/> is <see langword="null"/>.
	/// </exception>
	public static T? ToSafeSync<T>(this Task<T> task, Action? onCompletion = null, Action<Exception>? onException = null, TimeSpan? timeout = null)
	{
		Guard.ThrowIfNull(task);

		try
		{
			if (!WaitForCompletion(task, timeout))
				throw new TimeoutException();

			return task.GetAwaiter()
				.GetResult();
		}
		catch (Exception ex)
		{
			onException?.Invoke(ex);
			return default;
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
	/// <exception cref="ArgumentNullException">
	/// Thrown if <paramref name="task"/> is <see langword="null"/>.
	/// </exception>
	public static void ToSafeSync(this Task task, Action? onCompletion = null, Action<Exception>? onException = null, TimeSpan? timeout = null)
	{
		Guard.ThrowIfNull(task);

		try
		{
			if (!WaitForCompletion(task, timeout))
				throw new TimeoutException();

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
	/// <exception cref="ArgumentNullException">
	/// Thrown if <paramref name="task"/> is <see langword="null"/>.
	/// </exception>
	public static void SafeFireAndForget(this Task task, Action? onCompletion = null, Action<Exception>? onException = null)
	{
		Guard.ThrowIfNull(task);

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

	/// <summary>
	/// Waits for the task to finish, if a timeout was requested.
	/// </summary>
	/// <remarks>
	/// A faulted task makes <see cref="Task.Wait(TimeSpan)"/> throw an <see cref="AggregateException"/>,
	/// while awaiting the same task surfaces the original exception. Swallowing it here and letting the
	/// caller observe the fault through the awaiter gives both overloads the same exception shape
	/// regardless of whether a timeout was passed.
	/// </remarks>
	/// <param name="task">The task to wait for.</param>
	/// <param name="timeout">The optional timeout to wait for.</param>
	/// <returns>
	/// <see langword="false"/> if the timeout elapsed before the task finished; otherwise <see langword="true"/>.
	/// </returns>
	private static bool WaitForCompletion(Task task, TimeSpan? timeout)
	{
		if (!timeout.HasValue)
			return true;

		try
		{
			return task.Wait(timeout.Value);
		}
		catch (AggregateException)
		{
			return true;
		}
	}
}
