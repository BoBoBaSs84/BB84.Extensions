// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

public static partial class EnumeratorExtensions
{
	/// <summary>
	/// Returns the integer value of an enumerator.
	/// </summary>
	/// <typeparam name="T">The type of the enumerator.</typeparam>
	/// <param name="value">The value of the enumerator.</param>
	/// <returns>The integer value of the enumerator.</returns>
	public static int GetInt<T>(this T value) where T : struct, IComparable, IFormattable, IConvertible
		=> (int)(object)value;
}
