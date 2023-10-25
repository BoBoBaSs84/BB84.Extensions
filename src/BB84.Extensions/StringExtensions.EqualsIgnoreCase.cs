﻿namespace BB84.Extensions;

public static partial class StringExtensions
{
	/// <summary>
	/// Determines whether this string and a specified <see cref="string"/> object have the same value.
	/// </summary>
	/// <param name="stringValue">The input string to work with.</param>
	/// <param name="otherValue">The string to compare</param>
	/// <returns>true if the value of the value parameter is the same as this string; otherwise false.</returns>
	public static bool EqualsIgnoreCase(this string stringValue, string otherValue)
		=> stringValue.Equals(otherValue, StringComparison.OrdinalIgnoreCase);
}
