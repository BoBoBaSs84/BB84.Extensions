// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
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
	/// Adds the item of <typeparamref name="T"/> to the <paramref name="target"/> when not null.
	/// </summary>
	/// <typeparam name="T">The item type to work with.</typeparam>
	/// <param name="target">The sequence of <typeparamref name="T"/> to work with.</param>
	/// <param name="item">The item of <typeparamref name="T"/> to add or not.</param>
	/// <exception cref="ArgumentNullException">If the target is null.</exception>
	public static void AddIfNotNull<T>(this IList<T> target, T item)
	{
#if NET6_0_OR_GREATER
		ArgumentNullException.ThrowIfNull(target);
#else
		if (target is null)
			throw new ArgumentNullException(nameof(target));
#endif
		if (item is null)
			return;

		target.Add(item);
	}

	/// <summary>
	/// Adds the <see cref="IEnumerable{T}"/> to the <paramref name="target"/> when not null.
	/// </summary>
	/// <typeparam name="T">The item type to work with.</typeparam>
	/// <param name="target">The sequence of <typeparamref name="T"/> to work with.</param>
	/// <param name="items">The items of <typeparamref name="T"/> to add or not.</param>
	/// <exception cref="ArgumentNullException">If the target is null.</exception>
	public static void AddRangeIfNotNull<T>(this IList<T> target, IEnumerable<T> items)
	{
#if NET6_0_OR_GREATER
		ArgumentNullException.ThrowIfNull(target);
#else
		if (target is null)
			throw new ArgumentNullException(nameof(target));
#endif

		if (items is null || items.Any().Equals(false))
			return;

		items.ForEach(target.AddIfNotNull);
	}
}
