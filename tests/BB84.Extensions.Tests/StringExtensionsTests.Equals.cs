namespace BB84.Extensions.Tests;

public sealed partial class StringExtensionsTests
{
	[TestMethod]
	public void EqualsCaseSensitiveTest()
	{
		string stringValue = "UnitTest";

		bool result = stringValue.EqualsCaseSensitive("unittest");

		Assert.IsFalse(result);
	}

	[TestMethod]
	public void EqualsIgnoreCaseTest()
	{
		string stringValue = "UnitTest";

		bool result = stringValue.EqualsIgnoreCase("unittest");

		Assert.IsTrue(result);
	}
}
