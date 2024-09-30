using System.Text;

namespace BB84.Extensions;

public static partial class StringExtensions
{
	/// <summary>
	/// Decodes the provided string from a base64 string.
	/// </summary>
	/// <param name="value">The input string to work with.</param>
	/// <param name="encoding">The encoding to use.</param>
	/// <returns>The decoded string.</returns>
	/// <exception cref="ArgumentException">The provided string is not a valid base64 string.</exception>
	public static string FromBase64(this string value, Encoding encoding)
	{
		byte[] buffer = value.FromBase64();
		return encoding.GetString(buffer);
	}
}
