using System.Drawing;

namespace BB84.Extensions.Tests;

public sealed partial class ColorExtensionsTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetArgbByteData), DynamicDataSourceType.Method)]
	public void ToArgbByteArrayTest(Color value, byte[] excpected)
		=> Assert.IsTrue(excpected.SequenceEqual(value.ToArgbByteArray()));
}
