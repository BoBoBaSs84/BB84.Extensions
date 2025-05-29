// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Diagnostics.CodeAnalysis;

namespace BB84.Extensions;

public static partial class IntegerExtensions
{
	/// <summary>
	/// Indicates whether the specified integer value is <see langword="null"/> or not.
	/// </summary>
	/// <param name="value">The integer value to test.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is <see langword="null"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNull([NotNullWhen(true)] this int? value)
		=> value.HasValue.Equals(false);
}
