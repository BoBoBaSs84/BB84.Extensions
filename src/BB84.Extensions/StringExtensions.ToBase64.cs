﻿using System.Text;

namespace BB84.Extensions;

public static partial class StringExtensions
{
	/// <summary>
	/// Encodes the provided string to a base64 string.
	/// </summary>
	/// <param name="stringValue">The input string to work with.</param>
	/// <param name="encoding">The encoding to use.</param>
	/// <returns>The encoded string.</returns>
	public static string ToBase64(this string stringValue, Encoding encoding)
	{
		if (stringValue.IsNullOrWhiteSpace())
			return string.Empty;

		byte[] buffer = encoding.GetBytes(stringValue);
		return buffer.ToBase64();
	}
}
