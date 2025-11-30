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
	/// Determines whether the specified double value is negative.
	/// </summary>
	/// <param name="value">The double value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the specified value is less than zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNegative(this double value)
		=> value < 0;

	/// <summary>
	/// Determines whether the specified nullable double value is negative.
	/// </summary>
	/// <param name="value">The nullable double value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> has a value and is less than zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNegative([NotNullWhen(true)] this double? value)
		=> value.HasValue && value.Value < 0;

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

	/// <summary>
	/// Determines whether the specified double value is non-negative.
	/// </summary>
	/// <param name="value">The double value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the specified value is greater than or equal to zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNonNegative(this double value)
		=> value >= 0;

	/// <summary>
	/// Determines whether the specified nullable double value is non-negative.
	/// </summary>
	/// <param name="value">The nullable double value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> has a value and is greater than or equal to zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNonNegative([NotNullWhen(true)] this double? value)
		=> value.HasValue && value.Value >= 0;

	/// <summary>
	/// Determines whether the specified double value is less than or equal to zero.
	/// </summary>
	/// <param name="value">The double value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the specified value is less than or equal to zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNonPositive(this double value)
		=> value <= 0;

	/// <summary>
	/// Determines whether the specified nullable double value is non-positive.
	/// </summary>
	/// <param name="value">The nullable double value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the value is not <see langword="null"/> and less than or equal to zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNonPositive([NotNullWhen(true)] this double? value)
		=> value.HasValue && value.Value <= 0;

	/// <summary>
	/// Determines whether the specified double value is positive.
	/// </summary>
	/// <param name="value">The double value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the specified value is greater than zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsPositive(this double value)
		=> value > 0;

	/// <summary>
	/// Determines whether the specified nullable double value is positive.
	/// </summary>
	/// <param name="value">The nullable double value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> has a value and is greater than zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsPositive([NotNullWhen(true)] this double? value)
		=> value.HasValue && value.Value > 0;
}
