namespace BB84.Extensions.Tests;

public sealed partial class TaskExtensionsTests
{
	[TestMethod]
	public void ToAsyncVoidTest()
	{
		bool taskCompleted = false;
		bool exceptionOccured = false;

		AwaitableTask().ToAsyncVoid(() => taskCompleted = true, (e) => exceptionOccured = true);

		Assert.IsFalse(exceptionOccured);
		Assert.IsTrue(taskCompleted);
	}

	[TestMethod]
	public void ToAsyncVoidExceptionTest()
	{
		bool taskCompleted = false;
		bool exceptionOccured = false;

		AwaitableTask(true).ToAsyncVoid(() => taskCompleted = true, (e) => exceptionOccured = true);

		Task.Delay(100).Wait();

		Assert.IsTrue(exceptionOccured);
		Assert.IsTrue(taskCompleted);
	}
}
