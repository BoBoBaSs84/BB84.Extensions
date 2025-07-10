// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for working with nullable <see cref="decimal"/> values.
/// </summary>
/// <remarks>
/// This class includes utility methods to simplify common operations on nullable decimal
/// values, such as checking for null or non-null states. These methods are designed to
/// improve code readability and reduce boilerplate when working with nullable decimals.
/// </remarks>
public static class DecimalExtensions
{
	/// <summary>
	/// Determines whether the specified nullable decimal has a null value.
	/// </summary>
	/// <param name="value">The nullable decimal value to check.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNull([NotNullWhen(false)] this decimal? value)
		=> value.HasValue.Equals(false);
}
