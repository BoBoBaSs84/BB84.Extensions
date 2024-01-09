using System.Drawing;

using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class ColorExtensionsTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetArgbTestData), DynamicDataSourceType.Method)]
	public void ToARGBHexStringTest(Color value, string expected)
		=> Assert.AreEqual(expected, value.ToARGBHexString());
}
