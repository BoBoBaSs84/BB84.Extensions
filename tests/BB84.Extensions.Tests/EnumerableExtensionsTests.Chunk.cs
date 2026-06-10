// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class EnumerableExtensionsTests
{
	[TestMethod]
	public void ChunkEvenlyDivisibleSequenceTest()
	{
		IEnumerable<int> values = [1, 2, 3, 4, 5, 6];
		int[] firstExpected = [1, 2];
		int[] secondExpected = [3, 4];
		int[] thirdExpected = [5, 6];

		int[][] chunks = [.. values.Chunk(2)];

		Assert.HasCount(3, chunks);
		CollectionAssert.AreEqual(firstExpected, chunks[0]);
		CollectionAssert.AreEqual(secondExpected, chunks[1]);
		CollectionAssert.AreEqual(thirdExpected, chunks[2]);
	}

	[TestMethod]
	public void ChunkNonDivisibleSequenceTest()
	{
		IEnumerable<int> values = [1, 2, 3, 4, 5];
		int[] firstExpected = [1, 2];
		int[] secondExpected = [3, 4];
		int[] thirdExpected = [5];

		int[][] chunks = [.. values.Chunk(2)];

		Assert.HasCount(3, chunks);
		CollectionAssert.AreEqual(firstExpected, chunks[0]);
		CollectionAssert.AreEqual(secondExpected, chunks[1]);
		CollectionAssert.AreEqual(thirdExpected, chunks[2]);
	}

	[TestMethod]
	public void ChunkSizeLargerThanSequenceTest()
	{
		IEnumerable<int> values = [1, 2, 3];
		int[] expected = [1, 2, 3];

		int[][] chunks = [.. values.Chunk(10)];

		Assert.HasCount(1, chunks);
		CollectionAssert.AreEqual(expected, chunks[0]);
	}

	[TestMethod]
	public void ChunkSizeOfOneTest()
	{
		IEnumerable<int> values = [1, 2, 3];
		int[] firstExpected = [1];
		int[] secondExpected = [2];
		int[] thirdExpected = [3];

		int[][] chunks = [.. values.Chunk(1)];

		Assert.HasCount(3, chunks);
		CollectionAssert.AreEqual(firstExpected, chunks[0]);
		CollectionAssert.AreEqual(secondExpected, chunks[1]);
		CollectionAssert.AreEqual(thirdExpected, chunks[2]);
	}

	[TestMethod]
	public void ChunkEmptySequenceTest()
	{
		IEnumerable<int> values = [];

		int[][] chunks = [.. values.Chunk(3)];

		Assert.IsEmpty(chunks);
	}

	[TestMethod]
	public void ChunkNullSequenceThrowsArgumentNullExceptionTest()
	{
		IEnumerable<int> values = default!;

		Assert.ThrowsExactly<ArgumentNullException>(() => values.Chunk(2).ToArray());
	}

	[TestMethod]
	public void ChunkZeroSizeThrowsArgumentOutOfRangeExceptionTest()
	{
		IEnumerable<int> values = [1, 2, 3];

		Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => values.Chunk(0).ToArray());
	}

	[TestMethod]
	public void ChunkNegativeSizeThrowsArgumentOutOfRangeExceptionTest()
	{
		IEnumerable<int> values = [1, 2, 3];

		Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => values.Chunk(-1).ToArray());
	}
}
