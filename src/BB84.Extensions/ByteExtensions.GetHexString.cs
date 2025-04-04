// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Globalization;
using System.Text;

namespace BB84.Extensions;

public static partial class ByteExtensions
{
	/// <summary>
	/// Gets the hex string of a byte array
	/// </summary>
	/// <param name="inputBuffer">The byte array to work with.</param>
	/// <returns>The hexed string</returns>
	public static string GetHexString(this byte[] inputBuffer)
	{
		StringBuilder sb = new();
		foreach (byte b in inputBuffer)
			_ = sb.Append(b.ToString("X2", CultureInfo.InvariantCulture));
		return sb.ToString();
	}
}
