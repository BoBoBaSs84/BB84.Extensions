using System.Drawing;

namespace BB84.Extensions.Tests;

[TestClass]
public sealed partial class ColorExtensionsTests
{
	public static IEnumerable<object[]> GetArgbByteData()
	{
		yield return new object[] { Color.White, new byte[] { 255, 255, 255, 255 } };
		yield return new object[] { Color.Black, new byte[] { 0, 0, 0, 255 } };
		yield return new object[] { Color.Red, new byte[] { 0, 0, 255, 255 } };
		yield return new object[] { Color.Lime, new byte[] { 0, 255, 0, 255 } };
		yield return new object[] { Color.Blue, new byte[] { 255, 0, 0, 255 } };
	}

	public static IEnumerable<object[]> GetArgbHexData()
	{
		yield return new object[] { Color.White, "#FFFFFFFF" };
		yield return new object[] { Color.Black, "#FF000000" };
		yield return new object[] { Color.Red, "#FFFF0000" };
		yield return new object[] { Color.Lime, "#FF00FF00" };
		yield return new object[] { Color.Blue, "#FF0000FF" };
	}

	public static IEnumerable<object[]> GetRgbByteData()
	{
		yield return new object[] { Color.White, new byte[] { 255, 255, 255 } };
		yield return new object[] { Color.Black, new byte[] { 0, 0, 0 } };
		yield return new object[] { Color.Red, new byte[] { 0, 0, 255 } };
		yield return new object[] { Color.Lime, new byte[] { 0, 255, 0 } };
		yield return new object[] { Color.Blue, new byte[] { 255, 0, 0 } };
	}

	public static IEnumerable<object[]> GetRgbHexData()
	{
		yield return new object[] { Color.White, "#FFFFFF" };
		yield return new object[] { Color.Black, "#000000" };
		yield return new object[] { Color.Red, "#FF0000" };
		yield return new object[] { Color.Lime, "#00FF00" };
		yield return new object[] { Color.Blue, "#0000FF" };
	}
}
