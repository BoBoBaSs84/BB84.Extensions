// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for comparing values that implement the <see cref="IComparable"/> interface.
/// </summary>
/// <remarks>
/// This class includes methods for performing common comparison operations, such as checking if a value
/// is greater than, less than, or equal to another value. These methods are implemented as extension
/// methods to enhance readability and simplify comparison logic in code.
/// </remarks>
public static class ComparableExtensions
{
	/// <summary>
	/// Determines whether the current value is greater than or equal to the specified comparative value.
	/// </summary>
	/// <remarks>
	/// This method uses the <see cref="IComparable.CompareTo"/> method to perform the comparison.
	/// </remarks>
	/// <typeparam name="T">The type of the values being compared.</typeparam>
	/// <param name="value">The value to compare.</param>
	/// <param name="comparativeValue">The value to compare against.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is greater than or equal to <paramref name="comparativeValue"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsGreaterOrEqualThan<T>(this T value, T comparativeValue) where T : IComparable
		=> value.CompareTo(comparativeValue) >= 0;

	/// <summary>
	/// Determines whether the current value is greater than the specified comparative value.
	/// </summary>
	/// <remarks>
	/// This method uses the <see cref="IComparable.CompareTo"/> method to perform the comparison.
	/// </remarks>
	/// <typeparam name="T">The type of the values being compared.</typeparam>
	/// <param name="value">The value to compare.</param>
	/// <param name="comparativeValue">The value to compare against.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is greater than the <paramref name="comparativeValue"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsGreaterThan<T>(this T value, T comparativeValue) where T : IComparable
		=> value.CompareTo(comparativeValue) > 0;

	/// <summary>
	/// Determines whether the current value is less than or equal to the specified comparative value.
	/// </summary>
	/// <remarks>
	/// This method uses the <see cref="IComparable.CompareTo"/> method to perform the comparison.
	/// </remarks>
	/// <typeparam name="T">The type of the values being compared.</typeparam>
	/// <param name="value">The value to compare.</param>
	/// <param name="comparativeValue">The value to compare against.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is less than or equal to <paramref name="comparativeValue"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsLessOrEqualThan<T>(this T value, T comparativeValue) where T : IComparable
		=> value.CompareTo(comparativeValue) <= 0;

	/// <summary>
	/// Determines whether the current value is less than the specified comparative value.
	/// </summary>
	/// <remarks>
	/// This method uses the <see cref="IComparable.CompareTo"/> method to perform the comparison.
	/// </remarks>
	/// <typeparam name="T">The type of the values being compared.</typeparam>
	/// <param name="value">The value to compare.</param>
	/// <param name="comparativeValue">The value to compare against.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is less than the <paramref name="comparativeValue"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsLessThan<T>(this T value, T comparativeValue) where T : IComparable
		=> value.CompareTo(comparativeValue) < 0;
}
