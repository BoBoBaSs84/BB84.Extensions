// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Drawing;

namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for converting between <see cref="Color"/> objects and various representations,
/// including byte arrays and hexadecimal strings, for both ARGB and RGB formats.
/// </summary>
/// <remarks>
/// This class includes methods to create <see cref="Color"/> objects from ARGB or RGB byte arrays and
/// hex strings, as well as methods to convert <see cref="Color"/> objects back into these formats. It
/// supports both 32-bit ARGB and 24-bit RGB representations. The methods handle endianness where applicable
/// and validate input to ensure correct usage.
/// </remarks>
public static class ColorExtensions
{
	/// <summary>
	/// Creates a <see cref="Color"/> instance from a byte array containing ARGB color components.
	/// </summary>
	/// <remarks>
	/// The byte array must represent the color components in ARGB order, with each component occupying one
	/// byte. If the system architecture is not little-endian, the byte array is reversed before processing.
	/// </remarks>
	/// <param name="value">
	/// A byte array containing exactly 4 elements, representing the alpha, red, green, and blue components
	/// of the color in ARGB order.
	/// </param>
	/// <returns>A <see cref="Color"/> instance corresponding to the specified ARGB components.</returns>
	/// <exception cref="ArgumentException">
	/// Thrown if <paramref name="value"/> does not contain exactly 4 elements.
	/// </exception>
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

	/// <summary>
	/// Converts a hexadecimal ARGB color string to a <see cref="Color"/> object.
	/// </summary>
	/// <remarks>
	/// The input string must be in the format "<c>#AARRGGBB</c>", where:
	/// <list type="bullet">
	/// <item><c>AA</c> represents the alpha channel (transparency).</item>
	/// <item><c>RR</c> represents the red channel.</item>
	/// <item><c>GG</c> represents the green channel.</item>
	/// <item><c>BB</c> represents the blue channel.</item>
	/// </list>
	/// Example: "#FF112233" represents a fully opaque color with red = 17, green = 34, and blue = 51.
	/// </remarks>
	/// <param name="value">A string representing the color in ARGB hexadecimal format.</param>
	/// <returns>
	/// A <see cref="Color"/> instance corresponding to the specified ARGB hexadecimal string.
	/// Returns <see cref="Color.Empty"/> if the input string does not meet the required format.
	/// </returns>
	public static Color FromARGBHexString(this string value)
	{
		Color color = Color.Empty;

		if (value[0].Equals('#') && (value.Length == 9))
		{
			color = Color.FromArgb(
				Convert.ToInt32(value.Substring(1, 2), 16),
				Convert.ToInt32(value.Substring(3, 2), 16),
				Convert.ToInt32(value.Substring(5, 2), 16),
				Convert.ToInt32(value.Substring(7, 2), 16)
				);
		}

		return color;
	}

	/// <summary>
	/// Creates a <see cref="Color"/> instance from a byte array containing RGB values.
	/// </summary>
	/// <remarks>
	/// The byte array must represent the RGB components in the order: red, green, blue. If the
	/// system architecture is not little-endian, the array is reversed internally to ensure correct
	/// color representation.
	/// </remarks>
	/// <param name="value">
	/// A byte array containing exactly three elements representing the red, green, and blue components
	/// of the color, in that order.
	/// </param>
	/// <returns>A <see cref="Color"/> instance corresponding to the specified RGB values.</returns>
	/// <exception cref="ArgumentException">
	/// Thrown if <paramref name="value"/> does not contain exactly three elements.
	/// </exception>
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

	/// <summary>
	/// Converts a hexadecimal RGB color string to a <see cref="Color"/> object.
	/// </summary>
	/// <remarks>
	/// The input string must be in the format "<c>#RRGGBB</c>", where:
	/// <list type="bullet">
	/// <item><c>RR</c> represents the red channel.</item>
	/// <item><c>GG</c> represents the green channel.</item>
	/// <item><c>BB</c> represents the blue channel.</item>
	/// </list>
	/// Example: "#112233" represents a fully opaque color with red = 17, green = 34, and blue = 51.
	/// </remarks>
	/// <param name="value">A string representing the color in RGB hexadecimal format.</param>
	/// <returns>
	/// A <see cref="Color"/> instance corresponding to the specified RGB hexadecimal string.
	/// Returns <see cref="Color.Empty"/> if the input string does not meet the required format.
	/// </returns>
	public static Color FromRGBHexString(this string value)
	{
		Color color = Color.Empty;

		if (value[0].Equals('#') && ((value.Length == 7) || (value.Length == 4)))
		{
			if (value.Length == 7)
			{
				color = Color.FromArgb(
					Convert.ToInt32(value.Substring(1, 2), 16),
					Convert.ToInt32(value.Substring(3, 2), 16),
					Convert.ToInt32(value.Substring(5, 2), 16)
					);
			}
			else
			{
				string r = char.ToString(value[1]);
				string g = char.ToString(value[2]);
				string b = char.ToString(value[3]);

				color = Color.FromArgb(
					Convert.ToInt32(r + r, 16),
					Convert.ToInt32(g + g, 16),
					Convert.ToInt32(b + b, 16)
					);
			}
		}

		return color;
	}

	/// <summary>
	/// Converts the specified color <paramref name="value"/> to a byte array in ARGB format.
	/// </summary>
	/// <remarks>
	/// The resulting byte array contains the blue, green, red, and alpha components of the color in that order.
	/// If the system is not little-endian, the byte order is reversed to ensure compatibility.
	/// </remarks>
	/// <param name="value">The <see cref="Color"/> to convert.</param>
	/// <returns>A byte array containing the color components in ARGB order.</returns>
	public static byte[] ToArgbByteArray(this Color value)
	{
		byte[] bytes = [value.B, value.G, value.R, value.A];

		if (!BitConverter.IsLittleEndian)
			Array.Reverse(bytes);

		return bytes;
	}

	/// <summary>
	/// Converts the specified color <paramref name="value"/> to its ARGB hexadecimal string representation.
	/// </summary>
	/// <param name="value">The <see cref="Color"/> value to convert.</param>
	/// <returns>
	/// A string representing the color in ARGB hexadecimal format, prefixed with a '#' character.
	/// The format is "#AARRGGBB", where AA, RR, GG, and BB are the alpha, red, green, and blue components
	/// of the color, respectively, in two-digit hexadecimal notation.
	/// </returns>
	public static string ToARGBHexString(this Color value)
		=> $"#{value.A:X2}{value.R:X2}{value.G:X2}{value.B:X2}";

	/// <summary>
	/// Converts the specified color <paramref name="value"/> to a byte array in RGB format.
	/// </summary>
	/// <remarks>
	/// The resulting byte array contains the blue, green and red components of the color in that order.
	/// If the system is not little-endian, the byte order is reversed to ensure compatibility.
	/// </remarks>
	/// <param name="value">The <see cref="Color"/> to convert.</param>
	/// <returns>A byte array containing the color components in RGB order.</returns>
	public static byte[] ToRgbByteArray(this Color value)
	{
		byte[] bytes = [value.B, value.G, value.R];

		if (!BitConverter.IsLittleEndian)
			Array.Reverse(bytes);

		return bytes;
	}

	/// <summary>
	/// Converts the specified color <paramref name="value"/> to its RGB hexadecimal string representation.
	/// </summary>
	/// <param name="value">The <see cref="Color"/> value to convert.</param>
	/// <returns>
	/// A string representing the color in RGB hexadecimal format, prefixed with a '#' character.
	/// The format is "#RRGGBB", where RR, GG, and BB are the red, green, and blue components
	/// of the color, respectively, in two-digit hexadecimal notation.
	/// </returns>
	public static string ToRGBHexString(this Color value)
		=> $"#{value.R:X2}{value.G:X2}{value.B:X2}";
}
