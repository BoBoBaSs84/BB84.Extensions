using BB84.Extensions;

namespace BB84.ExtensionsTests;

[TestClass]
public sealed partial class StringExtensionsTests
{
	[TestMethod]
	public void IsNullTest()
	{
		string nullString = null!;

		Assert.AreEqual(true, nullString.IsNull());
	}

	[TestMethod]
	public void IsNullOrEmptyTest()
	{
		string nullString = null!;
		string emptyString = string.Empty;

		Assert.AreEqual(true, nullString.IsNullOrEmpty());
		Assert.AreEqual(true, emptyString.IsNullOrEmpty());
	}

	[TestMethod]
	public void IsNullOrWhiteSpaceTest()
	{
		string nullString = null!;
		string whiteString = " ";

		Assert.AreEqual(true, nullString.IsNullOrWhiteSpace());
		Assert.AreEqual(true, whiteString.IsNullOrWhiteSpace());
	}

	[TestMethod]
	public void GetMd5Utf8Test()
	{
		string value = "UnitTest";

		string result = value.GetMd5Utf8();

		Assert.AreEqual("37ADC7DB47085615AF6389C9C50AF7B9", result);
	}

	[TestMethod]
	public void GetMd5UnicodeTest()
	{
		string value = "UnitTest";

		string result = value.GetMd5Unicode();

		Assert.AreEqual("000C23A22CE00D7163E8FF10A23FCDC3", result);
	}

	[TestMethod]
	public void GetMd5AsciiTest()
	{
		string value = "UnitTest";

		string result = value.GetMd5Ascii();

		Assert.AreEqual("37ADC7DB47085615AF6389C9C50AF7B9", result);
	}
}
