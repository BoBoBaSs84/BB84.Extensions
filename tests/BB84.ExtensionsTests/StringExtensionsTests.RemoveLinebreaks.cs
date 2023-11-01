using BB84.Extensions;

namespace BB84.ExtensionsTests;

public partial class StringExtensionsTests
{
	[DataTestMethod]
	[DataRow("Unit\rTest", "UnitTest")]
	[DataRow("Unit\r\nTest", "UnitTest")]
	[DataRow("Unit\nTest", "UnitTest")]
	public void RemoveLinebreakTest(string value, string expected)
		=> Assert.AreEqual(expected, value.RemoveLinebreak());
}
