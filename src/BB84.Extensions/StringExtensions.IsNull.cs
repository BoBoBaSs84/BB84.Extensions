namespace BB84.Extensions;

public static partial class StringExtensions
{
	/// <summary>
	/// Indicates whether the specified string is null.
	/// </summary>
	/// <param name="value">The string value to test.</param>
	/// <returns><see langword="true"/> if the <paramref name="value"/>
	/// is <see langword="null"/>, otherwise <see langword="false"/>.</returns>
	public static bool IsNull(this string value)
		=> value is null;

	/// <summary>
	/// Indicates whether the specified string is null or an <see cref="string.Empty"/> string.
	/// </summary>
	/// <param name="value">The string value to test.</param>
	/// <returns>True if the value parameter is null or an empty string, otherwise false.</returns>
	public static bool IsNullOrEmpty(this string value)
		=> string.IsNullOrEmpty(value);

	/// <summary>
	/// Indicates whether a specified string is null, empty, or consists only of white-space
	/// characters.
	/// </summary>
	/// <param name="value">The string value to test.</param>
	/// <returns>True if the value parameter is null or an empty string or if value consists
	/// exclusively of white-space characters, otherwise false.</returns>
	public static bool IsNullOrWhiteSpace(this string value)
		=> string.IsNullOrWhiteSpace(value);
}
