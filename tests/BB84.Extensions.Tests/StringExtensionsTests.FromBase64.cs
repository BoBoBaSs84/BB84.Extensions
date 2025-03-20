using System.Text;

namespace BB84.Extensions.Tests;

public sealed partial class StringExtensionsTests
{
	[DataTestMethod]
	[DataRow("UnitTest", "VW5pdFRlc3Q=")]
	[DataRow("", "")]
	public void FromBase64Test(string expected, string value)
		=> Assert.AreEqual(expected, value.FromBase64(Encoding.UTF8));

	[DataTestMethod]
	[DataRow("%")]
	[DataRow("$")]
	[DataRow("#")]
	[ExpectedException(typeof(ArgumentException))]
	public void FromBase64ExceptionTest(string value)
		=> value.FromBase64();
}
