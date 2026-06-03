// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class TaskExtensionsTests
{
	[TestMethod]
	public void SafeFireAndForgetNoException()
	{
		bool taskCompleted = false;
		bool exceptionOccured = false;

		AwaitableTask().SafeFireAndForget(() => taskCompleted = true, (e) => exceptionOccured = true);

		Task.Delay(100).Wait();

		Assert.IsFalse(exceptionOccured);
		Assert.IsTrue(taskCompleted);
	}

	[TestMethod]
	public void SafeFireAndForgetException()
	{
		bool taskCompleted = false;
		bool exceptionOccured = false;

		AwaitableTask(true).SafeFireAndForget(() => taskCompleted = true, (e) => exceptionOccured = true);

		Task.Delay(200).Wait();

		Assert.IsTrue(exceptionOccured);
		Assert.IsTrue(taskCompleted);
	}

	[TestMethod]
	public void SafeFireAndForgetNullTaskThrows()
		=> Assert.Throws<ArgumentNullException>(() => ((Task)null!).SafeFireAndForget());
}
