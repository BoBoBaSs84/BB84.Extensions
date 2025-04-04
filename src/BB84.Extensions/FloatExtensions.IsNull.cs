﻿// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

public static partial class FloatExtensions
{
	/// <summary>
	/// Indicates whether the specified float value is <see langword="null"/> or not.
	/// </summary>
	/// <param name="value">The float value to check.</param>
	/// <returns><see langword="true"/> if the <paramref name="value"/>
	/// is <see langword="null"/>, otherwise <see langword="false"/>.</returns>
	public static bool IsNull(this float? value)
		=> value.HasValue.Equals(false);
}
