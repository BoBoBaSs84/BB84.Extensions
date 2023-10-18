namespace BB84.Extensions;

/// <summary>
/// The list extensions class.
/// </summary>
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
		if (target is null)
			throw new ArgumentNullException(nameof(target));

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
		if (target is null)
			throw new ArgumentNullException(nameof(target));

		if (items is null || items.Any().Equals(false))
			return;

		if (target is List<T> list)
		{
			list.AddRange(items);
			return;
		}

		foreach (T? item in items)
			target.Add(item);
	}
}
