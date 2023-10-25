using System.Text.RegularExpressions;

namespace BB84.Extensions;

/// <summary>
/// The string extensions class.
/// </summary>
public static partial class StringExtensions
{
	private static readonly Regex Base64 = new(@"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
}
