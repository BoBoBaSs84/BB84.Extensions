using System.Drawing;

namespace BB84.Extensions;

public static partial class ColorExtensions
{
	/// <summary>
	/// Converts to provided <paramref name="color"/> into a three byte array.
	/// </summary>
	/// <param name="color">The color to convert.</param>
	/// <returns>The three byte array.</returns>
	public static byte[] ToRgbByteArray(this Color color)
	{
		byte[] bytes = [color.B, color.G, color.R];

		if (!BitConverter.IsLittleEndian)
			Array.Reverse(bytes);

		return bytes;
	}
}
