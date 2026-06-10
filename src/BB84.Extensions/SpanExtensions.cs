// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
using System.Globalization;
using System.Text;

using BB84.Extensions.Helper;

namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for <see cref="ReadOnlySpan{T}"/> and
/// <see cref="ReadOnlyMemory{T}"/>, offering allocation-free helpers that complement
/// <see cref="ByteExtensions"/> and <see cref="ArrayExtensions"/>.
/// </summary>
public static class SpanExtensions
{
	/// <summary>
	/// Determines whether the <paramref name="span"/> contains no elements.
	/// </summary>
	/// <typeparam name="T">The type of elements in the span.</typeparam>
	/// <param name="span">The span to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="span"/> has a length of zero;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsEmpty<T>(this ReadOnlySpan<T> span)
		=> span.Length == 0;

	/// <summary>
	/// Returns a randomly selected element from the <paramref name="span"/> without heap
	/// allocation.
	/// </summary>
	/// <typeparam name="T">The type of elements in the span.</typeparam>
	/// <param name="span">The span from which to select a random element.</param>
	/// <returns>A randomly selected element from <paramref name="span"/>.</returns>
	public static T TakeRandom<T>(this ReadOnlySpan<T> span)
		=> span[RandomHelper.Random.Next(0, span.Length)];

	/// <summary>
	/// Converts the <paramref name="span"/> to its uppercase hexadecimal string representation,
	/// mirroring the behavior of <see cref="ByteExtensions.GetHexString"/>.
	/// </summary>
	/// <remarks>
	/// Each byte is represented as two uppercase hexadecimal characters. The resulting string
	/// contains no separators.
	/// </remarks>
	/// <param name="span">The span of bytes to convert.</param>
	/// <returns>
	/// A string containing the uppercase hexadecimal representation of <paramref name="span"/>.
	/// </returns>
	public static string GetHexString(this ReadOnlySpan<byte> span)
	{
#if NET6_0_OR_GREATER
		return Convert.ToHexString(span);
#else
		StringBuilder sb = new();
		foreach (byte b in span)
			_ = sb.Append(b.ToString("X2", CultureInfo.InvariantCulture));
		return sb.ToString();
#endif
	}

	/// <summary>
	/// Copies the contents of <paramref name="memory"/> into a new <see cref="byte"/> array.
	/// </summary>
	/// <param name="memory">The memory segment to convert.</param>
	/// <returns>A new <see cref="byte"/>[] containing the data from <paramref name="memory"/>.</returns>
	public static byte[] ToByteArray(this ReadOnlyMemory<byte> memory)
		=> memory.ToArray();
}
#endif
