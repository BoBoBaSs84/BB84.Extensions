// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

public static partial class ByteExtensions
{
	/// <summary>
	/// Converts an array of 8-bit unsigned integers to its equivalent string representation
	/// that is encoded with base-64 digits.
	/// </summary>
	/// <param name="byteArray">An array of 8-bit unsigned integers.</param>
	/// <returns>The string representation, in base 64, of the contents of <paramref name="byteArray"/>.</returns>
	public static string ToBase64(this byte[] byteArray)
		=> byteArray.Length.Equals(0) ? string.Empty : Convert.ToBase64String(byteArray);
}
