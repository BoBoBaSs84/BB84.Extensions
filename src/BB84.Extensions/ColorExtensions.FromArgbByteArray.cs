using System.Drawing;

namespace BB84.Extensions;

public static partial class ColorExtensions
{
	/// <summary>
	/// Converts to provided four byte <paramref name="value"/> into 32-bit color.
	/// </summary>
	/// <param name="value">The four byte array to convert.</param>
	/// <returns>The 32-bit color.</returns>
	/// <exception cref="ArgumentException"></exception>
	public static Color FromArgbByteArray(this byte[] value)
	{
		if (value.Length != 4)
			throw new ArgumentException("ARGB color must be 4 bytes long!", nameof(value));

		if (!BitConverter.IsLittleEndian)
			Array.Reverse(value);

		int a = value[3];
		int r = value[2];
		int g = value[1];
		int b = value[0];

		return Color.FromArgb(a, r, g, b);
	}
}
