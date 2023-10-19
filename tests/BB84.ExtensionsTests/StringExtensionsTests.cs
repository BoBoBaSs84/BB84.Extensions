using System.Globalization;

using BB84.Extensions;

namespace BB84.ExtensionsTests;

[TestClass]
public class StringExtensionsTests
{
	[TestMethod]
	public void FormatInvariantSuccessTest()
	{
		DateTime dateTime = DateTime.Now;
		string testString = @"Today is: {0}";

		string result = testString.FormatInvariant(dateTime);

		Assert.IsTrue(result.Contains(dateTime.ToString(CultureInfo.InvariantCulture)));
	}

	[TestMethod]
	public void FormatSuccessTest()
	{
		DateTime dateTime = DateTime.Now;
		string testString = @"Today is: {0}";

		string result = testString.Format(CultureInfo.GetCultureInfo("de-DE"), dateTime);

		Assert.IsTrue(result.Contains(dateTime.ToString(CultureInfo.GetCultureInfo("de-DE"))));
	}

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

	[TestMethod]
	public void GetMd5Utf8Test()
	{
		string value = "UnitTest";

		var result = value.GetMd5Utf8();

		Assert.AreEqual("37ADC7DB47085615AF6389C9C50AF7B9", result);
	}

	[TestMethod]
	public void GetMd5UnicodeTest()
	{
		string value = "UnitTest";

		var result = value.GetMd5Unicode();

		Assert.AreEqual("000C23A22CE00D7163E8FF10A23FCDC3", result);
	}

	[TestMethod]
	public void GetMd5AsciiTest()
	{
		string value = "UnitTest";

		var result = value.GetMd5Ascii();

		Assert.AreEqual("37ADC7DB47085615AF6389C9C50AF7B9", result);
	}
}
