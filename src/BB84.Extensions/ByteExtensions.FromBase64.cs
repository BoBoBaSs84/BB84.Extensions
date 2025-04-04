// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

public static partial class ByteExtensions
{
	/// <summary>
	/// Converts the specified <paramref name="value"/>, which encodes binary data as base-64 digits,
	/// to an equivalent 8-bit unsigned integer array.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <returns>An array of 8-bit unsigned integers that is equivalent to <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentException"></exception>
	public static byte[] FromBase64(this string value)
	{
		if (value.IsNullOrEmpty())
			return [];

		value = value.Trim();
		bool isValidBase64 = (value.Length % 4 == 0) && Base64Regex.IsMatch(value);

		if (isValidBase64.Equals(false))
			throw new ArgumentException($"{value} is not valid base64");

		byte[] bytes = Convert.FromBase64String(value);

		return bytes;
	}
}
