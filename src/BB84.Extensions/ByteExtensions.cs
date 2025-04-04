// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Text.RegularExpressions;

namespace BB84.Extensions;

/// <summary>
/// The byte extensions class.
/// </summary>
public static partial class ByteExtensions
{
#if NET7_0_OR_GREATER
	private static readonly Regex Base64Regex = GeneratedBase64Regex();

	[GeneratedRegex(@"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None)]
	private static partial Regex GeneratedBase64Regex();
#else
	private static readonly Regex Base64Regex = new(@"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
#endif
}
