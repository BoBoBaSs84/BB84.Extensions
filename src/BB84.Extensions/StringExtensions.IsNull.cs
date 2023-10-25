namespace BB84.Extensions;

public static partial class StringExtensions
{
	/// <summary>
	/// Indicates whether the specified string is null.
	/// </summary>
	/// <param name="stringValue">The string value to test.</param>
	/// <returns>True if the value parameter is null, otherwise false.</returns>
	public static bool IsNull(this string stringValue)
		=> stringValue is null;

	/// <summary>
	/// Indicates whether the specified string is null or an <see cref="string.Empty"/> string.
	/// </summary>
	/// <param name="stringValue">The string value to test.</param>
	/// <returns>True if the value parameter is null or an empty string, otherwise false.</returns>
	public static bool IsNullOrEmpty(this string stringValue)
		=> string.IsNullOrEmpty(stringValue);

	/// <summary>
	/// Indicates whether a specified string is null, empty, or consists only of white-space
	/// characters.
	/// </summary>
	/// <param name="stringValue">The string value to test.</param>
	/// <returns>True if the value parameter is null or an empty string or if value consists
	/// exclusively of white-space characters, otherwise false.</returns>
	public static bool IsNullOrWhiteSpace(this string stringValue)
		=> string.IsNullOrWhiteSpace(stringValue);
}
