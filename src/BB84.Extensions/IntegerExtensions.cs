// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for working with nullable <see cref="int"/> values.
/// </summary>
/// <remarks>
/// This static class contains utility methods for common operations involving integers, such as creating
/// arrays of integers within a specified range, performing actions over a range of integers, and
/// determining whether nullable integers are null or non-null.
/// </remarks>
public static class IntegerExtensions
{
	/// <summary>
	/// Generates an array of integers starting from a specified minimum value up to the given value.
	/// </summary>
	/// <remarks>
	/// This method creates an array where each element corresponds to an integer in the range from 
	/// <paramref name="value"/> to <paramref name="minValue"/>. The array is zero-based, and the indices
	/// of the array correspond to the values in the range.
	/// </remarks>
	/// <param name="value">The maximum value in the resulting array. Must be greater than or equal to <paramref name="minValue"/>.</param>
	/// <param name="minValue">The minimum value in the resulting array. Must be less than or equal to <paramref name="value"/>.</param>
	/// <returns>
	/// An array of integers ranging from <paramref name="minValue"/> to <paramref name="value"/> (inclusive).
	/// </returns>
	/// <exception cref="ArgumentOutOfRangeException">
	/// Thrown if <paramref name="minValue"/> is greater than <paramref name="value"/>.
	/// </exception>
	public static int[] ArrayDown(this int value, int minValue)
	{
		if (value < minValue)
			throw new ArgumentOutOfRangeException(nameof(minValue), "Minimum value must be smaller than the starting value.");

		int[] array = new int[value + 1];
		for (int i = minValue; i <= value; i++)
			array[i] = i;
		return array;
	}

	/// <summary>
	/// Generates an array of integers starting from the specified value up to the specified maximum value.
	/// </summary>
	/// <remarks>
	/// This method creates an array where each element corresponds to an integer in the range from 
	/// <paramref name="value"/> to <paramref name="maxValue"/>. The array is zero-based, and the indices
	/// of the array correspond to the values in the range.
	/// </remarks>
	/// <param name="value">The starting value of the array. Must be less than or equal to <paramref name="maxValue"/>.</param>
	/// <param name="maxValue">The maximum value to include in the array. Must be greater than or equal to <paramref name="value"/>.</param>
	/// <returns>
	/// An array of integers ranging from <paramref name="value"/> to <paramref name="maxValue"/> (inclusive).
	/// </returns>
	/// <exception cref="ArgumentOutOfRangeException">
	/// Thrown if <paramref name="maxValue"/> is less than <paramref name="value"/>.
	/// </exception>
	public static int[] ArrayUp(this int value, int maxValue)
	{
		if (value > maxValue)
			throw new ArgumentOutOfRangeException(nameof(maxValue), "Maximum value must be greater than the starting value.");

		int[] array = new int[maxValue + 1];
		for (int i = value; i <= maxValue; i++)
			array[i] = i;
		return array;
	}

	/// <summary>
	/// Executes the specified action for each integer from 0 to the specified value (exclusive).
	/// </summary>
	/// <remarks>
	/// This method iterates from 0 to <paramref name="value"/> - 1, invoking <paramref name="action"/>
	/// for each integer.
	/// </remarks>
	/// <param name="value">The upper limit (exclusive) of the range.</param>
	/// <param name="action">The action to execute for each integer in the range.</param>
	public static void For(this int value, Action<int> action)
	{
		for (int i = 0; i < value; i++)
			action(i);
	}

	/// <summary>
	/// Determines whether the specified nullable integer has a null value.
	/// </summary>
	/// <param name="value">The nullable integer to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNull([NotNullWhen(false)] this int? value)
		=> value.HasValue.Equals(false);
}
