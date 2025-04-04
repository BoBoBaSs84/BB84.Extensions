// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Text;

namespace BB84.Extensions;

public static partial class ByteExtensions
{
	/// <summary>
	/// Returns all the bytes in the specified byte array decoded into a string.
	/// </summary>
	/// <remarks>
	/// If <paramref name="encoding"/> is not provided, <see cref="Encoding.UTF8"/> is used.
	/// </remarks>
	/// <param name="inputBuffer">The byte array containing the sequence of bytes to decode.</param>
	/// <param name="encoding">The character encoding to use.</param>
	/// <returns>A string that contains the results of decoding the specified sequence of bytes.</returns>
	public static string GetString(this byte[] inputBuffer, Encoding? encoding = null)
	{
		encoding ??= Encoding.UTF8;
		return encoding.GetString(inputBuffer);
	}
}
