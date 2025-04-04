// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

public static partial class EnumerableExtensions
{
	/// <summary>
	/// Returns a randomly choosen item from the collection of <paramref name="values"/>.
	/// </summary>
	/// <typeparam name="T">The type of object in the collection.</typeparam>
	/// <param name="values">The collection of objects to choose from.</param>
	/// <returns>A random item from the collection.</returns>
	public static T TakeRandom<T>(this IEnumerable<T> values)
		=> values.ToArray().TakeRandom();
}
