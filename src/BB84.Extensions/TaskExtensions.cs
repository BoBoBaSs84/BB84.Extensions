// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

/// <summary>
/// The <see cref="Task"/> extensions class.
/// </summary>
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
}
