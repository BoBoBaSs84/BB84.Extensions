using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace BB84.Extensions;

public static partial class StringExtensions
{
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
