namespace BB84.Extensions;

/// <summary>
/// The enumerable extensions class.
/// </summary>
public static class EnumerableExtensions
{
	/// <summary>
	/// Iterates over an enumerable and executes an Action on each element.
	/// </summary>
	/// <typeparam name="T">The type of the elements of source.</typeparam>
	/// <param name="source">A sequence of values to invoke an action on.</param>
	/// <param name="action">An Action to invoke on each source element.</param>
	public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
	{
		foreach (T? item in source)
			action(item);
	}
}
