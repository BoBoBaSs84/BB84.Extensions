using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace BB84.Extensions;

public static partial class ByteExtensions
{
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
}
