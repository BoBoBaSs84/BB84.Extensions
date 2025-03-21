using System.Drawing;

namespace BB84.Extensions.Tests;

public sealed partial class ColorExtensionsTests
{
	[DataTestMethod]
	[DynamicData(nameof(FromRGBHexStringTestData), DynamicDataSourceType.Method)]
	public void FromRGBHexStringTest(Color expected, string value)
		=> Assert.AreEqual(expected.ToArgb(), value.FromRGBHexString().ToArgb());
}
