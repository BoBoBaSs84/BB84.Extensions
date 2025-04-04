// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Globalization;

namespace BB84.Extensions;

public static partial class StringExtensions
{
	/// <summary>
	/// Formats the string with <paramref name="parameters"/> to an invariant culture.
	/// </summary>
	/// <param name="stringValue">The string with placeholders.</param>
	/// <param name="parameters">The parameters to set for the placeholders.</param>
	/// <returns>The formated string.</returns>
	public static string FormatInvariant(this string stringValue, params object[] parameters)
			=> string.Format(CultureInfo.InvariantCulture, stringValue, parameters);

	/// <summary>
	/// Formats the string with <paramref name="parameters"/> to an provided culture.
	/// </summary>
	/// <param name="stringValue">The string with placeholders.</param>
	/// <param name="formatProvider">The format provider to use.</param>
	/// <param name="parameters">The parameters to set for the placeholders.</param>
	/// <returns>The formated string.</returns>
	public static string Format(this string stringValue, IFormatProvider formatProvider, params object[] parameters)
			=> string.Format(formatProvider, stringValue, parameters);
}
