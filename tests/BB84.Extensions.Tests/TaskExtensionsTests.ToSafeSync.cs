// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class TaskExtensionsTests
{
	[TestMethod]
	public void ToSafeSyncTest()
	{
		bool taskCompleted = false;
		bool taskExecuted = false;
		bool exceptionOccured = false;

		taskExecuted = BoolTask()
			.ToSafeSync(() => taskCompleted = true, (e) => exceptionOccured = true);

		Assert.IsTrue(taskExecuted);
		Assert.IsFalse(exceptionOccured);
		Assert.IsTrue(taskCompleted);
	}

	[TestMethod]
	public void ToSafeSyncExceptionTest()
	{
		bool taskCompleted = false;
		bool taskExecuted = false;
		bool exceptionOccured = false;

		taskExecuted = BoolTask(true)
			.ToSafeSync(() => taskCompleted = true, (e) => exceptionOccured = true);

		Assert.IsFalse(taskExecuted);
		Assert.IsTrue(exceptionOccured);
		Assert.IsTrue(taskCompleted);
	}
}
