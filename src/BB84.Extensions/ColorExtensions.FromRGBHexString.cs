// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Drawing;

namespace BB84.Extensions;

public static partial class ColorExtensions
{
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
}
