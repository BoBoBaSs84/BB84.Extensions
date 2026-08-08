// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Runtime.CompilerServices;

namespace BB84.Extensions.Common;

/// <summary>
/// Provides the shared implementation behind the per-type value predicates.
/// </summary>
/// <remarks>
/// The public extension classes (<see cref="ShortExtensions"/>, <see cref="IntegerExtensions"/>,
/// <see cref="LongExtensions"/>, <see cref="DecimalExtensions"/> and friends) forward to these
/// methods so the logic exists exactly once. The comparison based members rely on
/// <see cref="IComparable{T}"/> instead of generic math, because the package also targets
/// frameworks where <c>System.Numerics.INumber&lt;T&gt;</c> is not available.
/// <para>
/// Note that <see cref="IComparable{T}"/> orders <c>NaN</c> below zero, which does not match the
/// IEEE comparison operators. <see cref="FloatExtensions"/> and <see cref="DoubleExtensions"/>
/// therefore implement their sign predicates directly and only use the null and default members
/// from here.
/// </para>
/// </remarks>
internal static class NumericCore
{
	/// <summary>
	/// Determines whether the specified value is equal to the default value of its type.
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsDefault<T>(T value) where T : struct
		=> EqualityComparer<T>.Default.Equals(value, default);

	/// <summary>
	/// Determines whether the specified nullable value is equal to its default value (<see langword="null"/>).
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsDefault<T>(T? value) where T : struct
		=> !value.HasValue;

	/// <summary>
	/// Determines whether the specified value is not equal to the default value of its type.
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsNotDefault<T>(T value) where T : struct
		=> !EqualityComparer<T>.Default.Equals(value, default);

	/// <summary>
	/// Determines whether the specified nullable value is not equal to its default value (<see langword="null"/>).
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsNotDefault<T>(T? value) where T : struct
		=> value.HasValue;

	/// <summary>
	/// Determines whether the specified nullable value has no value.
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsNull<T>(T? value) where T : struct
		=> !value.HasValue;

	/// <summary>
	/// Determines whether the specified nullable value has a value.
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsNotNull<T>(T? value) where T : struct
		=> value.HasValue;

	/// <summary>
	/// Determines whether the specified value is greater than zero.
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsPositive<T>(T value) where T : struct, IComparable<T>
		=> value.CompareTo(default) > 0;

	/// <summary>
	/// Determines whether the specified nullable value has a value that is greater than zero.
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsPositive<T>(T? value) where T : struct, IComparable<T>
		=> value.HasValue && value.Value.CompareTo(default) > 0;

	/// <summary>
	/// Determines whether the specified value is less than zero.
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsNegative<T>(T value) where T : struct, IComparable<T>
		=> value.CompareTo(default) < 0;

	/// <summary>
	/// Determines whether the specified nullable value has a value that is less than zero.
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsNegative<T>(T? value) where T : struct, IComparable<T>
		=> value.HasValue && value.Value.CompareTo(default) < 0;

	/// <summary>
	/// Determines whether the specified value is greater than or equal to zero.
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsNonNegative<T>(T value) where T : struct, IComparable<T>
		=> value.CompareTo(default) >= 0;

	/// <summary>
	/// Determines whether the specified nullable value has a value that is greater than or equal to zero.
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsNonNegative<T>(T? value) where T : struct, IComparable<T>
		=> value.HasValue && value.Value.CompareTo(default) >= 0;

	/// <summary>
	/// Determines whether the specified value is less than or equal to zero.
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsNonPositive<T>(T value) where T : struct, IComparable<T>
		=> value.CompareTo(default) <= 0;

	/// <summary>
	/// Determines whether the specified nullable value has a value that is less than or equal to zero.
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsNonPositive<T>(T? value) where T : struct, IComparable<T>
		=> value.HasValue && value.Value.CompareTo(default) <= 0;
}
