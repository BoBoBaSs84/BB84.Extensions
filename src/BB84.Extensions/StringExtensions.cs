using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace BB84.Extensions;

/// <summary>
/// The string extensions class.
/// </summary>
public static class StringExtensions
{
	private static readonly Regex Base64 = new(@"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);

	/// <summary>
	/// Encodes the provided string to a base64 string.
	/// </summary>
	/// <param name="stringValue">The input string to work with.</param>
	/// <param name="encoding">The encoding to use.</param>
	/// <returns>The encoded string.</returns>
	public static string ToBase64(this string stringValue, Encoding? encoding = null)
	{
		if (stringValue.IsNullOrWhiteSpace())
			return string.Empty;

		encoding ??= Encoding.Default;
		byte[] buffer = encoding.GetBytes(stringValue);
		return Convert.ToBase64String(buffer);
	}

	/// <summary>
	/// Decodes the provided string from a base64 string.
	/// </summary>
	/// <param name="stringValue">The input string to work with.</param>
	/// <param name="encoding">The encoding to use.</param>
	/// <returns>The decoded string.</returns>
	/// <exception cref="ArgumentException">The provided string is not a valid base64 string.</exception>
	public static string FromBase64(this string stringValue, Encoding? encoding = null)
	{
		if (stringValue.IsNullOrEmpty())
			return string.Empty;

		// Check for valid base64
		stringValue = stringValue.Trim();
		bool isValidBase64 = (stringValue.Length % 4 == 0) && Base64.IsMatch(stringValue);

		if (isValidBase64.Equals(false))
			throw new ArgumentException($"{stringValue} is not valid base64");

		byte[] buffer = Convert.FromBase64String(stringValue);
		encoding ??= Encoding.Default;
		return encoding.GetString(buffer);
	}

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
	/// Indicates whether the specified string is null.
	/// </summary>
	/// <param name="stringValue">The string value to test.</param>
	/// <returns>True if the value parameter is null, otherwise false.</returns>
	public static bool IsNull(this string stringValue)
		=> stringValue is null;

	/// <summary>
	/// Indicates whether the specified string is null or an <see cref="string.Empty"/> string.
	/// </summary>
	/// <param name="stringValue">The string value to test.</param>
	/// <returns>True if the value parameter is null or an empty string, otherwise false.</returns>
	public static bool IsNullOrEmpty(this string stringValue)
		=> string.IsNullOrEmpty(stringValue);

	/// <summary>
	/// Indicates whether a specified string is null, empty, or consists only of white-space
	/// characters.
	/// </summary>
	/// <param name="stringValue">The string value to test.</param>
	/// <returns>True if the value parameter is null or an empty string or if value consists
	/// exclusively of white-space characters, otherwise false.</returns>
	public static bool IsNullOrWhiteSpace(this string stringValue)
		=> string.IsNullOrWhiteSpace(stringValue);

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

	[SuppressMessage("Security", "CA5351", Justification = "Not used for cryptography.")]
	private static byte[] GetMd5Bytes(string stringValue, Encoding encoding)
	{
#if NET6_0_OR_GREATER
		return MD5.HashData(encoding.GetBytes(stringValue));
#else
		return MD5.Create().ComputeHash(encoding.GetBytes(stringValue));
#endif
	}
}
