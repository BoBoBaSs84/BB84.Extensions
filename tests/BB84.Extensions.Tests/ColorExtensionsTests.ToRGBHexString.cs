using System.Drawing;

namespace BB84.Extensions.Tests;

public sealed partial class ColorExtensionsTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetRgbHexData), DynamicDataSourceType.Method)]
	public void ToRGBHexStringTest(Color value, string expected)
		=> Assert.AreEqual(expected, value.ToRGBHexString());
}
