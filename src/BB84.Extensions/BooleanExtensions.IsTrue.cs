// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

public static partial class BooleanExtensions
{
	/// <summary>
	/// Indicates whether the specified Boolean <paramref name="value"/> is <see langword="true"/>.
	/// </summary>
	/// <param name="value">The <see cref="bool"/> value to work with.</param>
	/// <returns><see langword="true"/> if the <paramref name="value"/> is true, otherwise <see langword="false"/></returns>
	public static bool IsTrue(this bool value)
		=> value.Equals(true);

	/// <summary>
	/// Indicates whether the specified nullable Boolean <paramref name="value"/> is <see langword="true"/>.
	/// </summary>
	/// <param name="value">The nullable <see cref="bool"/> value to work with.</param>
	/// <returns><see langword="true"/> if the <paramref name="value"/> is true, otherwise <see langword="false"/></returns>
	public static bool IsTrue([NotNullWhen(true)] this bool? value)
		=> value.HasValue && value.Value.Equals(true);
}
