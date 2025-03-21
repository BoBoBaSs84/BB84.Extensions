namespace BB84.Extensions.Tests;

public sealed partial class EnumeratorExtensionsTests
{
	[TestMethod]
	public void GetIntTest()
	{
		TestType type = TestType.Two;

		int value = type.GetInt();

		Assert.AreEqual(2, value);
	}
}
