// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
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
	/// <returns>The result <typeparamref name="T"/> or <see langword="null"/></returns>
	public static T ToSafeSync<T>(this Task<T> task, Action? onCompletion = null, Action<Exception>? onException = null)
	{
		try
		{
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
}
