// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

public static partial class IntegerExtensions
{
	/// <summary>
	/// Returns an array of integers starting from the <paramref name="value"/> to the <paramref name="maxValue"/>.
	/// </summary>
	/// <param name="value">The value to start from.</param>
	/// <param name="maxValue">The value to end with.</param>
	/// <returns>An array of integers.</returns>
	/// /// <exception cref="ArgumentOutOfRangeException"></exception>
	public static int[] ArrayUp(this int value, int maxValue)
	{
		if (value > maxValue)
			throw new ArgumentOutOfRangeException(nameof(maxValue), "Maximum value must be greater than the starting value.");

		int[] array = new int[maxValue + 1];
		for (int i = value; i <= maxValue; i++)
			array[i] = i;
		return array;
	}
}
