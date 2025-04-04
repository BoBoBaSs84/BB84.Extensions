// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

public static partial class EnumerableExtensions
{
	/// <summary>
	/// Iterates over the <paramref name="values"/> and executes an <paramref name="action"/>
	/// on each element.
	/// </summary>
	/// <typeparam name="T">The type of the elements of source.</typeparam>
	/// <param name="values">A sequence of values to invoke an action on.</param>
	/// <param name="action">The action to invoke on each source element.</param>
	public static void ForEach<T>(this IEnumerable<T> values, Action<T> action)
	{
		foreach (T value in values)
			action(value);
	}

	/// <summary>
	/// Iterates over the <paramref name="values"/> that fit the <paramref name="predicate"/>
	/// and executes an <paramref name="action"/> on each element.
	/// </summary>
	/// <typeparam name="T">The type of the elements of source.</typeparam>
	/// <param name="values">A sequence of values to invoke an action on.</param>
	/// <param name="predicate">The function to test each element for a condition.</param>
	/// <param name="action">The action to invoke on each source element.</param>
	public static void ForEach<T>(this IEnumerable<T> values, Func<T, bool> predicate, Action<T> action)
	{
		foreach (T value in values.Where(predicate))
			action(value);
	}

	/// <summary>
	/// Iterates over the <paramref name="values"/> that fit the <paramref name="predicate"/>
	/// and executes an <paramref name="action"/> on each element if the
	/// <paramref name="breakCondition"/> is not met.
	/// </summary>
	/// <typeparam name="T">The type of the elements of source.</typeparam>
	/// <param name="values">A sequence of values to invoke an action on.</param>
	/// <param name="predicate">The function to test each element for a condition.</param>
	/// <param name="breakCondition">The condition that breaks the iteration.</param>
	/// <param name="action">The action to invoke on each source element.</param>
	public static void ForEach<T>(this IEnumerable<T> values, Func<T, bool> predicate, Func<T, bool> breakCondition, Action<T> action)
	{
		foreach (T value in values.Where(predicate))
		{
			if (breakCondition(value))
				break;

			action(value);
		}
	}
}
