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
/// Provides a set of extension methods for working with <see cref="byte"/> arrays, including
/// compression, decompression, encoding,hashing, and utility methods.
/// </summary>
/// <remarks>
/// This class includes methods for common operations on byte arrays, such as converting to and
/// from Base64, generating MD5 hashes, and encoding/decoding strings. It also provides utility
/// methods for checking nullability and obtaining hexadecimal representations of byte arrays.
/// </remarks>
public static partial class ByteExtensions
{
#if NET7_0_OR_GREATER
	private static readonly Regex Base64Regex = GeneratedBase64Regex();

	[GeneratedRegex(@"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None)]
	private static partial Regex GeneratedBase64Regex();
#else
	private static readonly Regex Base64Regex = new(@"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
#endif

	/// <summary>
	/// Compresses the specified byte array using the Deflate algorithm.
	/// </summary>
	/// <remarks>
	/// This method uses the <see cref="DeflateStream"/> class to perform compression. The caller is
	/// responsible for ensuring that the input data is suitable for compression and for handling the
	/// compressed output appropriately.
	/// </remarks>
	/// <param name="inputBuffer">The byte array to compress.</param>
	/// <param name="compressionLevel">The level of compression to apply.</param>
	/// <returns>
	/// A byte array containing the compressed data. The returned array will be empty if the input array is empty.
	/// </returns>
	public static byte[] Compress(this byte[] inputBuffer, CompressionLevel compressionLevel = CompressionLevel.Optimal)
	{
		byte[] outputBuffer;

		using (MemoryStream uncompressedStream = new(inputBuffer))
		{
			using MemoryStream compressedStream = new();
			using (DeflateStream compressorStream = new(compressedStream, compressionLevel, true))
				uncompressedStream.CopyTo(compressorStream);
			outputBuffer = compressedStream.ToArray();
		}

		return outputBuffer;
	}

	/// <summary>
	/// Decompresses the specified byte array using the Deflate compression algorithm.
	/// </summary>
	/// <remarks>
	/// This method uses the <see cref="DeflateStream"/> class to perform
	/// decompression. Ensure that the input data is properly compressed using the Deflate algorithm
	/// before calling this method.
	/// </remarks>
	/// <param name="inputBuffer">The compressed byte array to decompress.</param>
	/// <returns>
	/// A byte array containing the decompressed data. Returns an empty array if the input contains no data.
	/// </returns>
	public static byte[] Decompress(this byte[] inputBuffer)
	{
		byte[] outputBuffer;

		MemoryStream compressedStream = new(inputBuffer);
		using (DeflateStream decompressorStream = new(compressedStream, CompressionMode.Decompress))
		{
			using MemoryStream decompressedStream = new();
			decompressorStream.CopyTo(decompressedStream);
			outputBuffer = decompressedStream.ToArray();
		}

		return outputBuffer;
	}

	/// <summary>
	/// Converts the specified Base64-encoded string to its equivalent byte array representation.
	/// </summary>
	/// <remarks>
	/// The input string is trimmed of any leading or trailing whitespace before validation and decoding.
	/// Ensure that the input string is a valid Base64-encoded string to avoid exceptions.
	/// </remarks>
	/// <param name="value">The Base64-encoded string to convert.</param>
	/// <returns>
	/// A byte array containing the decoded data from the Base64 string. Returns an empty array if the
	/// input string is null or empty.
	/// </returns>
	/// <exception cref="ArgumentException">
	/// Thrown if <paramref name="value"/> is not a valid Base64-encoded string.
	/// </exception>
	public static byte[] FromBase64(this string value)
	{
		if (value.IsNullOrEmpty())
			return [];

		value = value.Trim();
		bool isValidBase64 = (value.Length % 4 == 0) && Base64Regex.IsMatch(value);

		if (isValidBase64.Equals(false))
			throw new ArgumentException($"{value} is not valid base64");

		byte[] bytes = Convert.FromBase64String(value);

		return bytes;
	}

	/// <summary>
	/// Converts the specified byte array to its hexadecimal string representation.
	/// </summary>
	/// <remarks>
	/// This method processes each byte in the array and converts it to a two-character hexadecimal
	/// string using uppercase letters. The resulting string concatenates these representations in order.
	/// </remarks>
	/// <param name="inputBuffer">The byte array to convert.</param>
	/// <returns>
	/// A string containing the hexadecimal representation of the byte array, with each byte represented
	/// as two uppercase hexadecimal characters.
	/// </returns>
	public static string GetHexString(this byte[] inputBuffer)
	{
		StringBuilder sb = new();
		foreach (byte b in inputBuffer)
			_ = sb.Append(b.ToString("X2", CultureInfo.InvariantCulture));
		return sb.ToString();
	}

	/// <summary>
	/// Computes the MD5 hash value for the specified byte array.
	/// </summary>
	/// <remarks>
	/// This method is not intended for cryptographic purposes. MD5 is considered insecure for
	/// cryptographic use cases.
	/// </remarks>
	/// <param name="value">The input byte array for which the MD5 hash is to be computed.</param>
	/// <returns>A byte array containing the computed MD5 hash value.</returns>
	[SuppressMessage("Security", "CA5351", Justification = "Not used for cryptographic algorithms.")]
	public static byte[] GetMD5(this byte[] value)
	{
#if NET6_0_OR_GREATER
		return MD5.HashData(value);
#else
		return MD5.Create().ComputeHash(value);
#endif
	}

	/// <summary>
	/// Computes the MD5 hash of the specified byte array and returns it as a hexadecimal string.
	/// </summary>
	/// <remarks>
	/// The returned string is in lowercase and contains no separators.
	/// </remarks>
	/// <param name="value">The byte array to compute the MD5 hash for.</param>
	/// <returns>
	/// A string representing the MD5 hash of the input byte array in hexadecimal format.
	/// </returns>
	public static string GetMD5String(this byte[] value)
		=> value.GetMD5().GetHexString();

	/// <summary>
	/// Converts the specified byte array to a string using the provided encoding.
	/// </summary>
	/// <param name="inputBuffer">The byte array to convert to a string.</param>
	/// <param name="encoding">
	/// The character encoding to use for the conversion. If null, <see cref="Encoding.UTF8"/> is used by default.
	/// </param>
	/// <returns>
	/// A string representation of the byte array, decoded using the specified or default encoding.
	/// </returns>
	public static string GetString(this byte[] inputBuffer, Encoding? encoding = null)
	{
		encoding ??= Encoding.UTF8;
		return encoding.GetString(inputBuffer);
	}

	/// <summary>
	/// Determines whether the specified byte is equal to its default value (0).
	/// </summary>
	/// <param name="value">The byte to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is equal to its default value (0);
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsDefault(this byte value)
		=> value.Equals(default);

	/// <summary>
	/// Determines whether the specified nullable byte is equal to its default value <see langword="null"/>.
	/// </summary>
	/// <param name="value">The nullable byte to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is equal to its default value <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsDefault([NotNullWhen(false)] this byte? value)
		=> value.Equals(default);

	/// <summary>
	/// Determines whether the specified byte is not equal to its default value (0).
	/// </summary>
	/// <param name="value">The byte to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is not equal to its default value (0);
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotDefault(this byte value)
		=> value.Equals(default).Equals(false);

	/// <summary>
	/// Determines whether the specified byte is not equal to its default value <see langword="null"/>.
	/// </summary>
	/// <param name="value">The byte to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is not equal to its default value <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotDefault([NotNullWhen(true)] this byte? value)
		=> value.Equals(default).Equals(false);

	/// <summary>
	/// Determines whether the specified byte is null.
	/// </summary>
	/// <param name="value">The byte array to check.</param>
	/// <returns>
	/// <see langword="true"/> if the specified byte is <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNull([NotNullWhen(false)] this byte? value)
		=> value is null;

	/// <summary>
	/// Determines whether the specified byte array is null.
	/// </summary>
	/// <param name="value">The byte array to check.</param>
	/// <returns>
	/// <see langword="true"/> if the specified byte array is <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNull([NotNullWhen(false)] this byte[]? value)
		=> value is null;

	/// <summary>
	/// Determines whether the specified byte is not null.
	/// </summary>
	/// <param name="value">The byte array to check.</param>
	/// <returns>
	/// <see langword="true"/> if the specified byte is not <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotNull([NotNullWhen(true)] this byte? value)
		=> value is not null;

	/// <summary>
	/// Determines whether the specified byte array is not null.
	/// </summary>
	/// <param name="value">The byte array to check.</param>
	/// <returns>
	/// <see langword="true"/> if the specified byte array is not <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotNull([NotNullWhen(true)] this byte[]? value)
		=> value is not null;

	/// <summary>
	/// Converts the specified byte array to its equivalent Base64 string representation.
	/// </summary>
	/// <param name="byteArray">The byte array to convert to a Base64 string.</param>
	/// <returns>
	/// A Base64-encoded string representation of the byte array.
	/// Returns an empty string if the byte array is empty.
	/// </returns>
	public static string ToBase64(this byte[] byteArray)
		=> byteArray.Length.Equals(0) ? string.Empty : Convert.ToBase64String(byteArray);
}
