using System.Text;

namespace BB84.Extensions.Tests;

public sealed partial class StringExtensionsTests
{
	[DataTestMethod]
	[DataRow("VW5pdFRlc3Q=", "UnitTest")]
	[DataRow("", "")]
	public void ToBase64Test(string expected, string value)
		=> Assert.AreEqual(expected, value.ToBase64(Encoding.UTF8));
}
