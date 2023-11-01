using System.Text.RegularExpressions;

namespace BB84.Extensions;

/// <summary>
/// The string extensions class.
/// </summary>
public static partial class StringExtensions
{
	private static readonly Regex Base64Regex = new(@"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
	private static readonly Regex WhitespaceRegex = new(@"\s+", RegexOptions.None);
	private static readonly Regex LinebreakRegex = new(@"(\r\n|\r|\n)", RegexOptions.None);
}
