using System.IO.Compression;
using System.Text;

namespace BB84.Extensions;

public static partial class StringExtensions
{
	/// <summary>
	/// Compresses a string and returns a deflate compressed, Base64 encoded string.
	/// </summary>
	/// <param name="value">Input string to compress.</param>
	/// <param name="compressionLevel">The compression level to use.</param>
	/// <returns></returns>
	public static string Compress(this string value, CompressionLevel compressionLevel = CompressionLevel.Optimal)
	{
		byte[] compressedBytes;

		using (MemoryStream uncompressedStream = new(Encoding.UTF8.GetBytes(value)))
		{
			using MemoryStream compressedStream = new();
			using (DeflateStream compressorStream = new(compressedStream, compressionLevel, true))
				uncompressedStream.CopyTo(compressorStream);
			compressedBytes = compressedStream.ToArray();
		}

		return Convert.ToBase64String(compressedBytes);
	}
}
