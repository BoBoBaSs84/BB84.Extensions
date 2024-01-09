using System.Drawing;

namespace BB84.ExtensionsTests;

[TestClass]
public sealed partial class ColorExtensionsTests
{
	public static IEnumerable<object[]> GetArgbTestData()
	{
		yield return new object[] { Color.White, "#FFFFFFFF" };
		yield return new object[] { Color.Black, "#FF000000" };
		yield return new object[] { Color.Red, "#FFFF0000" };
		yield return new object[] { Color.Lime, "#FF00FF00" };
		yield return new object[] { Color.Blue, "#FF0000FF" };
	}

	public static IEnumerable<object[]> GetRgbTestData()
	{
		yield return new object[] { Color.White, "#FFFFFF" };
		yield return new object[] { Color.Black, "#000000" };
		yield return new object[] { Color.Red, "#FF0000" };
		yield return new object[] { Color.Lime, "#00FF00" };
		yield return new object[] { Color.Blue, "#0000FF" };
	}
}
