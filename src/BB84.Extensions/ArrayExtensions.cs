// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.Extensions.Helper;

namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for working with arrays.
/// </summary>
/// <remarks>
/// This class contains utility methods that extend the functionality of arrays, such
/// as selecting random elements.
/// </remarks>
public static class ArrayExtensions
{
	/// <summary>
	/// Randomizes the order of elements in the specified array.
	/// </summary>
	/// <typeparam name="T">The type of elements in the array.</typeparam>
	/// <param name="array">The array to randomize.</param>
	/// <returns>
	/// A new array containing the elements of the original array in random order.
	/// </returns>
	public static T[] Randomize<T>(this T[] array)
		=> [.. array.ToList().Randomize()];

	/// <summary>
	/// Selects a random element from the specified <paramref name="array"/>.
	/// </summary>
	/// <remarks>
	/// This method uses a random number generator to select an element from the array.
	/// </remarks>
	/// <typeparam name="T">The type of elements in the array.</typeparam>
	/// <param name="array">The array from which to select a random element.</param>
	/// <returns>
	/// A randomly selected element of <typeparamref name="T"/> from the <paramref name="array"/>.
	/// </returns>
	public static T TakeRandom<T>(this T[] array)
		=> array.ToList().TakeRandom();
}
