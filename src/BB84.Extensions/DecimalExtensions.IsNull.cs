// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

public static partial class DecimalExtensions
{
	/// <summary>
	/// Indicates whether the specified decimal value is <see langword="null"/> or not.
	/// </summary>
	/// <param name="value">The decimal value to test.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is <see langword="null"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNull([NotNullWhen(false)] this decimal? value)
		=> value.HasValue.Equals(false);
}
