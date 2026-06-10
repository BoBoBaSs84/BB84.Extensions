// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

/// <summary>
/// Provides a set of extension methods for <see cref="IEnumerable{T}"/> to simplify
/// common operations such as iterating over elements with actions, applying conditions,
/// and selecting random items.
/// </summary>
/// <remarks>
/// The <see cref="EnumerableExtensions"/> class includes utility methods that enhance the
/// usability of LINQ collections by adding functionality for element-wise operations and
/// random selection. These methods are designed to work seamlessly with any
/// <see cref="IEnumerable{T}"/> implementation.
/// </remarks>
public static class EnumerableExtensions
{
	/// <summary>
	/// Executes the specified action on each element of the sequence.
	/// </summary>
	/// <remarks>
	/// This method iterates through the collection and invokes the specified action for each
	/// element.
	/// </remarks>
	/// <typeparam name="T">The type of the elements in the collection.</typeparam>
	/// <param name="values">The collection of elements to iterate over.</param>
	/// <param name="action">The action to perform on each element.</param>
	public static void ForEach<T>(this IEnumerable<T> values, Action<T> action)
	{
		foreach (T value in values)
			action(value);
	}

	/// <summary>
	/// Executes a specified action on each element of the sequence that satisfies the given predicate.
	/// </summary>
	/// <remarks>
	/// This method filters the elements of the sequence using the specified predicate and then applies
	/// the provided action to each matching element. The sequence is not modified, and the method does not
	/// return a value.
	/// </remarks>
	/// <typeparam name="T">The type of the elements in the sequence.</typeparam>
	/// <param name="values">The sequence of elements to evaluate.</param>
	/// <param name="predicate">A function to test each element for a condition.</param>
	/// <param name="action">The action to perform on each element that satisfies the predicate.</param>
	public static void ForEach<T>(this IEnumerable<T> values, Func<T, bool> predicate, Action<T> action)
	{
		foreach (T value in values.Where(predicate))
			action(value);
	}

	/// <summary>
	/// Iterates over a filtered sequence of elements, performing an action on each element until a break
	/// condition is met.
	/// </summary>
	/// <remarks>
	/// This method applies the <paramref name="predicate"/> to filter the input sequence, then performs the
	/// specified <paramref name="action"/> on each filtered element until the <paramref name="breakCondition"/>
	/// is met. The iteration stops as soon as the <paramref name="breakCondition"/> returns <see langword="true"/>
	/// for an element.
	/// </remarks>
	/// <typeparam name="T">The type of elements in the sequence.</typeparam>
	/// <param name="values">The sequence of elements to iterate over.</param>
	/// <param name="predicate">A function to test each element for a condition.</param>
	/// <param name="breakCondition">A function that determines whether iteration should stop.</param>
	/// <param name="action">An action to perform on each element that passes the filter and does not meet the break condition.</param>
	public static void ForEach<T>(this IEnumerable<T> values, Func<T, bool> predicate, Func<T, bool> breakCondition, Action<T> action)
	{
		foreach (T value in values.Where(predicate))
		{
			if (breakCondition(value))
				break;

			action(value);
		}
	}

	/// <summary>
	/// Returns <see langword="true"/> if the collection of <paramref name="values"/> contains no items.
	/// </summary>
	/// <typeparam name="T">The type of elements in the sequence.</typeparam>
	/// <param name="values">The collection of elements to check.</param>
	/// <returns>True if the collection is empty; otherwise, false.</returns>
	public static bool IsEmpty<T>(this IEnumerable<T> values)
		=> !values.Any();

	/// <summary>
	/// Returns <see langword="true"/> if the collection of <paramref name="values"/> contains at least
	/// one item.
	/// </summary>
	/// <typeparam name="T">The type of elements in the sequence.</typeparam>
	/// <param name="values">The collection of elements to check.</param>
	/// <returns>True if the collection contains items; otherwise, false.</returns>
	public static bool IsNotEmpty<T>(this IEnumerable<T> values)
		=> values.Any();

	/// <summary>
	/// Returns <see langword="true"/> if the collection of <paramref name="values"/> is null or contains
	/// no items.
	/// </summary>
	/// <typeparam name="T">The type of elements in the sequence.</typeparam>
	/// <param name="values">The collection of elements to check.</param>
	/// <returns>True if the collection is null or empty; otherwise, false.</returns>
	public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? values)
		=> values is null || !values.Any();

	/// <summary>
	/// Returns <see langword="true"/> if the collection of <paramref name="values"/> is not null and contains
	/// at least one item.
	/// </summary>
	/// <typeparam name="T">The type of elements in the sequence.</typeparam>
	/// <param name="values">The collection of elements to check.</param>
	/// <returns>True if the collection is not null and contains items; otherwise, false.</returns>
	public static bool IsNotNullOrEmpty<T>([NotNullWhen(true)] this IEnumerable<T>? values)
		=> values is not null && values.Any();

	/// <summary>
	/// Randomizes the order of the items in the collection of <paramref name="values"/>.
	/// </summary>
	/// <typeparam name="T">The type of object in the collection.</typeparam>
	/// <param name="values">The collection of objects to randomize.</param>
	/// <returns>
	/// A new collection with the items in a randomized order.
	/// </returns>
	public static IEnumerable<T> Randomize<T>(this IEnumerable<T> values)
		=> values.ToList().Randomize();

	/// <summary>
	/// Returns a randomly choosen item from the collection of <paramref name="values"/>.
	/// </summary>
	/// <typeparam name="T">The type of object in the collection.</typeparam>
	/// <param name="values">The collection of objects to choose from.</param>
	/// <returns>A random item from the collection.</returns>
	public static T TakeRandom<T>(this IEnumerable<T> values)
		=> values.ToArray().TakeRandom();

	/// <summary>
	/// Returns a randomly chosen item from the collection of <paramref name="values"/>, or the
	/// default value of <typeparamref name="T"/> if the collection is empty.
	/// </summary>
	/// <typeparam name="T">The type of object in the collection.</typeparam>
	/// <param name="values">The collection of objects to choose from.</param>
	/// <returns>
	/// A random item from the collection, or <see langword="default"/> if the collection is empty.
	/// </returns>
	public static T? TakeRandomOrDefault<T>(this IEnumerable<T> values)
		=> values.ToArray().TakeRandomOrDefault();

	/// <summary>
	/// Attempts to retrieve a randomly chosen item from the collection of <paramref name="values"/>.
	/// </summary>
	/// <typeparam name="T">The type of object in the collection.</typeparam>
	/// <param name="values">The collection of objects to choose from.</param>
	/// <param name="result">
	/// When this method returns <see langword="true"/>, contains a randomly selected element from
	/// <paramref name="values"/>; otherwise, the default value of <typeparamref name="T"/>.
	/// </param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="values"/> is not empty and a random element was
	/// selected; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool TryTakeRandom<T>(this IEnumerable<T> values, [MaybeNullWhen(false)] out T result)
		=> values.ToArray().TryTakeRandom(out result);

	/// <summary>
	/// Splits the elements of <paramref name="values"/> into chunks of at most
	/// <paramref name="size"/> elements each. The last chunk will contain the remaining elements
	/// if the sequence length is not evenly divisible by <paramref name="size"/>.
	/// </summary>
	/// <typeparam name="T">The type of elements in the sequence.</typeparam>
	/// <param name="values">The sequence to partition.</param>
	/// <param name="size">The maximum number of elements in each chunk.</param>
	/// <returns>
	/// An <see cref="IEnumerable{T}"/> of <typeparamref name="T"/>[] where each array contains
	/// at most <paramref name="size"/> elements.
	/// </returns>
	/// <exception cref="ArgumentNullException">
	/// Thrown when <paramref name="values"/> is <see langword="null"/>.
	/// </exception>
	/// <exception cref="ArgumentOutOfRangeException">
	/// Thrown when <paramref name="size"/> is less than or equal to zero.
	/// </exception>
	public static IEnumerable<T[]> Chunk<T>(this IEnumerable<T> values, int size)
	{
#if NET6_0_OR_GREATER
		ArgumentNullException.ThrowIfNull(values);
#else
		if (values is null)
			throw new ArgumentNullException(nameof(values));
#endif
		if (size <= 0)
			throw new ArgumentOutOfRangeException(nameof(size), "Size must be greater than zero.");

#if NET6_0_OR_GREATER
		return Enumerable.Chunk(values, size);
#else
		return ChunkIterator(values, size);
#endif
	}

#if !NET6_0_OR_GREATER
	private static IEnumerable<T[]> ChunkIterator<T>(IEnumerable<T> values, int size)
	{
		T[] chunk = new T[size];
		int index = 0;

		foreach (T value in values)
		{
			chunk[index++] = value;

			if (index == size)
			{
				yield return chunk;
				chunk = new T[size];
				index = 0;
			}
		}

		if (index > 0)
		{
			T[] remainder = new T[index];
			Array.Copy(chunk, remainder, index);
			yield return remainder;
		}
	}
#endif
}
