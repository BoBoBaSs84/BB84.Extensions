// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class ArrayExtensionsTests
{
	[TestMethod]
	public void RandomizeShouldRandomizeArrayItems()
	{
		int[] originalArray = [.. Enumerable.Range(1, 100)];

		int[] randomizedArray = originalArray.Randomize();

		Assert.HasCount(originalArray.Length, randomizedArray, "The length of items should remain the same after randomization.");
		CollectionAssert.AreEquivalent(originalArray, randomizedArray, "The randomized array should contain the same items as the original array.");
		Assert.IsFalse(originalArray.SequenceEqual(randomizedArray), "The order of items should be different after randomization.");
	}
}
