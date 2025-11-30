// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for working with nullable <see cref="long"/> values.
/// </summary>
/// <remarks>
/// This static class contains utility methods for common operations involving longs, such as creating
/// arrays of longs within a specified range, performing actions over a range of longs, and
/// determining whether nullable longs are null or non-null.
/// </remarks>
public static class LongExtensions
{
	/// <summary>
	/// Executes the specified action for each long from 0 to the specified value (exclusive).
	/// </summary>
	/// <remarks>
	/// This method iterates from 0 to <paramref name="value"/> - 1, invoking <paramref name="action"/>
	/// for each long.
	/// </remarks>
	/// <param name="value">The upper limit (exclusive) of the range.</param>
	/// <param name="action">The action to execute for each long in the range.</param>
	public static void For(this long value, Action<long> action)
	{
		for (long i = 0; i < value; i++)
			action(i);
	}

	/// <summary>
	/// Determines whether the specified long is equal to its default value (0).
	/// </summary>
	/// <param name="value">The long to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is equal to its default value (0);
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsDefault(this long value)
		=> value.Equals(default);

	/// <summary>
	/// Determines whether the specified nullable long is equal to its default value <see langword="null"/>.
	/// </summary>
	/// <param name="value">The nullable long to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is equal to its default value <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsDefault([NotNullWhen(false)] this long? value)
		=> value.Equals(default);

	/// <summary>
	/// Determines whether the specified long value is negative.
	/// </summary>
	/// <param name="value">The long value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the specified value is less than zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNegative(this long value)
		=> value < 0;

	/// <summary>
	/// Determines whether the specified nullable long value is negative.
	/// </summary>
	/// <param name="value">The nullable long value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> has a value and is less than zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNegative([NotNullWhen(true)] this long? value)
		=> value.HasValue && value.Value < 0;

	/// <summary>
	/// Determines whether the specified long is not equal to its default value (0).
	/// </summary>
	/// <param name="value">The long to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is not equal to its default value (0);
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotDefault(this long value)
		=> value.Equals(default).Equals(false);

	/// <summary>
	/// Determines whether the specified long is not equal to its default value <see langword="null"/>.
	/// </summary>
	/// <param name="value">The long to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is not equal to its default value <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotDefault([NotNullWhen(true)] this long? value)
		=> value.Equals(default).Equals(false);

	/// <summary>
	/// Determines whether the specified nullable long has a null value.
	/// </summary>
	/// <param name="value">The nullable long to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNull([NotNullWhen(false)] this long? value)
		=> value.HasValue.Equals(false);

	/// <summary>
	/// Determines whether the specified nullable long has a non-null value.
	/// </summary>
	/// <param name="value">The nullable long to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is not <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotNull([NotNullWhen(true)] this long? value)
		=> value.HasValue.Equals(true);

	/// <summary>
	/// Determines whether the specified long value is non-negative.
	/// </summary>
	/// <param name="value">The long value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the specified value is greater than or equal to zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNonNegative(this long value)
		=> value >= 0;

	/// <summary>
	/// Determines whether the specified nullable long value is non-negative.
	/// </summary>
	/// <param name="value">The nullable long value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> has a value and is greater than or equal to zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNonNegative([NotNullWhen(true)] this long? value)
		=> value.HasValue && value.Value >= 0;

	/// <summary>
	/// Determines whether the specified long value is less than or equal to zero.
	/// </summary>
	/// <param name="value">The long value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the specified value is less than or equal to zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNonPositive(this long value)
		=> value <= 0;

	/// <summary>
	/// Determines whether the specified nullable long value is non-positive.
	/// </summary>
	/// <param name="value">The nullable long value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the value is not <see langword="null"/> and less than or equal to zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNonPositive([NotNullWhen(true)] this long? value)
		=> value.HasValue && value.Value <= 0;

	/// <summary>
	/// Determines whether the specified long value is positive.
	/// </summary>
	/// <param name="value">The long value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the specified value is greater than zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsPositive(this long value)
		=> value > 0;

	/// <summary>
	/// Determines whether the specified nullable long value is positive.
	/// </summary>
	/// <param name="value">The nullable long value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> has a value and is greater than zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsPositive([NotNullWhen(true)] this long? value)
		=> value.HasValue && value.Value > 0;
}
