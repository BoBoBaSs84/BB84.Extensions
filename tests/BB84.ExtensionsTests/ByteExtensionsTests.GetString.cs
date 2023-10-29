using BB84.Extensions;

namespace BB84.ExtensionsTests;

public partial class ByteExtensionsTests
{
	[DataTestMethod]
	[DataRow(new byte[] { 65 }, "A")]
	public void GetStringTest(byte[] inputBuffer, string expected)
		=> Assert.AreEqual(expected, inputBuffer.GetString());
}
