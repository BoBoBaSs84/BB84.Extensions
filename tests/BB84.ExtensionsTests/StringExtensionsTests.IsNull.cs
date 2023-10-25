using BB84.Extensions;

namespace BB84.ExtensionsTests;

public partial class StringExtensionsTests
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
}
