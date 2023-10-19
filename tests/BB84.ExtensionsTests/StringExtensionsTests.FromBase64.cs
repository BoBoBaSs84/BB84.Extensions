using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class StringExtensionsTests
{
	[TestMethod]
	public void FromBase64Test()
	{
		string value = "VW5pdFRlc3Q=";

		string result = value.FromBase64();

		Assert.AreNotEqual(value, result);
		Assert.AreEqual("UnitTest", result);
	}

	[TestMethod]
	public void FromBase64EmptyTest()
	{
		string value = string.Empty;

		string result = value.FromBase64();

		Assert.AreEqual(value, result);
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentException))]
	public void FromBase64ExceptionTest()
	{
		string value = "%$#";

		_ = value.FromBase64();
	}
}
