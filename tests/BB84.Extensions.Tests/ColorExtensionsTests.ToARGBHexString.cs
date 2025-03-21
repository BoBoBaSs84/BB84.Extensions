using System.Drawing;

namespace BB84.Extensions.Tests;

public sealed partial class ColorExtensionsTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetArgbHexData), DynamicDataSourceType.Method)]
	public void ToARGBHexStringTest(Color value, string expected)
		=> Assert.AreEqual(expected, value.ToARGBHexString());
}
