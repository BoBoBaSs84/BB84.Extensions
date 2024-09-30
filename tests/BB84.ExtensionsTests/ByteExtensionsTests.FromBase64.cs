using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class ByteExtensionsTests
{
	[DataTestMethod]
	[DataRow(new byte[] { 85, 110, 105, 116, 84, 101, 115, 116 }, "VW5pdFRlc3Q=")]
	[DataRow(new byte[0], "")]
	public void FromBase64Test(byte[] expected, string value)
		=> Assert.IsTrue(expected.SequenceEqual(value.FromBase64()));
}
