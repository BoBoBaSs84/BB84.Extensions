namespace BB84.Extensions.Tests;

public sealed partial class ListExtensionsTests
{
	[TestMethod]
	public void RandomizeShouldRandomizeListItems()
	{
		List<int> originalList = [.. Enumerable.Range(1, 100)];

		List<int> randomizedList = [.. originalList.Randomize()];

		Assert.HasCount(originalList.Count, randomizedList, "The count of items should remain the same after randomization.");
		CollectionAssert.AreEquivalent(originalList, randomizedList, "The randomized list should contain the same items as the original list.");
		Assert.IsFalse(originalList.SequenceEqual(randomizedList), "The order of items should be different after randomization.");
	}
}
