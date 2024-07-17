using System.Drawing;

using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class ColorExtensionsTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetRgbTestData), DynamicDataSourceType.Method)]
	public void FromRGBHexStringTest(Color expected, string value)
		=> Assert.AreEqual(expected.ToArgb(), value.FromRGBHexString().ToArgb());
}
