// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Text.RegularExpressions;

namespace BB84.Extensions;

/// <summary>
/// The string extensions class.
/// </summary>
public static partial class StringExtensions
{
#if NET7_0_OR_GREATER
	private static readonly Regex WhitespaceRegex = GeneratedWhitespaceRegex();
	private static readonly Regex LinebreakRegex = GeneratedLinebreakRegex();

	[GeneratedRegex(@"\s+", RegexOptions.None)]
	private static partial Regex GeneratedWhitespaceRegex();

	[GeneratedRegex(@"(\r\n|\r|\n)", RegexOptions.None)]
	private static partial Regex GeneratedLinebreakRegex();
#else
	private static readonly Regex WhitespaceRegex = new(@"\s+", RegexOptions.None);
	private static readonly Regex LinebreakRegex = new(@"(\r\n|\r|\n)", RegexOptions.None);
#endif
}
