namespace BB84.Extensions;

public static partial class ByteExtensions
{
	/// <summary>
	/// Converts the specified <paramref name="value"/>, which encodes binary data as base-64 digits,
	/// to an equivalent 8-bit unsigned integer array.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <returns>An array of 8-bit unsigned integers that is equivalent to <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentException"></exception>
	public static byte[] FromBase64(this string value)
	{
		if (value.IsNullOrEmpty())
			return [];

		value = value.Trim();
		bool isValidBase64 = (value.Length % 4 == 0) && Base64Regex.IsMatch(value);

		if (isValidBase64.Equals(false))
			throw new ArgumentException($"{value} is not valid base64");

		byte[] bytes = Convert.FromBase64String(value);

		return bytes;
	}
}
