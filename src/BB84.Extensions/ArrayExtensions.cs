﻿// Copyright: 2023 Robert Peter Meyer
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
	/// Selects a random element from the specified <paramref name="values"/>.
	/// </summary>
	/// <remarks>
	/// This method uses a random number generator to select an element from the array.
	/// </remarks>
	/// <typeparam name="T">The type of elements in the array.</typeparam>
	/// <param name="values">The array from which to select a random element.</param>
	/// <returns>
	/// A randomly selected element of <typeparamref name="T"/> from the <paramref name="values"/>.
	/// </returns>
	public static T TakeRandom<T>(this T[] values)
		=> values[RandomHelper.Random.Next(0, values.Length)];
}
