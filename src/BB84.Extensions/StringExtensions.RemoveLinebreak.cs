namespace BB84.Extensions;

public static partial class StringExtensions
{
	/// <summary>
	/// Removes unwanted linebreaks within the provided string value.
	/// </summary>
	/// <param name="stringValue">The input string value to modify.</param>
	/// <returns>The replaced string.</returns>
	public static string RemoveLinebreak(this string stringValue)
		=> LinebreakRegex.Replace(stringValue, string.Empty);
}
