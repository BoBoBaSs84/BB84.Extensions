using System.Drawing;

namespace BB84.Extensions.Tests;

public sealed partial class ColorExtensionsTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetRgbByteData), DynamicDataSourceType.Method)]
	public void FromRgbByteArrayTest(Color expected, byte[] value)
		=> Assert.AreEqual(expected.ToArgb(), value.FromRgbByteArray().ToArgb());

	[TestMethod]
	[ExpectedException(typeof(ArgumentException))]
	public void FromRgbByteArrayExceptionTest()
	=> Array.Empty<byte>().FromRgbByteArray();
}
