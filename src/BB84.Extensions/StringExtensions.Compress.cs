using System.IO.Compression;
using System.Text;

namespace BB84.Extensions;

public static partial class StringExtensions
{
	/// <summary>
	/// Compresses a string and returns a deflate compressed, Base64 encoded string.
	/// </summary>
	/// <param name="stringValue">The input string value to compress.</param>
	/// <param name="compressionLevel">The compression level to use.</param>
	/// <returns>The compressed base64 encoded string.</returns>
	public static string Compress(this string stringValue, CompressionLevel compressionLevel = CompressionLevel.Optimal)
	{
		byte[] inputBuffer = Encoding.UTF8.GetBytes(stringValue);

		byte[] outputBuffer = inputBuffer.Compress(compressionLevel);

		return Convert.ToBase64String(outputBuffer);
	}
}
