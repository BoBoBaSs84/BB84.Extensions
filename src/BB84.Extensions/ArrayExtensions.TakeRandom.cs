// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.Extensions.Helper;

namespace BB84.Extensions;

public static partial class ArrayExtensions
{
	/// <summary>
	/// Returns a randomly choosen item from a given array of <paramref name="values"/>.
	/// </summary>
	/// <typeparam name="T">The type of object in the array.</typeparam>
	/// <param name="values">The array of objects to choose from.</param>
	/// <returns>A random item from the array.</returns>
	public static T TakeRandom<T>(this T[] values)
		=> values[RandomHelper.Random.Next(0, values.Length)];
}
