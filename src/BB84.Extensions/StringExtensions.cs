// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Globalization;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace BB84.Extensions;

/// <summary>
/// Provides a set of extension methods for working with strings, including compression,
/// encoding, formatting, and validation.
/// </summary>
/// <remarks>This <see cref="StringExtensions"/> class includes utility methods for common string
/// operations such as compressing and decompressing strings, encoding and decoding Base64 strings,
/// formatting strings with culture-specific options, and checking for null or empty values. It also
/// provides methods for removing unwanted whitespace or line breaks, and generating MD5 hashes for
/// strings.
/// </remarks>
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
	/// Compresses the specified string using the provided compression level and returns the result
	/// as a Base64-encoded string.
	/// </summary>
	/// <remarks>
	/// This method compresses the input string into a byte array, applies the specified compression level,
	/// and encodes the compressed data as a Base64 string for safe storage or transmission.
	/// </remarks>
	/// <param name="value">The string to compress.</param>
	/// <param name="compressionLevel">The level of compression to apply.</param>
	/// <returns>A Base64-encoded string representing the compressed data.</returns>
	public static string Compress(this string value, CompressionLevel compressionLevel = CompressionLevel.Optimal)
	{
		byte[] inputBuffer = value.GetBytes();
		byte[] outputBuffer = inputBuffer.Compress(compressionLevel);
		return Convert.ToBase64String(outputBuffer);
	}

	/// <summary>
	/// Decompresses a Base64-encoded, compressed string and returns the resulting decompressed string.
	/// </summary>
	/// <remarks>This method assumes the input string is Base64-encoded and represents compressed data.
	/// The decompression process involves decoding the Base64 string into a byte array, decompressing
	/// the byte array and converting the resulting byte array back into a string.
	/// </remarks>
	/// <param name="value">A Base64-encoded string representing compressed data.</param>
	/// <returns>
	/// The decompressed string obtained from the input. If the input is invalid or cannot be decompressed,
	/// an exception may be thrown.
	/// </returns>
	public static string Decompress(this string value)
	{
		byte[] inputBuffer = Convert.FromBase64String(value);
		byte[] outputBuffer = inputBuffer.Decompress();
		return outputBuffer.GetString();
	}

	/// <summary>
	/// Encrypts the specified text using AES encryption with a key derived from the provided key string.
	/// </summary>
	/// <param name="value">The text to encrypt.</param>
	/// <param name="key">The key used for encryption. It is hashed to derive a suitable AES key.</param>
	/// <returns>The encrypted text, encoded as a Base64 string.</returns>
	public static string Encrypt(this string value, string key)
	{
		byte[] buffer = Encoding.UTF8.GetBytes(value);
		byte[] aesKey = new byte[24];

#if NET8_0_OR_GREATER
		Buffer.BlockCopy(SHA512.HashData(Encoding.UTF8.GetBytes(key)), 0, aesKey, 0, 24);
#else
		SHA512 hash = SHA512.Create();
		Buffer.BlockCopy(hash.ComputeHash(Encoding.UTF8.GetBytes(key)), 0, aesKey, 0, 24);
#endif

		using Aes aes = Aes.Create();
		aes.Key = aesKey;

		using ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
		using MemoryStream resultStream = new();
		using (CryptoStream aesStream = new(resultStream, encryptor, CryptoStreamMode.Write))
		using (MemoryStream plainStream = new(buffer))
		{
			plainStream.CopyTo(aesStream);
		}

		byte[] result = resultStream.ToArray();
		byte[] combined = new byte[aes.IV.Length + result.Length];
		Array.ConstrainedCopy(aes.IV, 0, combined, 0, aes.IV.Length);
		Array.ConstrainedCopy(result, 0, combined, aes.IV.Length, result.Length);

		return combined.ToBase64();
	}

	/// <summary>
	/// Decrypts the specified encrypted text using AES decryption with a key derived from the provided key string.
	/// </summary>
	/// <param name="encryptedValue">The encrypted text to decrypt, encoded as a Base64 string.</param>
	/// <param name="key">The key used for decryption. It is hashed to derive a suitable AES key.</param>
	/// <returns>The decrypted text.</returns>
	public static string Decrypt(this string encryptedValue, string key)
	{
		byte[] combined = encryptedValue.FromBase64();
		byte[] buffer = new byte[combined.Length];
		byte[] aesKey = new byte[24];

#if NET8_0_OR_GREATER
		Buffer.BlockCopy(SHA512.HashData(Encoding.UTF8.GetBytes(key)), 0, aesKey, 0, 24);
#else
		SHA512 hash = SHA512.Create();
		Buffer.BlockCopy(hash.ComputeHash(Encoding.UTF8.GetBytes(key)), 0, aesKey, 0, 24);
#endif
		using Aes aes = Aes.Create();
		aes.Key = aesKey;

		byte[] iv = new byte[aes.IV.Length];
		byte[] ciphertext = new byte[buffer.Length - iv.Length];

		Array.ConstrainedCopy(combined, 0, iv, 0, iv.Length);
		Array.ConstrainedCopy(combined, iv.Length, ciphertext, 0, ciphertext.Length);

		aes.IV = iv;

		using ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
		using MemoryStream resultStream = new();
		using (CryptoStream aesStream = new(resultStream, decryptor, CryptoStreamMode.Write))
		using (MemoryStream plainStream = new(ciphertext))
		{
			plainStream.CopyTo(aesStream);
		}

		return resultStream.ToArray().GetString();
	}

	/// <summary>
	/// Determines whether the specified string is equal to the current string, using a case-sensitive
	/// comparison.
	/// </summary>
	/// <param name="value">The string to compare against <paramref name="comparisonValue"/>.</param>
	/// <param name="comparisonValue">The string to compare to <paramref name="value"/>.</param>
	/// <returns>
	/// <see langword="true"/> if the two strings are equal using a case-sensitive, ordinal comparison;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool EqualsCaseSensitive(this string value, string comparisonValue)
		=> value.Equals(comparisonValue, StringComparison.Ordinal);

	/// <summary>
	/// Determines whether two strings are equal, ignoring case.
	/// </summary>
	/// <param name="value">The string to compare against <paramref name="comparisonValue"/>.</param>
	/// <param name="comparisonValue">The string to compare to <paramref name="value"/>.</param>
	/// <returns>
	/// <see langword="true"/> if the two strings are equal ignoring case, ordinal comparison;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool EqualsIgnoreCase(this string value, string comparisonValue)
		=> value.Equals(comparisonValue, StringComparison.OrdinalIgnoreCase);

	/// <summary>
	/// Formats the specified string using the provided parameters, with formatting rules based on the
	/// invariant culture.
	/// </summary>
	/// <remarks>
	/// This method uses <see cref="CultureInfo.InvariantCulture"/> to ensure consistent formatting
	/// regardless of the current culture.
	/// </remarks>
	/// <param name="value">The composite format string to format.</param>
	/// <param name="parameters">
	/// An array of objects to format. These objects are inserted into the format string.
	/// </param>
	/// <returns>
	/// A formatted string where placeholders in <paramref name="value"/> are replaced with the string
	/// representations of the corresponding objects in <paramref name="parameters"/>.
	/// </returns>
	public static string FormatInvariant(this string value, params object[] parameters)
			=> string.Format(CultureInfo.InvariantCulture, value, parameters);

	/// <summary>
	/// Formats the specified string using the provided format provider and parameters.
	/// </summary>
	/// <remarks>
	/// This method is an extension method for the <see cref="string"/> class. It simplifies the use of
	/// <see cref="string.Format(IFormatProvider, string, object[])"/> by allowing the format string to
	/// be called directly on the string instance.
	/// </remarks>
	/// <param name="value">The composite format string to format.</param>
	/// <param name="formatProvider">An object that provides culture-specific formatting information.</param>
	/// <param name="parameters">An array of objects to format and include in the resulting string.</param>
	/// <returns>
	/// A formatted string where placeholders in <paramref name="value"/> are replaced by the corresponding
	/// values in <paramref name="parameters"/>.
	/// </returns>
	public static string Format(this string value, IFormatProvider formatProvider, params object[] parameters)
			=> string.Format(formatProvider, value, parameters);

	/// <summary>
	/// Decodes a Base64-encoded string into its original representation using the specified character encoding.
	/// </summary>
	/// <remarks>
	/// This method extends the <see cref="string"/> type to provide a convenient way to decode Base64-encoded
	/// strings into their original form using a specified encoding. The input string must be a valid
	/// Base64-encoded string.
	/// </remarks>
	/// <param name="value">The Base64-encoded string to decode.</param>
	/// <param name="encoding">The character encoding to use for decoding the byte array into a string.</param>
	/// <returns>The decoded string represented in the specified encoding.</returns>
	public static string FromBase64(this string value, Encoding encoding)
	{
		byte[] buffer = value.FromBase64();
		return encoding.GetString(buffer);
	}

	/// <summary>
	/// Converts the specified string to a byte array using the provided encoding.
	/// </summary>
	/// <remarks>
	/// If the <paramref name="encoding"/> parameter is <see langword="null"/>, the method defaults to
	/// using <see cref="Encoding.UTF8"/>.
	/// </remarks>
	/// <param name="value">The string to convert to a byte array.</param>
	/// <param name="encoding">The character encoding to use for the conversion.</param>
	/// <returns>A byte array representing the encoded string.</returns>
	public static byte[] GetBytes(this string value, Encoding? encoding = null)
	{
		encoding ??= Encoding.UTF8;
		return encoding.GetBytes(value);
	}

	/// <summary>
	/// Computes the MD5 hash of the specified string using UTF-8 encoding.
	/// </summary>
	/// <remarks>
	/// This method uses UTF-8 encoding to convert the input string into bytes before computing the MD5
	/// hash. The resulting hash is returned as a hexadecimal string.
	/// </remarks>
	/// <param name="value">The input string to compute the MD5 hash for.</param>
	/// <returns>A hexadecimal string representation of the MD5 hash of the input string.</returns>
	public static string GetMd5Utf8(this string value)
		=> GetMd5Bytes(value, Encoding.UTF8).GetHexString();

	/// <summary>
	/// Computes the MD5 hash of the specified string using ASCII encoding.
	/// </summary>
	/// <remarks>
	/// This method uses ASCII encoding to convert the input string into bytes before computing the MD5
	/// hash. The resulting hash is returned as a hexadecimal string.
	/// </remarks>
	/// <param name="value">The input string to compute the MD5 hash for.</param>
	/// <returns>A hexadecimal string representation of the MD5 hash of the input string.</returns>
	public static string GetMd5Ascii(this string value)
		=> GetMd5Bytes(value, Encoding.ASCII).GetHexString();

	/// <summary>
	/// Computes the MD5 hash of the specified string using Unicode encoding.
	/// </summary>
	/// <remarks>
	/// This method uses Unicode encoding to convert the input string into bytes before computing the MD5
	/// hash. The resulting hash is returned as a hexadecimal string.
	/// </remarks>
	/// <param name="value">The input string to compute the MD5 hash for.</param>
	/// <returns>A hexadecimal string representation of the MD5 hash of the input string.</returns>
	public static string GetMd5Unicode(this string value)
		=> GetMd5Bytes(value, Encoding.Unicode).GetHexString();

	/// <summary>
	/// Determines whether the specified nullable string has a null value.
	/// </summary>
	/// <param name="value">The nullable string to check.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNull([NotNullWhen(false)] this string? value)
		=> value is null;

	/// <summary>
	/// Determines whether the specified nullable string has a non-null value.
	/// </summary>
	/// <param name="value">The nullable string to check.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is not <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotNull([NotNullWhen(true)] this string? value)
		=> value is not null;

	/// <summary>
	/// Determines whether the specified nullable string has a null value or is empty.
	/// </summary>
	/// <param name="value">The nullable string to check.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is <see langword="null"/> or empty;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value)
		=> string.IsNullOrEmpty(value);

	/// <summary>
	/// Determines whether the specified nullable string has a non-null value or is not empty.
	/// </summary>
	/// <param name="value">The nullable string to check.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is not <see langword="null"/> and not empty;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotNullOrEmpty([NotNullWhen(true)] this string? value)
		=> string.IsNullOrEmpty(value).Equals(false);

	/// <summary>
	/// Determines whether the specified string is null, empty or consists only of white-space characters.
	/// </summary>
	/// <param name="value">The nullable string to check.</param>
	/// <returns>
	/// <see langword="true"/> if the string is null, empty or consists only of white-space characters;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value)
		=> string.IsNullOrWhiteSpace(value);

	/// <summary>
	/// Determines whether the specified string is not null, not empty or does not consists only of
	/// white-space characters.
	/// </summary>
	/// <param name="value">The nullable string to check.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is not <see langword="null"/>, not empty
	/// and does not consists only of white-space characters; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotNullOrWhiteSpace([NotNullWhen(true)] this string? value)
		=> string.IsNullOrWhiteSpace(value).Equals(false);

	/// <summary>
	/// Removes all linebreaks from the specified string.
	/// </summary>
	/// <param name="value">
	/// The input string from which linebreaks will be removed.</param>
	/// <returns>
	/// A new string with all linebreaks removed. If the input string is empty, an empty string is returned.
	/// </returns>
	public static string RemoveLinebreak(this string value)
		=> LinebreakRegex.Replace(value, string.Empty);

	/// <summary>
	/// Removes all whitespaces from the specified string.
	/// </summary>
	/// <param name="value">
	/// The input string from which whitespaces will be removed.</param>
	/// <returns>
	/// A new string with all whitespaces removed. If the input string is empty, an empty string is returned.
	/// </returns>
	public static string RemoveWhitespace(this string value)
		=> WhitespaceRegex.Replace(value, string.Empty);

	/// <summary>
	/// Converts the specified string to its Base64-encoded representation using the specified encoding.
	/// </summary>
	/// <remarks>
	/// If the <paramref name="value"/> is null or consists only of whitespace, an empty string is returned.
	/// </remarks>
	/// <param name="value">The string to encode.</param>
	/// <param name="encoding">The character encoding to use for converting the string to bytes.</param>
	/// <returns>
	/// A Base64-encoded string representation of the input string, or an empty string if <paramref name="value"/>
	/// is null or whitespace.
	/// </returns>
	public static string ToBase64(this string value, Encoding encoding)
	{
		if (value.IsNullOrWhiteSpace())
			return string.Empty;

		byte[] buffer = encoding.GetBytes(value);
		return buffer.ToBase64();
	}

	/// <summary>
	/// Converts an enumerable collection of strings into a single string, with each element separated
	/// </summary>
	/// <param name="values">The collection of strings to join.</param>
	/// <param name="separator">The string to use as a separator between each element.</param>
	/// <returns>The concatenated string with elements separated by the specified separator.</returns>
	public static string Join(this IEnumerable<string> values, string separator)
		=> string.Join(separator, values);

	private static byte[] GetMd5Bytes(string stringValue, Encoding encoding)
		=> encoding.GetBytes(stringValue).GetMD5();
}
