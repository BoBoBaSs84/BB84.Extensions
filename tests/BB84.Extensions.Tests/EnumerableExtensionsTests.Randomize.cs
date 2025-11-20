namespace BB84.Extensions.Tests;

public sealed partial class EnumerableExtensionsTests
{
	[TestMethod]
	public void RandomizeShouldReturnRandomizedSequence()
	{
		IEnumerable<int> original = [.. Enumerable.Range(1, 100)];

		IEnumerable<int> randomized = [.. original.Randomize()];

		Assert.HasCount(original.Count(), randomized, "The count of elements should remain the same after randomization.");
		CollectionAssert.AreEquivalent(original.ToList(), randomized.ToList(), "The randomized collection should contain the same elements as the original.");
		Assert.IsFalse(original.SequenceEqual(randomized), "The order of items should be different after randomization.");
	}
}
