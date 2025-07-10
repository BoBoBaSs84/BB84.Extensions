// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Globalization;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;

namespace BB84.Extensions;

/// <summary>
/// The string extensions class.
/// </summary>
public static partial class StringExtensions
{
#if NET6_0_OR_GREATER
	private static readonly Regex WhitespaceRegex = GeneratedWhitespaceRegex();
	private static readonly Regex LinebreakRegex = GeneratedLinebreakRegex();

	[GeneratedRegex(@"\s+", RegexOptions.None)]
	private static partial Regex GeneratedWhitespaceRegex();

	[GeneratedRegex(@"(\r\n|\r|\n)", RegexOptions.None)]
	private static partial Regex GeneratedLinebreakRegex();
#else
	private static readonly Regex WhitespaceRegex = new(@"\s+", RegexOptions.None);
	private static readonly Regex LinebreakRegex = new(@"(\r\n|\r|\n)", RegexOptions.None);
#endif

	/// <summary>
	/// Compresses a string and returns a deflate compressed, Base64 encoded string.
	/// </summary>
	/// <param name="stringValue">The input string value to compress.</param>
	/// <param name="compressionLevel">The compression level to use.</param>
	/// <returns>The compressed base64 encoded string.</returns>
	public static string Compress(this string stringValue, CompressionLevel compressionLevel = CompressionLevel.Optimal)
	{
		byte[] inputBuffer = stringValue.GetBytes();
		byte[] outputBuffer = inputBuffer.Compress(compressionLevel);
		return Convert.ToBase64String(outputBuffer);
	}

	/// <summary>
	/// Decompresses a deflate compressed, Base64 encoded string and returns an uncompressed string.
	/// </summary>
	/// <param name="stringValue">The input string value to decompress.</param>
	/// <returns></returns>
	public static string Decompress(this string stringValue)
	{
		byte[] inputBuffer = Convert.FromBase64String(stringValue);
		byte[] outputBuffer = inputBuffer.Decompress();
		return outputBuffer.GetString();
	}

	/// <summary>
	/// Determines whether this string and a specified <see cref="string"/> object have the same value.
	/// </summary>
	/// <param name="stringValue">The input string to work with.</param>
	/// <param name="otherValue">The string to compare.</param>
	/// <returns>true if the value of the value parameter is the same as this string; otherwise false.</returns>
	public static bool EqualsCaseSensitive(this string stringValue, string otherValue)
		=> stringValue.Equals(otherValue, StringComparison.Ordinal);

	/// <summary>
	/// Determines whether this string and a specified <see cref="string"/> object have the same value.
	/// </summary>
	/// <param name="stringValue">The input string to work with.</param>
	/// <param name="otherValue">The string to compare</param>
	/// <returns>true if the value of the value parameter is the same as this string; otherwise false.</returns>
	public static bool EqualsIgnoreCase(this string stringValue, string otherValue)
		=> stringValue.Equals(otherValue, StringComparison.OrdinalIgnoreCase);

	/// <summary>
	/// Formats the string with <paramref name="parameters"/> to an invariant culture.
	/// </summary>
	/// <param name="stringValue">The string with placeholders.</param>
	/// <param name="parameters">The parameters to set for the placeholders.</param>
	/// <returns>The formated string.</returns>
	public static string FormatInvariant(this string stringValue, params object[] parameters)
			=> string.Format(CultureInfo.InvariantCulture, stringValue, parameters);

	/// <summary>
	/// Formats the string with <paramref name="parameters"/> to an provided culture.
	/// </summary>
	/// <param name="stringValue">The string with placeholders.</param>
	/// <param name="formatProvider">The format provider to use.</param>
	/// <param name="parameters">The parameters to set for the placeholders.</param>
	/// <returns>The formated string.</returns>
	public static string Format(this string stringValue, IFormatProvider formatProvider, params object[] parameters)
			=> string.Format(formatProvider, stringValue, parameters);

	/// <summary>
	/// Decodes the provided string from a base64 string.
	/// </summary>
	/// <param name="value">The input string to work with.</param>
	/// <param name="encoding">The encoding to use.</param>
	/// <returns>The decoded string.</returns>
	/// <exception cref="ArgumentException">The provided string is not a valid base64 string.</exception>
	public static string FromBase64(this string value, Encoding encoding)
	{
		byte[] buffer = value.FromBase64();
		return encoding.GetString(buffer);
	}

	/// <summary>
	/// Returns all the characters in the specified string encoded into a sequence of bytes.
	/// </summary>
	/// <remarks>
	/// If <paramref name="encoding"/> is not provided, <see cref="Encoding.UTF8"/> is used.
	/// </remarks>
	/// <param name="stringValue">The string value containing the characters to encode.</param>
	/// <param name="encoding">The character encoding to use.</param>
	/// <returns>A byte array containing the results of encoding the specified set of characters.</returns>
	public static byte[] GetBytes(this string stringValue, Encoding? encoding = null)
	{
		encoding ??= Encoding.UTF8;
		return encoding.GetBytes(stringValue);
	}

	/// <summary>
	/// Gets a string with the MD5 hash value of a given string (UT8 Encoded)
	/// </summary>
	/// <param name="stringValue">The input string to work with.</param>
	/// <returns>The MD5 hashed string.</returns>
	public static string GetMd5Utf8(this string stringValue)
		=> GetMd5Bytes(stringValue, Encoding.UTF8).GetHexString();

	/// <summary>
	/// Gets a string with the MD5 hash value of a given string (ASCII Encoded)
	/// </summary>
	/// <param name="stringValue">The input string to work with.</param>
	/// <returns>The MD5 hashed string.</returns>
	public static string GetMd5Ascii(this string stringValue)
		=> GetMd5Bytes(stringValue, Encoding.ASCII).GetHexString();

	/// <summary>
	/// Gets a string with the MD5 hash value of a given string (Unicode Encoded)
	/// </summary>
	/// <param name="stringValue">The input string to work with.</param>
	/// <returns>The MD5 hashed string.</returns>
	public static string GetMd5Unicode(this string stringValue)
		=> GetMd5Bytes(stringValue, Encoding.Unicode).GetHexString();

	/// <summary>
	/// Indicates whether the specified string value is <see langword="null"/> or not.
	/// </summary>
	/// <param name="value">The string value to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is <see langword="null"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNull([NotNullWhen(false)] this string? value)
		=> value is null;

	/// <summary>
	/// Indicates whether the specified string value is <see langword="null"/> or an <see cref="string.Empty"/>.
	/// </summary>
	/// <param name="value">The string value to test.</param>
	/// <returns>True if the value parameter is null or an empty string, otherwise false.</returns>
	public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value)
		=> string.IsNullOrEmpty(value);

	/// <summary>
	/// Indicates whether a specified string is null, empty, or consists only of white-space characters.
	/// </summary>
	/// <param name="value">The string value to test.</param>
	/// <returns>True if the value parameter is null or an empty string or if value consists
	/// exclusively of white-space characters, otherwise false.</returns>
	public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value)
		=> string.IsNullOrWhiteSpace(value);

	/// <summary>
	/// Removes unwanted linebreaks within the provided string value.
	/// </summary>
	/// <param name="value">The input string value to modify.</param>
	/// <returns>The same <see cref="string"/> instance so that multiple calls can be chained.</returns>
	public static string RemoveLinebreak(this string value)
		=> LinebreakRegex.Replace(value, string.Empty);

	/// <summary>
	/// Removes unwanted whitespace within the provided string value.
	/// </summary>
	/// <param name="stringValue">The input string value to modify.</param>
	/// <returns>The same <see cref="string"/> instance so that multiple calls can be chained.</returns>
	public static string RemoveWhitespace(this string stringValue)
		=> WhitespaceRegex.Replace(stringValue, string.Empty);

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

	private static byte[] GetMd5Bytes(string stringValue, Encoding encoding)
		=> encoding.GetBytes(stringValue).GetMD5();
}
