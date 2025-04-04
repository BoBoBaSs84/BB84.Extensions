// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

public static partial class StringExtensions
{
	/// <summary>
	/// Removes unwanted whitespace within the provided string value.
	/// </summary>
	/// <param name="stringValue">The input string value to modify.</param>
	/// <returns>The same <see cref="string"/> instance so that multiple calls can be chained.</returns>
	public static string RemoveWhitespace(this string stringValue)
		=> WhitespaceRegex.Replace(stringValue, string.Empty);
}
