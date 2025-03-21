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
