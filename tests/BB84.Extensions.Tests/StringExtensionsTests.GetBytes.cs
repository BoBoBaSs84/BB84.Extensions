namespace BB84.Extensions.Tests;

public partial class StringExtensionsTests
{
	[DataTestMethod]
	[DataRow("A", new byte[] { 65 })]
	public void GetBytesTest(string stringValue, byte[] expected)
		=> Assert.IsTrue(expected.SequenceEqual(stringValue.GetBytes()));
}
