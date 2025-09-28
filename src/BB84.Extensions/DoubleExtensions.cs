// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for working with nullable <see cref="double"/> values.
/// </summary>
/// <remarks>
/// This class includes utility methods to simplify common operations on nullable double
/// values, such as checking for null or non-null states. These methods are designed to
/// improve code readability and reduce boilerplate when working with nullable doubles.
/// </remarks>
public static class DoubleExtensions
{
	/// <summary>
	/// Determines whether the specified double is equal to its default value (0).
	/// </summary>
	/// <param name="value">The double to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is equal to its default value (0);
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsDefault(this double value)
		=> value.Equals(default);

	/// <summary>
	/// Determines whether the specified nullable double is equal to its default value <see langword="null"/>.
	/// </summary>
	/// <param name="value">The nullable double to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is equal to its default value <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsDefault([NotNullWhen(false)] this double? value)
		=> value.Equals(default);

	/// <summary>
	/// Determines whether the specified double is not equal to its default value (0).
	/// </summary>
	/// <param name="value">The double to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is not equal to its default value (0);
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotDefault(this double value)
		=> value.Equals(default).Equals(false);

	/// <summary>
	/// Determines whether the specified double is not equal to its default value <see langword="null"/>.
	/// </summary>
	/// <param name="value">The double to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is not equal to its default value <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotDefault([NotNullWhen(true)] this double? value)
		=> value.Equals(default).Equals(false);

	/// <summary>
	/// Determines whether the specified nullable double has a null value.
	/// </summary>
	/// <param name="value">The nullable double to check.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNull([NotNullWhen(false)] this double? value)
		=> value.HasValue.Equals(false);

	/// <summary>
	/// Determines whether the specified nullable double has a value.
	/// </summary>
	/// <param name="value">The nullable double to check.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is not <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotNull([NotNullWhen(true)] this double? value)
		=> value.HasValue.Equals(true);
}
