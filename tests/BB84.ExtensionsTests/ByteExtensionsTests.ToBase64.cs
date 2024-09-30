using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class ByteExtensionsTests
{
	[DataTestMethod]
	[DataRow("VW5pdFRlc3Q=", new byte[] { 85, 110, 105, 116, 84, 101, 115, 116 })]
	[DataRow("", new byte[0])]
	public void ToBase64Test(string expected, byte[] bytes)
		=> Assert.AreEqual(expected, bytes.ToBase64());
}
