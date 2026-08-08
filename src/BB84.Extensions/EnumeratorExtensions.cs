// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Globalization;

namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for working with enumeration types.
/// </summary>
/// <remarks>
/// This static class includes utility methods for counting enumeration constants,
/// converting enumeration values to integers, and retrieving all values of an enumeration type.
/// The <see cref="Enum"/> constraint keeps non-enum types out at compile time instead of letting
/// them fail at runtime.
/// </remarks>
public static class EnumeratorExtensions
{
	/// <summary>
	/// Counts the number of defined constants in the specified enumeration type.
	/// </summary>
	/// <typeparam name="T">The enumeration type to count the constants for.</typeparam>
	/// <param name="value">An instance of the enumeration type.</param>
	/// <returns>The total number of constants defined in the enumeration type.</returns>
	public static int Count<T>(this T value) where T : struct, Enum
#if NET5_0_OR_GREATER
		=> Enum.GetValues<T>().Length;
#else
		=> Enum.GetValues(typeof(T)).Length;
#endif

	/// <summary>
	/// Converts the specified enumeration value to its equivalent integer representation.
	/// </summary>
	/// <remarks>
	/// The conversion goes through <see cref="Convert.ToInt32(object, IFormatProvider)"/>, so it also
	/// works for enumerations whose underlying type is not <see cref="int"/>.
	/// </remarks>
	/// <typeparam name="T">The enumeration type to convert.</typeparam>
	/// <param name="value">The value to convert to an integer.</param>
	/// <returns>The integer representation of the specified value.</returns>
	/// <exception cref="OverflowException">
	/// Thrown if the value does not fit into an <see cref="int"/>.
	/// </exception>
	public static int GetInt<T>(this T value) where T : struct, Enum
		=> Convert.ToInt32(value, CultureInfo.InvariantCulture);

	/// <summary>
	/// Retrieves all values of the specified enumeration type.
	/// </summary>
	/// <typeparam name="T">The enumeration type.</typeparam>
	/// <param name="value">An instance of the enumeration type.</param>
	/// <returns>
	/// An <see cref="IEnumerable{T}"/> containing all values of the specified enumeration type.
	/// </returns>
	public static IEnumerable<T> GetValues<T>(this T value) where T : struct, Enum
#if NET5_0_OR_GREATER
		=> Enum.GetValues<T>();
#else
		=> (T[])Enum.GetValues(typeof(T));
#endif
}
