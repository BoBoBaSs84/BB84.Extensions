using System.IO.Compression;

namespace BB84.Extensions;

public static partial class ByteExtensions
{
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
}
