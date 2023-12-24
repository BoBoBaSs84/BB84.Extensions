namespace BB84.Extensions;

public static partial class ListExtensions
{
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
