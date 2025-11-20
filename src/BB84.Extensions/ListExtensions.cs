// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.Extensions.Helper;

namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for working with <see cref="IList{T}"/> objects, enabling
/// conditional addition of items or collections.
/// </summary>
/// <remarks>
/// This class includes methods to add items or collections to a list only if they are not null.
/// These methods help simplify common null-checking patterns when working with lists.
/// </remarks>
public static class ListExtensions
{
	/// <summary>
	/// Adds the item of <typeparamref name="T"/> to the <paramref name="list"/> when not null.
	/// </summary>
	/// <typeparam name="T">The item type to work with.</typeparam>
	/// <param name="list">The sequence of <typeparamref name="T"/> to work with.</param>
	/// <param name="item">The item of <typeparamref name="T"/> to add or not.</param>
	/// <exception cref="ArgumentNullException">If the target is null.</exception>
	public static void AddIfNotNull<T>(this IList<T> list, T item)
	{
#if NET6_0_OR_GREATER
		ArgumentNullException.ThrowIfNull(list);
#else
		if (list is null)
			throw new ArgumentNullException(nameof(list));
#endif
		if (item is null)
			return;

		list.Add(item);
	}

	/// <summary>
	/// Adds the <see cref="IEnumerable{T}"/> to the <paramref name="list"/> when not null.
	/// </summary>
	/// <typeparam name="T">The item type to work with.</typeparam>
	/// <param name="list">The sequence of <typeparamref name="T"/> to work with.</param>
	/// <param name="items">The items of <typeparamref name="T"/> to add or not.</param>
	/// <exception cref="ArgumentNullException">If the target is null.</exception>
	public static void AddRangeIfNotNull<T>(this IList<T> list, IEnumerable<T> items)
	{
#if NET6_0_OR_GREATER
		ArgumentNullException.ThrowIfNull(list);
#else
		if (list is null)
			throw new ArgumentNullException(nameof(list));
#endif

		if (items is null || items.Any().Equals(false))
			return;

		items.ForEach(list.AddIfNotNull);
	}

	/// <summary>
	/// Returns a new list with the elements of the <paramref name="list"/> list in random order.
	/// </summary>
	/// <remarks>
	/// This method uses a random number generator to shuffle the elements of the list.
	/// The original list remains unchanged.
	/// </remarks>
	/// <typeparam name="T">The type of elements in the list.</typeparam>
	/// <param name="list">The list to randomize.</param>
	/// <returns>
	/// A new list containing the elements of the <paramref name="list"/> list in a randomized order.
	/// </returns>
	public static IList<T> Randomize<T>(this IList<T> list)
	{
		IList<T> newList = [.. list];

		int sourceCount = newList.Count;
		for (int currentPosition = sourceCount - 1; currentPosition > 0; currentPosition--)
		{
			int newPosition = RandomHelper.Random.Next(currentPosition + 1);
			(newList[newPosition], newList[currentPosition]) = (newList[currentPosition], newList[newPosition]);
		}

		return newList;
	}

	/// <summary>
	/// Returns a random element from the specified list.
	/// </summary>
	/// <typeparam name="T">The type of elements in the list.</typeparam>
	/// <param name="list">The list from which to take a random element.</param>
	/// <returns>A random element from the <paramref name="list"/>.</returns>
	public static T TakeRandom<T>(this IList<T> list)
		=> list[RandomHelper.Random.Next(0, list.Count)];
}
