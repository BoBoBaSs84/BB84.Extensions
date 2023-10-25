using System.Text;

namespace BB84.Extensions;

public static partial class StringExtensions
{
	/// <summary>
	/// Decodes the provided string from a base64 string.
	/// </summary>
	/// <param name="stringValue">The input string to work with.</param>
	/// <param name="encoding">The encoding to use.</param>
	/// <returns>The decoded string.</returns>
	/// <exception cref="ArgumentException">The provided string is not a valid base64 string.</exception>
	public static string FromBase64(this string stringValue, Encoding? encoding = null)
	{
		if (stringValue.IsNullOrEmpty())
			return string.Empty;

		// Check for valid base64
		stringValue = stringValue.Trim();
		bool isValidBase64 = (stringValue.Length % 4 == 0) && Base64.IsMatch(stringValue);

		if (isValidBase64.Equals(false))
			throw new ArgumentException($"{stringValue} is not valid base64");

		byte[] buffer = Convert.FromBase64String(stringValue);
		encoding ??= Encoding.Default;
		return encoding.GetString(buffer);
	}
}
