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
/// The byte extensions class.
/// </summary>
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
	/// Compresses the provided byte array and returns the compressed byte array.
	/// </summary>
	/// <param name="inputBuffer">The byte array to compress.</param>
	/// <param name="compressionLevel">The compression level to use.</param>
	/// <returns>The compressed byte array.</returns>
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
	/// Decompresses the provided byte array and returns the decompressed byte array.
	/// </summary>
	/// <param name="inputBuffer">The byte array to decompress.</param>
	/// <returns>The decompressed byte array.</returns>
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
	/// Converts the specified <paramref name="value"/>, which encodes binary data as base-64 digits,
	/// to an equivalent 8-bit unsigned integer array.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <returns>An array of 8-bit unsigned integers that is equivalent to <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentException"></exception>
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
	/// Gets the hex string of a byte array
	/// </summary>
	/// <param name="inputBuffer">The byte array to work with.</param>
	/// <returns>The hexed string</returns>
	public static string GetHexString(this byte[] inputBuffer)
	{
		StringBuilder sb = new();
		foreach (byte b in inputBuffer)
			_ = sb.Append(b.ToString("X2", CultureInfo.InvariantCulture));
		return sb.ToString();
	}

	/// <summary>
	/// Returns the MD5 hash as byte array for a given byte array.
	/// </summary>
	/// <param name="value">The input byte array to work with.</param>
	/// <returns>The MD5 hash as byte array.</returns>
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
	/// Returns the MD5 hash as string for a given byte array.
	/// </summary>
	/// <param name="value">The input byte array to work with.</param>
	/// <returns>The MD5 hash as string.</returns>
	public static string GetMD5String(this byte[] value)
		=> value.GetMD5().GetHexString();

	/// <summary>
	/// Returns all the bytes in the specified byte array decoded into a string.
	/// </summary>
	/// <remarks>
	/// If <paramref name="encoding"/> is not provided, <see cref="Encoding.UTF8"/> is used.
	/// </remarks>
	/// <param name="inputBuffer">The byte array containing the sequence of bytes to decode.</param>
	/// <param name="encoding">The character encoding to use.</param>
	/// <returns>A string that contains the results of decoding the specified sequence of bytes.</returns>
	public static string GetString(this byte[] inputBuffer, Encoding? encoding = null)
	{
		encoding ??= Encoding.UTF8;
		return encoding.GetString(inputBuffer);
	}

	/// <summary>
	/// Indicates whether the specified byte array is null.
	/// </summary>
	/// <param name="value">The byte array value to test.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is <see langword="null"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNull([NotNullWhen(false)] this byte[]? value)
		=> value is null;

	/// <summary>
	/// Converts an array of 8-bit unsigned integers to its equivalent string representation
	/// that is encoded with base-64 digits.
	/// </summary>
	/// <param name="byteArray">An array of 8-bit unsigned integers.</param>
	/// <returns>The string representation, in base 64, of the contents of <paramref name="byteArray"/>.</returns>
	public static string ToBase64(this byte[] byteArray)
		=> byteArray.Length.Equals(0) ? string.Empty : Convert.ToBase64String(byteArray);
}
