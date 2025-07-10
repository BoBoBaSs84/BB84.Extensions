// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

/// <summary>
/// The <see cref="Stream"/> extensions class.
/// </summary>
public static class StreamExtensions
{
	/// <summary>
	/// The method will keep reading (and copying into a <see cref="MemoryStream"/>)
	/// until it runs out of data.
	/// </summary>
	/// <param name="inputStream">The stream to work with.</param>
	/// <returns>The <see cref="Stream"/> as <see cref="byte"/> array.</returns>
	public static byte[] ToByteArray(this Stream inputStream)
	{
		byte[] buffer = new byte[16 * 1024];
		int read;
		using MemoryStream memoryStream = new();
		while ((read = inputStream.Read(buffer, 0, buffer.Length)) > 0)
			memoryStream.Write(buffer, 0, read);
		return memoryStream.ToArray();
	}
}
