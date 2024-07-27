using System.Drawing;

namespace BB84.Extensions;

public static partial class ColorExtensions
{
	/// <summary>
	/// Converts to provided <paramref name="color"/> into a four byte array.
	/// </summary>
	/// <param name="color">The color to convert.</param>
	/// <returns>The four byte array.</returns>
	public static byte[] ToArgbByteArray(this Color color)
	{
		byte[] bytes = [color.B, color.G, color.R, color.A];

		if (!BitConverter.IsLittleEndian)
			Array.Reverse(bytes);

		return bytes;
	}
}
