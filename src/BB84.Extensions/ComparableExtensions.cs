// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

/// <summary>
/// The comparable extensions class.
/// </summary>
public static class ComparableExtensions
{
	/// <summary>
	/// Check if a value is greater or equal than another value.
	/// </summary>
	/// <typeparam name="T">The type that implements <see cref="IComparable"/>.</typeparam>
	/// <param name="value">The value to compare.</param>
	/// <param name="comparativeValue">The value to compare with.</param>
	/// <returns>True if the value is greater or equal than the othe value, otherwise false.</returns>
	public static bool IsGreaterOrEqualThan<T>(this T value, T comparativeValue) where T : IComparable
		=> value.CompareTo(comparativeValue) >= 0;

	/// <summary>
	/// Check if a value is greater than another value.
	/// </summary>
	/// <typeparam name="T">The type that implements <see cref="IComparable"/>.</typeparam>
	/// <param name="value">The value to compare.</param>
	/// <param name="comparativeValue">The value to compare with.</param>
	/// <returns>True if the value is greater than the othe value, otherwise false.</returns>
	public static bool IsGreaterThan<T>(this T value, T comparativeValue) where T : IComparable
		=> value.CompareTo(comparativeValue) > 0;

	/// <summary>
	/// Check if a value is less or equal than another value.
	/// </summary>
	/// <typeparam name="T">The type that implements <see cref="IComparable"/>.</typeparam>
	/// <param name="value">The value to compare.</param>
	/// <param name="comparativeValue">The value to compare with.</param>
	/// <returns>True if the value is less or equal than the othe value, otherwise false.</returns>
	public static bool IsLessOrEqualThan<T>(this T value, T comparativeValue) where T : IComparable
		=> value.CompareTo(comparativeValue) <= 0;

	/// <summary>
	/// Check if a value is less than another value.
	/// </summary>
	/// <typeparam name="T">The type that implements <see cref="IComparable"/>.</typeparam>
	/// <param name="value">The value to compare.</param>
	/// <param name="comparativeValue">The value to compare with.</param>
	/// <returns>True if the value is lesser than the othe value, otherwise false.</returns>
	public static bool IsLessThan<T>(this T value, T comparativeValue) where T : IComparable
		=> value.CompareTo(comparativeValue) < 0;
}
