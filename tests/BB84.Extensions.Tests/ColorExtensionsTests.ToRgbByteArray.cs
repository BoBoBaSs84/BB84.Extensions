using System.Drawing;

namespace BB84.Extensions.Tests;

public sealed partial class ColorExtensionsTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetRgbByteData), DynamicDataSourceType.Method)]
	public void ToRgbByteArrayTest(Color value, byte[] expected)
		=> Assert.IsTrue(expected.SequenceEqual(value.ToRgbByteArray()));
}
