// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Drawing;

namespace BB84.Extensions;

/// <summary>
/// The color extensions class.
/// </summary>
public static class ColorExtensions
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

	/// <summary>
	/// Returns a <see cref="Color"/> from an ARGB hex representation (i.e. <b>#FF00FF00</b>)
	/// </summary>
	/// <param name="value">The hex string to convert.</param>
	/// <returns>The hex string as <see cref="Color"/>.</returns>
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

	/// <summary>
	/// Returns a <see cref="Color"/> from an RGB hex representation (i.e. <b>#00FF00</b> or <b>#FFF</b>)
	/// </summary>
	/// <param name="value">The hex string to convert.</param>
	/// <returns>The hex string as <see cref="Color"/>.</returns>
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

	/// <summary>
	/// Returns the <see cref="Color"/> as ARGB hex representation (i.e. <b>#FF00FF00</b>)
	/// </summary>
	/// <param name="value">The color to convert.</param>
	/// <returns>The color as hex string.</returns>
	public static string ToARGBHexString(this Color value)
		=> $"#{value.A:X2}{value.R:X2}{value.G:X2}{value.B:X2}";

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

	/// <summary>
	/// Returns the <see cref="Color"/> as RGB hex representation (i.e. <b>#00FF00</b>)
	/// </summary>
	/// <param name="value">The color to convert.</param>
	/// <returns>The color as hex string.</returns>
	public static string ToRGBHexString(this Color value)
		=> $"#{value.R:X2}{value.G:X2}{value.B:X2}";
}
