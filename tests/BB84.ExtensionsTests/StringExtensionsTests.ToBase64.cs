using System.Text;

using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class StringExtensionsTests
{
	[DataTestMethod]
	[DataRow("VW5pdFRlc3Q=", "UnitTest")]
	[DataRow("", "")]
	public void ToBase64Test(string expected, string value)
		=> Assert.AreEqual(expected, value.ToBase64(Encoding.UTF8));
}
