using System.Text;

namespace BB84.Extensions;

public static partial class StringExtensions
{
	/// <summary>
	/// Returns all the characters in the specified string encoded into a sequence of bytes.
	/// </summary>
	/// <remarks>
	/// If <paramref name="encoding"/> is not provided, <see cref="Encoding.UTF8"/> is used.
	/// </remarks>
	/// <param name="stringValue">The string value containing the characters to encode.</param>
	/// <param name="encoding">The character encoding to use.</param>
	/// <returns>A byte array containing the results of encoding the specified set of characters.</returns>
	public static byte[] GetBytes(this string stringValue, Encoding? encoding = null)
	{
		encoding ??= Encoding.UTF8;
		return encoding.GetBytes(stringValue);
	}
}
