// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.IO.Compression;

namespace BB84.Extensions;

public static partial class StringExtensions
{
	/// <summary>
	/// Compresses a string and returns a deflate compressed, Base64 encoded string.
	/// </summary>
	/// <param name="stringValue">The input string value to compress.</param>
	/// <param name="compressionLevel">The compression level to use.</param>
	/// <returns>The compressed base64 encoded string.</returns>
	public static string Compress(this string stringValue, CompressionLevel compressionLevel = CompressionLevel.Optimal)
	{
		byte[] inputBuffer = stringValue.GetBytes();

		byte[] outputBuffer = inputBuffer.Compress(compressionLevel);

		return Convert.ToBase64String(outputBuffer);
	}
}
