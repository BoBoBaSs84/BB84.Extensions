using System.Drawing;

using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class ColorExtensionsTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetRgbTestData), DynamicDataSourceType.Method)]
	public void ToRGBHexStringTest(Color value, string expected)
		=> Assert.AreEqual(expected, value.ToRGBHexString());
}
