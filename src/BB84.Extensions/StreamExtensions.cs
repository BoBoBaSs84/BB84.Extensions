namespace BB84.Extensions;

/// <summary>
/// The stream extensions class.
/// </summary>
public static partial class StreamExtensions
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
		using MemoryStream memoryStream = new();
		int read;
		while ((read = inputStream.Read(buffer, 0, buffer.Length)) > 0)
			memoryStream.Write(buffer, 0, read);
		return memoryStream.ToArray();
	}
}
