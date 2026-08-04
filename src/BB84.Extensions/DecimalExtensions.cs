// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.Extensions.Common;

namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for working with <see cref="decimal"/> and nullable <see cref="decimal"/> values.
/// </summary>
/// <remarks>
/// This class includes utility methods to simplify common operations on decimal values, such as
/// checking for null, default or sign related states. These methods are designed to improve code
/// readability and reduce boilerplate when working with decimals.
/// </remarks>
public static class DecimalExtensions
{
	/// <summary>
	/// Executes the specified action for each decimal from 0 to the specified value (exclusive).
	/// </summary>
	/// <remarks>
	/// This method iterates from 0 to <paramref name="value"/> - 1, invoking <paramref name="action"/>
	/// for each decimal.
	/// </remarks>
	/// <param name="value">The upper limit (exclusive) of the range.</param>
	/// <param name="action">The action to execute for each decimal in the range.</param>
	public static void For(this decimal value, Action<decimal> action)
	{
		for (decimal i = 0; i < value; i++)
			action(i);
	}

	/// <summary>
	/// Determines whether the specified decimal is equal to its default value (0).
	/// </summary>
	/// <param name="value">The decimal to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is equal to its default value (0);
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsDefault(this decimal value)
		=> NumericCore.IsDefault(value);

	/// <summary>
	/// Determines whether the specified nullable decimal is equal to its default value <see langword="null"/>.
	/// </summary>
	/// <param name="value">The nullable decimal to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is equal to its default value <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsDefault([NotNullWhen(false)] this decimal? value)
		=> NumericCore.IsDefault(value);

	/// <summary>
	/// Determines whether the specified decimal value is negative.
	/// </summary>
	/// <param name="value">The decimal value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the specified value is less than zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNegative(this decimal value)
		=> NumericCore.IsNegative(value);

	/// <summary>
	/// Determines whether the specified nullable decimal value is negative.
	/// </summary>
	/// <param name="value">The nullable decimal value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> has a value and is less than zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNegative([NotNullWhen(true)] this decimal? value)
		=> NumericCore.IsNegative(value);

	/// <summary>
	/// Determines whether the specified decimal is not equal to its default value (0).
	/// </summary>
	/// <param name="value">The decimal to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is not equal to its default value (0);
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotDefault(this decimal value)
		=> NumericCore.IsNotDefault(value);

	/// <summary>
	/// Determines whether the specified decimal is not equal to its default value <see langword="null"/>.
	/// </summary>
	/// <param name="value">The decimal to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is not equal to its default value <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotDefault([NotNullWhen(true)] this decimal? value)
		=> NumericCore.IsNotDefault(value);

	/// <summary>
	/// Determines whether the specified nullable decimal has a null value.
	/// </summary>
	/// <param name="value">The nullable decimal value to check.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNull([NotNullWhen(false)] this decimal? value)
		=> NumericCore.IsNull(value);

	/// <summary>
	/// Determines whether the specified nullable decimal has a value.
	/// </summary>
	/// <param name="value">The nullable decimal to check.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is not <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotNull([NotNullWhen(true)] this decimal? value)
		=> NumericCore.IsNotNull(value);

	/// <summary>
	/// Determines whether the specified decimal value is non-negative.
	/// </summary>
	/// <param name="value">The decimal value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the specified value is greater than or equal to zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNonNegative(this decimal value)
		=> NumericCore.IsNonNegative(value);

	/// <summary>
	/// Determines whether the specified nullable decimal value is non-negative.
	/// </summary>
	/// <param name="value">The nullable decimal value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> has a value and is greater than or equal to zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNonNegative([NotNullWhen(true)] this decimal? value)
		=> NumericCore.IsNonNegative(value);

	/// <summary>
	/// Determines whether the specified decimal value is less than or equal to zero.
	/// </summary>
	/// <param name="value">The decimal value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the specified value is less than or equal to zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNonPositive(this decimal value)
		=> NumericCore.IsNonPositive(value);

	/// <summary>
	/// Determines whether the specified nullable decimal value is non-positive.
	/// </summary>
	/// <param name="value">The nullable decimal value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the value is not <see langword="null"/> and less than or equal to zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNonPositive([NotNullWhen(true)] this decimal? value)
		=> NumericCore.IsNonPositive(value);

	/// <summary>
	/// Determines whether the specified decimal value is positive.
	/// </summary>
	/// <param name="value">The decimal value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the specified value is greater than zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsPositive(this decimal value)
		=> NumericCore.IsPositive(value);

	/// <summary>
	/// Determines whether the specified nullable decimal value is positive.
	/// </summary>
	/// <param name="value">The nullable decimal value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> has a value and is greater than zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsPositive([NotNullWhen(true)] this decimal? value)
		=> NumericCore.IsPositive(value);
}
