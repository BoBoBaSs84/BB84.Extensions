using System.Drawing;

using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class ColorExtensionsTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetRgbByteData), DynamicDataSourceType.Method)]
	public void ToRgbByteArrayTest(Color value, byte[] expected)
		=> Assert.IsTrue(expected.SequenceEqual(value.ToRgbByteArray()));
}
