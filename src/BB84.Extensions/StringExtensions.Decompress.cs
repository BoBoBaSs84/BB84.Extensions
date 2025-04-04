// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

public static partial class StringExtensions
{
	/// <summary>
	/// Decompresses a deflate compressed, Base64 encoded string and returns an uncompressed string.
	/// </summary>
	/// <param name="stringValue">The input string value to decompress.</param>
	/// <returns></returns>
	public static string Decompress(this string stringValue)
	{
		byte[] inputBuffer = Convert.FromBase64String(stringValue);

		byte[] outputBuffer = inputBuffer.Decompress();

		return outputBuffer.GetString();
	}
}
