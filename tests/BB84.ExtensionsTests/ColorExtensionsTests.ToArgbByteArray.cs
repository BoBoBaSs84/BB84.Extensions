using System.Drawing;

using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class ColorExtensionsTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetArgbByteData), DynamicDataSourceType.Method)]
	public void ToArgbByteArrayTest(Color value, byte[] excpected)
		=> Assert.IsTrue(excpected.SequenceEqual(value.ToArgbByteArray()));
}
