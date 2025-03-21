namespace BB84.Extensions.Tests;

[TestClass]
public sealed partial class TaskExtensionsTests
{
	private static async Task<bool> BoolTask(bool throwException = false)
	{
		if (throwException)
		{
			await Task.Delay(50)
				.ConfigureAwait(true);

			throw new InvalidOperationException();
		}

		return true;
	}

	private static async Task AwaitableTask(bool throwException = false)
	{
		if (throwException)
		{
			await Task.Delay(50)
				.ConfigureAwait(true);

			throw new InvalidOperationException();
		}
	}
}
