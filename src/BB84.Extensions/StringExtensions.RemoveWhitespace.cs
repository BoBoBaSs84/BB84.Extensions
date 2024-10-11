namespace BB84.Extensions;

public static partial class StringExtensions
{
	/// <summary>
	/// Removes unwanted whitespace within the provided string value.
	/// </summary>
	/// <param name="stringValue">The input string value to modify.</param>
	/// <returns>The same <see cref="string"/> instance so that multiple calls can be chained.</returns>
	public static string RemoveWhitespace(this string stringValue)
		=> WhitespaceRegex.Replace(stringValue, string.Empty);
}
