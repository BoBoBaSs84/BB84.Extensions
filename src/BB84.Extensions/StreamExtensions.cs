// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for working with <see cref="Stream"/> objects.
/// </summary>
/// <remarks>
/// This class contains utility methods that extend the functionality of the <see cref="Stream"/>
/// class, enabling common operations such as converting a stream to a byte array synchronously
/// or asynchronously.
/// </remarks>
public static class StreamExtensions
{
	/// <summary>
	/// Converts the contents of the specified <see cref="Stream"/> to a byte array.
	/// </summary>
	/// <remarks>
	/// The method reads the entire content of the <paramref name="inputStream"/> and returns
	/// it as a byte array. The position of the <paramref name="inputStream"/> is advanced as
	/// the data is read.
	/// </remarks>
	/// <param name="inputStream">The input <see cref="Stream"/> to read from.</param>
	/// <returns>
	/// A byte array containing the data read from the <paramref name="inputStream"/>.
	/// </returns>
	public static byte[] ToByteArray(this Stream inputStream)
	{
		byte[] buffer = new byte[16 * 1024];
		int read;
		using MemoryStream memoryStream = new();
		while ((read = inputStream.Read(buffer, 0, buffer.Length)) > 0)
			memoryStream.Write(buffer, 0, read);
		return memoryStream.ToArray();
	}

	/// <summary>
	/// Asynchronously converts the contents of the specified <see cref="Stream"/> to a byte array.
	/// </summary>
	/// <remarks>
	/// The method reads the entire content of the <paramref name="inputStream"/> asynchronously
	/// and returns it as a byte array. The position of the <paramref name="inputStream"/> is
	/// advanced as the data is read.
	/// </remarks>
	/// <param name="inputStream">The input <see cref="Stream"/> to read from.</param>
	/// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
	/// <returns>
	/// A task that represents the asynchronous operation. The task result contains a byte array
	/// with the data read from the <paramref name="inputStream"/>.
	/// </returns>
	public static async Task<byte[]> ToByteArrayAsync(this Stream inputStream, CancellationToken cancellationToken = default)
	{
		using MemoryStream memoryStream = new();
		
		await inputStream.CopyToAsync(memoryStream, 16 * 1024, cancellationToken)
			.ConfigureAwait(false);
		
		return memoryStream.ToArray();
	}
}
