using System.Drawing;

using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class ColorExtensionsTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetArgbTestData), DynamicDataSourceType.Method)]
	public void FromARGBHexStringTest(Color expected, string value)
		=> Assert.AreEqual(expected.ToArgb(), value.FromARGBHexString().ToArgb());
}
