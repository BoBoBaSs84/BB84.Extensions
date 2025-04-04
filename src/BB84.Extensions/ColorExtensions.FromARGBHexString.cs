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
}
