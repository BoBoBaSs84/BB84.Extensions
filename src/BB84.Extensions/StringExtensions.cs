using System.Text.RegularExpressions;

namespace BB84.Extensions;

/// <summary>
/// The string extensions class.
/// </summary>
public static partial class StringExtensions
{
#if NET7_0_OR_GREATER
	private static readonly Regex Base64Regex = GeneratedBase64Regex();
	private static readonly Regex WhitespaceRegex = GeneratedWhitespaceRegex();
	private static readonly Regex LinebreakRegex = GeneratedLinebreakRegex();

	[GeneratedRegex(@"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None)]
	private static partial Regex GeneratedBase64Regex();

	[GeneratedRegex(@"\s+", RegexOptions.None)]
	private static partial Regex GeneratedWhitespaceRegex();

	[GeneratedRegex(@"(\r\n|\r|\n)", RegexOptions.None)]
	private static partial Regex GeneratedLinebreakRegex();
#else
	private static readonly Regex Base64Regex = new(@"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
	private static readonly Regex WhitespaceRegex = new(@"\s+", RegexOptions.None);
	private static readonly Regex LinebreakRegex = new(@"(\r\n|\r|\n)", RegexOptions.None);
#endif
}
