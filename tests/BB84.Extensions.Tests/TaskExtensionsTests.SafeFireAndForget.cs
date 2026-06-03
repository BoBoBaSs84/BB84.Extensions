// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class TaskExtensionsTests
{
	[TestMethod]
	public async Task SafeFireAndForgetNoException()
	{
		TaskCompletionSource<bool> tcs = new(TaskCreationOptions.RunContinuationsAsynchronously);
		bool exceptionOccured = false;

		AwaitableTask()
			.SafeFireAndForget(() => tcs.TrySetResult(true), (e) => { exceptionOccured = true; tcs.TrySetResult(true); });

		var completed = await Task.WhenAny(tcs.Task, Task.Delay(1000)).ConfigureAwait(false);
		Assert.AreEqual(tcs.Task, completed, "Timed out waiting for task completion");
		Assert.IsFalse(exceptionOccured);
		Assert.IsTrue(tcs.Task.Result);
	}

	[TestMethod]
	public async Task SafeFireAndForgetException()
	{
		TaskCompletionSource<bool> tcs = new(TaskCreationOptions.RunContinuationsAsynchronously);
		bool exceptionOccured = false;

		AwaitableTask(true)
			.SafeFireAndForget(() => tcs.TrySetResult(true), (e) => { exceptionOccured = true; tcs.TrySetResult(true); });

		var completed = await Task.WhenAny(tcs.Task, Task.Delay(1000)).ConfigureAwait(false);
		Assert.AreEqual(tcs.Task, completed, "Timed out waiting for task completion");
		Assert.IsTrue(exceptionOccured);
		Assert.IsTrue(tcs.Task.Result);
	}

	[TestMethod]
	public void SafeFireAndForgetNullTaskThrows()
		=> Assert.Throws<ArgumentNullException>(() => ((Task)null!).SafeFireAndForget());
}
