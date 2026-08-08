// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Globalization;
using System.Text;

namespace BB84.Extensions.Common;

/// <summary>
/// Converts byte sequences into their uppercase hexadecimal string representation.
/// </summary>
/// <remarks>
/// This sits on the hot path of every hash helper, so the fast path matters. It exists because
/// <c>SpanExtensions</c> is only compiled for the frameworks that have spans, while
/// <see cref="ByteExtensions"/> is compiled for all of them, and both need the same conversion.
/// </remarks>
internal static class HexConverter
{
	private const string HexFormat = "X2";

	/// <summary>
	/// Converts the specified bytes to their uppercase hexadecimal string representation.
	/// </summary>
	/// <param name="value">The bytes to convert.</param>
	/// <returns>
	/// A string containing two uppercase hexadecimal characters per byte, without separators.
	/// </returns>
	internal static string ToHexString(byte[] value)
	{
#if NET6_0_OR_GREATER
		return Convert.ToHexString(value);
#else
		StringBuilder builder = new(value.Length * 2);
		foreach (byte b in value)
			_ = builder.Append(b.ToString(HexFormat, CultureInfo.InvariantCulture));
		return builder.ToString();
#endif
	}

#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
	/// <summary>
	/// Converts the specified bytes to their uppercase hexadecimal string representation.
	/// </summary>
	/// <param name="value">The bytes to convert.</param>
	/// <returns>
	/// A string containing two uppercase hexadecimal characters per byte, without separators.
	/// </returns>
	internal static string ToHexString(ReadOnlySpan<byte> value)
	{
#if NET6_0_OR_GREATER
		return Convert.ToHexString(value);
#else
		StringBuilder builder = new(value.Length * 2);
		foreach (byte b in value)
			_ = builder.Append(b.ToString(HexFormat, CultureInfo.InvariantCulture));
		return builder.ToString();
#endif
	}
#endif
}
