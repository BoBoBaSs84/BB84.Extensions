using BB84.Extensions;

namespace BB84.ExtensionsTests;

public partial class ByteExtensionsTests
{
	[DataTestMethod]
	[DataRow(new byte[] { 0 }, false)]
	[DataRow(null, true)]
	public void IsNullTest(byte[]? value, bool expected)
	{
		Assert.AreEqual(expected, value.IsNull());
	}
}
