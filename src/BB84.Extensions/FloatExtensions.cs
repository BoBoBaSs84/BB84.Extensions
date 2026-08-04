// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.Extensions.Common;

namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for working with <see cref="float"/> and nullable <see cref="float"/> values.
/// </summary>
/// <remarks>
/// This class includes utility methods to simplify common operations on float values, such as
/// checking for null, default or sign related states. These methods are designed to improve code
/// readability and reduce boilerplate when working with floats.
/// <para>
/// The sign related methods follow the IEEE comparison operators, which means that
/// <see cref="float.NaN"/> is neither positive, negative, non-positive nor non-negative and
/// therefore yields <see langword="false"/> in all four cases.
/// </para>
/// </remarks>
public static class FloatExtensions
{
	/// <summary>
	/// Determines whether the specified float is equal to its default value (0).
	/// </summary>
	/// <param name="value">The float to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is equal to its default value (0);
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsDefault(this float value)
		=> NumericCore.IsDefault(value);

	/// <summary>
	/// Determines whether the specified nullable float is equal to its default value <see langword="null"/>.
	/// </summary>
	/// <param name="value">The nullable float to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is equal to its default value <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsDefault([NotNullWhen(false)] this float? value)
		=> NumericCore.IsDefault(value);

	// The sign predicates below deliberately use the comparison operators instead of NumericCore:
	// IComparable<float> orders NaN below zero, so routing them through the core would turn
	// IsNegative(NaN) and IsNonPositive(NaN) from false into true.

	/// <summary>
	/// Determines whether the specified float value is negative.
	/// </summary>
	/// <param name="value">The float value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the specified value is less than zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNegative(this float value)
		=> value < 0;

	/// <summary>
	/// Determines whether the specified nullable float value is negative.
	/// </summary>
	/// <param name="value">The nullable float value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> has a value and is less than zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNegative([NotNullWhen(true)] this float? value)
		=> value.HasValue && value.Value < 0;

	/// <summary>
	/// Determines whether the specified float is not equal to its default value (0).
	/// </summary>
	/// <param name="value">The float to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is not equal to its default value (0);
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotDefault(this float value)
		=> NumericCore.IsNotDefault(value);

	/// <summary>
	/// Determines whether the specified float is not equal to its default value <see langword="null"/>.
	/// </summary>
	/// <param name="value">The float to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is not equal to its default value <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotDefault([NotNullWhen(true)] this float? value)
		=> NumericCore.IsNotDefault(value);

	/// <summary>
	/// Determines whether the specified nullable float has a null value.
	/// </summary>
	/// <param name="value">The nullable float to check.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNull([NotNullWhen(false)] this float? value)
		=> NumericCore.IsNull(value);

	/// <summary>
	/// Determines whether the specified nullable float has a value.
	/// </summary>
	/// <param name="value">The nullable float to check.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is not <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotNull([NotNullWhen(true)] this float? value)
		=> NumericCore.IsNotNull(value);

	/// <summary>
	/// Determines whether the specified float value is non-negative.
	/// </summary>
	/// <param name="value">The float value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the specified value is greater than or equal to zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNonNegative(this float value)
		=> value >= 0;

	/// <summary>
	/// Determines whether the specified nullable float value is non-negative.
	/// </summary>
	/// <param name="value">The nullable float value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> has a value and is greater than or equal to zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNonNegative([NotNullWhen(true)] this float? value)
		=> value.HasValue && value.Value >= 0;

	/// <summary>
	/// Determines whether the specified float value is less than or equal to zero.
	/// </summary>
	/// <param name="value">The float value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the specified value is less than or equal to zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNonPositive(this float value)
		=> value <= 0;

	/// <summary>
	/// Determines whether the specified nullable float value is non-positive.
	/// </summary>
	/// <param name="value">The nullable float value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the value is not <see langword="null"/> and less than or equal to zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNonPositive([NotNullWhen(true)] this float? value)
		=> value.HasValue && value.Value <= 0;

	/// <summary>
	/// Determines whether the specified float value is positive.
	/// </summary>
	/// <param name="value">The float value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the specified value is greater than zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsPositive(this float value)
		=> value > 0;

	/// <summary>
	/// Determines whether the specified nullable float value is positive.
	/// </summary>
	/// <param name="value">The nullable float value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> has a value and is greater than zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsPositive([NotNullWhen(true)] this float? value)
		=> value.HasValue && value.Value > 0;
}
