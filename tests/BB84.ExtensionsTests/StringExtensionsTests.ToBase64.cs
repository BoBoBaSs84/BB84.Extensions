using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class StringExtensionsTests
{
	[TestMethod]
	public void ToBase64Test()
	{
		string value = "UnitTest";

		string result = value.ToBase64();

		Assert.AreNotEqual(value, result);
		Assert.AreEqual("VW5pdFRlc3Q=", result);
	}

	[TestMethod]
	public void ToBase64EmptyTest()
	{
		string value = string.Empty;

		string result = value.ToBase64();

		Assert.AreEqual(value, result);
	}
}
