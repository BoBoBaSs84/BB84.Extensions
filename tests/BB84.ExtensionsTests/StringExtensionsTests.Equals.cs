using BB84.Extensions;

namespace BB84.ExtensionsTests;

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
