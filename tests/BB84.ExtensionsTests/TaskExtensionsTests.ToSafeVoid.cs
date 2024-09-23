using BB84.Extensions;

namespace BB84.ExtensionsTests;

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
