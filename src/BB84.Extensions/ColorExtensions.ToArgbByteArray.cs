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
