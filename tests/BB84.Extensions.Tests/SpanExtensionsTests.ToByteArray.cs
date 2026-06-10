// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
#if NET5_0_OR_GREATER
namespace BB84.Extensions.Tests;

public sealed partial class SpanExtensionsTests
{
	[TestMethod]
	public void ToByteArrayShouldReturnEquivalentArray()
	{
		byte[] source = [1, 2, 3, 4];
		ReadOnlyMemory<byte> memory = source;

		byte[] result = SpanExtensions.ToByteArray(memory);

		CollectionAssert.AreEqual(source, result);
	}

	[TestMethod]
	public void ToByteArrayWithEmptyMemoryShouldReturnEmptyArray()
	{
		ReadOnlyMemory<byte> memory = ReadOnlyMemory<byte>.Empty;

		byte[] result = SpanExtensions.ToByteArray(memory);

		Assert.IsEmpty(result);
	}
}
#endif
