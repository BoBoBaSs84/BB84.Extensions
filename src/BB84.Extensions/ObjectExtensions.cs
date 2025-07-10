// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Globalization;

namespace BB84.Extensions;

/// <summary>
/// Provides a set of extension methods for performing common operations on objects,
/// such as null checks and type conversions using invariant culture formatting.
/// </summary>
/// <remarks>
/// The <see cref="ObjectExtensions"/> class includes utility methods that simplify
/// working with objects in .NET. These methods are particularly useful for scenarios
/// where null checks or culture-invariant type conversions are required.
/// </remarks>
public static class ObjectExtensions
{
	/// <summary>
	/// Determines whether the specified nullable object has a null value.
	/// </summary>
	/// <param name="value">The nullable object to check.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNull([NotNullWhen(false)] this object? value)
		=> value is null;

	/// <summary>
	/// Converts the value of the specified object to an equivalent Boolean value, using the invariant
	/// culture formatting information.
	/// </summary>
	/// <param name="value">An object that implements the <see cref="IConvertible"/> interface, or null.</param>
	/// <returns>true or false, which reflects the value returned by invoking the 
	/// <see cref="IConvertible.ToBoolean(IFormatProvider)"/> method for the underlying type of value. 
	/// If value is null, the method returns false.</returns>
	public static bool ToBooleanInvariant(this object? value)
		=> Convert.ToBoolean(value, CultureInfo.InvariantCulture);

	/// <summary>
	/// Converts the value of the specified object to a <see cref="DateTime"/> object, using the
	/// invariant culture formatting information.
	/// </summary>
	/// <param name="value">An object that implements the <see cref="IConvertible"/> interface.</param>
	/// <returns>The date and time equivalent of the value of value, or the date and time equivalent
	/// of <see cref="DateTime.MinValue"/> if value is null.</returns>
	public static DateTime ToDateTimeInvariant(this object? value)
		=> Convert.ToDateTime(value, CultureInfo.InvariantCulture);

	/// <summary>
	/// Converts the value of the specified object to an equivalent decimal number, using the invariant
	/// culture formatting information.
	/// </summary>
	/// <param name="value">An object that implements the <see cref="IConvertible"/> interface.</param>
	/// <returns>A decimal number that is equivalent to value, or 0 (zero) if value is null.</returns>
	public static decimal ToDecimalInvariant(this object? value)
		=> Convert.ToDecimal(value, CultureInfo.InvariantCulture);

	/// <summary>
	/// Converts the value of the specified object to an double-precision floating-point number,
	/// using the invariant culture formatting information.
	/// </summary>
	/// <param name="value">An object that implements the <see cref="IConvertible"/> interface.</param>
	/// <returns>A double-precision floating-point number that is equivalent to value, or zero
	/// if value is null.</returns>
	public static double ToDoubleInvariant(this object? value)
		=> Convert.ToDouble(value, CultureInfo.InvariantCulture);

	/// <summary>
	/// Converts the value of the specified object to a 16-bit signed integer, using the invariant
	/// culture formatting information.
	/// </summary>
	/// <param name="value">An object that implements the <see cref="IConvertible"/> interface.</param>
	/// <returns>A 16-bit signed integer that is equivalent to value, or zero if value is null.</returns>
	public static short ToInt16Invariant(this object? value)
		=> Convert.ToInt16(value, CultureInfo.InvariantCulture);

	/// <summary>
	/// Converts the value of the specified object to a 32-bit signed integer, using the invariant
	/// culture formatting information.
	/// </summary>
	/// <param name="value">An object that implements the <see cref="IConvertible"/> interface.</param>
	/// <returns>A 32-bit signed integer that is equivalent to value, or zero if value is null.</returns>
	public static int ToInt32Invariant(this object? value)
		=> Convert.ToInt32(value, CultureInfo.InvariantCulture);

	/// <summary>
	/// Converts the value of the specified object to a 64-bit signed integer, using the invariant
	/// culture formatting information.
	/// </summary>
	/// <param name="value">An object that implements the <see cref="IConvertible"/> interface.</param>
	/// <returns>A 64-bit signed integer that is equivalent to value, or zero if value is null.</returns>
	public static long ToInt64Invariant(this object? value)
		=> Convert.ToInt64(value, CultureInfo.InvariantCulture);

	/// <summary>
	/// Converts the value of the specified object to its equivalent string representation using
	/// the invariant culture formatting information.
	/// </summary>
	/// <param name="value">An object that supplies the value to convert, or null.</param>
	/// <returns>The string representation of value, or <see cref="string.Empty"/> if value is an object
	/// whose value is null. If value is null, the method returns <see cref="string.Empty"/>.</returns>
	public static string ToStringInvariant(this object? value)
#if NET5_0_OR_GREATER
		=> Convert.ToString(value, CultureInfo.InvariantCulture) ?? string.Empty;
#else
		=> Convert.ToString(value, CultureInfo.InvariantCulture);
#endif
}
