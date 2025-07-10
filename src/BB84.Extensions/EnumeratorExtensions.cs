// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for working with enumeration types and value types.
/// </summary>
/// <remarks>
/// This static class includes utility methods for counting enumeration constants,
/// converting value types to integers, and retrieving all values of an enumeration type.
/// These methods are designed to simplify common operations on enums and value types
/// while ensuring type safety and ease of use.
/// </remarks>
public static class EnumeratorExtensions
{
	/// <summary>
	/// Counts the number of defined constants in the specified enumeration type.
	/// </summary>
	/// <typeparam name="T">The enumeration type to count the constants for.</typeparam>
	/// <param name="value">An instance of the enumeration type.</param>
	/// <returns>The total number of constants defined in the enumeration type.</returns>
	public static int Count<T>(this T value) where T : struct, IComparable, IFormattable, IConvertible
		=> Enum.GetValues(value.GetType()).Length;

	/// <summary>
	/// Converts the specified value of a value type to its equivalent integer representation.
	/// </summary>
	/// <remarks>This method uses a boxed conversion to cast the value to an integer.</remarks>
	/// <typeparam name="T">The value type to convert.</typeparam>
	/// <param name="value">The value to convert to an integer.</param>
	/// <returns>The integer representation of the specified value.</returns>
	public static int GetInt<T>(this T value) where T : struct, IComparable, IFormattable, IConvertible
		=> (int)(object)value;

	/// <summary>
	/// Retrieves all values of the specified enumeration type.
	/// </summary>
	/// <remarks>
	/// This method provides a strongly-typed way to retrieve all values of an enumeration.
	/// The generic type parameter <typeparamref name="T"/> must be an enumeration type,
	/// and the method will throw a runtime exception if used with a non-enum type.
	/// </remarks>
	/// <typeparam name="T">The enumeration type.</typeparam>
	/// <param name="value">An instance of the enumeration type.</param>
	/// <returns>
	/// An <see cref="IEnumerable{T}"/> containing all values of the specified enumeration type.
	/// </returns>
	public static IEnumerable<T> GetValues<T>(this T value) where T : struct, IComparable, IFormattable, IConvertible
		=> Enum.GetValues(value.GetType()).OfType<T>().ToArray();
}
