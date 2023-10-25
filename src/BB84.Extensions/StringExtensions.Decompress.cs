using System.IO.Compression;
using System.Text;

namespace BB84.Extensions;

public static partial class StringExtensions
{
	/// <summary>
	/// Decompresses a deflate compressed, Base64 encoded string and returns an uncompressed string.
	/// </summary>
	/// <param name="value">Input string to decompress.</param>
	public static string Decompress(this string value)
	{
		byte[] decompressedBytes;

		MemoryStream compressedStream = new(Convert.FromBase64String(value));
		using (DeflateStream decompressorStream = new(compressedStream, CompressionMode.Decompress))
		{
			using MemoryStream decompressedStream = new();
			decompressorStream.CopyTo(decompressedStream);
			decompressedBytes = decompressedStream.ToArray();
		}

		return Encoding.UTF8.GetString(decompressedBytes);
	}
}
