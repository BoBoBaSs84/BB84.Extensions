// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
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

	/// <summary>
	/// Returns a random element from the specified <paramref name="array"/>, or the default value of
	/// <typeparamref name="T"/> if the array is empty.
	/// </summary>
	/// <typeparam name="T">The type of elements in the array.</typeparam>
	/// <param name="array">The array from which to select a random element.</param>
	/// <returns>
	/// A randomly selected element from <paramref name="array"/>, or <see langword="default"/> if
	/// the array is empty.
	/// </returns>
	public static T? TakeRandomOrDefault<T>(this T[] array)
		=> array.ToList().TakeRandomOrDefault();

	/// <summary>
	/// Attempts to retrieve a random element from the specified <paramref name="array"/>.
	/// </summary>
	/// <typeparam name="T">The type of elements in the array.</typeparam>
	/// <param name="array">The array from which to select a random element.</param>
	/// <param name="result">
	/// When this method returns <see langword="true"/>, contains a randomly selected element from
	/// <paramref name="array"/>; otherwise, the default value of <typeparamref name="T"/>.
	/// </param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="array"/> is not empty and a random element was
	/// selected; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool TryTakeRandom<T>(this T[] array, [MaybeNullWhen(false)] out T result)
		=> array.ToList().TryTakeRandom(out result);
}
