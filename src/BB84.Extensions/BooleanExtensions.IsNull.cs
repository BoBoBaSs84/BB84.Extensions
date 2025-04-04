// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

public static partial class BooleanExtensions
{
	/// <summary>
	/// Indicates whether the specified boolean value is <see langword="null"/> or not.
	/// </summary>
	/// <param name="value">The boolean value to test.</param>
	/// <returns><see langword="true"/> if the <paramref name="value"/>
	/// is <see langword="null"/>, otherwise <see langword="false"/>.</returns>
	public static bool IsNull(this bool? value)
		=> value.HasValue.Equals(false);
}
