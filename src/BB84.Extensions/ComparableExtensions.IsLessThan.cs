﻿namespace BB84.Extensions;

public static partial class ComparableExtensions
{
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
