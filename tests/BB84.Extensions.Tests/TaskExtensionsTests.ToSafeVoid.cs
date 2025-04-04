// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class TaskExtensionsTests
{
	[TestMethod]
	public void ToSyncVoidTest()
	{
		bool taskCompleted = false;
		bool exceptionOccured = false;

		AwaitableTask().ToSyncVoid(() => taskCompleted = true, (e) => exceptionOccured = true);

		Assert.IsFalse(exceptionOccured);
		Assert.IsTrue(taskCompleted);
	}

	[TestMethod]
	public void ToSyncVoidExceptionTest()
	{
		bool taskCompleted = false;
		bool exceptionOccured = false;

		AwaitableTask(true).ToSyncVoid(() => taskCompleted = true, (e) => exceptionOccured = true);

		Assert.IsTrue(exceptionOccured);
		Assert.IsTrue(taskCompleted);
	}
}
