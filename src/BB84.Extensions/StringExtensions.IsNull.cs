// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

public static partial class StringExtensions
{
	/// <summary>
	/// Indicates whether the specified string value is <see langword="null"/> or not.
	/// </summary>
	/// <param name="value">The string value to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is <see langword="null"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNull([NotNullWhen(false)] this string? value)
		=> value is null;

	/// <summary>
	/// Indicates whether the specified string value is <see langword="null"/> or an <see cref="string.Empty"/>.
	/// </summary>
	/// <param name="value">The string value to test.</param>
	/// <returns>True if the value parameter is null or an empty string, otherwise false.</returns>
	public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value)
		=> string.IsNullOrEmpty(value);

	/// <summary>
	/// Indicates whether a specified string is null, empty, or consists only of white-space characters.
	/// </summary>
	/// <param name="value">The string value to test.</param>
	/// <returns>True if the value parameter is null or an empty string or if value consists
	/// exclusively of white-space characters, otherwise false.</returns>
	public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value)
		=> string.IsNullOrWhiteSpace(value);
}
