using System.Drawing;

namespace BB84.Extensions.Tests;

public sealed partial class ColorExtensionsTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetArgbByteData), DynamicDataSourceType.Method)]
	public void FromArgbByteArrayTest(Color expected, byte[] value)
		=> Assert.AreEqual(expected.ToArgb(), value.FromArgbByteArray().ToArgb());

	[TestMethod]
	[ExpectedException(typeof(ArgumentException))]
	public void FromArgbByteArrayExceptionTest()
		=> Array.Empty<byte>().FromArgbByteArray();

}
