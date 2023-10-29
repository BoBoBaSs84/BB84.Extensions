namespace BB84.Extensions;

public static partial class StringExtensions
{
	/// <summary>
	/// Decompresses a deflate compressed, Base64 encoded string and returns an uncompressed string.
	/// </summary>
	/// <param name="stringValue">The input string value to decompress.</param>
	/// <returns></returns>
	public static string Decompress(this string stringValue)
	{
		byte[] inputBuffer = Convert.FromBase64String(stringValue);

		byte[] outputBuffer = inputBuffer.Decompress();

		return outputBuffer.GetString();
	}
}
