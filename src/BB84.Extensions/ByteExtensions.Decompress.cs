using System.IO.Compression;

namespace BB84.Extensions;

public static partial class ByteExtensions
{
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
}
