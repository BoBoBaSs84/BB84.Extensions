using System.Drawing;

namespace BB84.Extensions;

public static partial class ColorExtensions
{
	/// <summary>
	/// Converts to provided three byte <paramref name="value"/> into 24-bit color.
	/// </summary>
	/// <param name="value">The three byte array to convert.</param>
	/// <returns>The 24-bit color.</returns>
	/// <exception cref="ArgumentException"></exception>
	public static Color FromRgbByteArray(this byte[] value)
	{
		if (value.Length != 3)
			throw new ArgumentException("RGB color must be 3 bytes long!", nameof(value));

		if (!BitConverter.IsLittleEndian)
			Array.Reverse(value);

		int r = value[2];
		int g = value[1];
		int b = value[0];

		return Color.FromArgb(r, g, b);
	}
}
