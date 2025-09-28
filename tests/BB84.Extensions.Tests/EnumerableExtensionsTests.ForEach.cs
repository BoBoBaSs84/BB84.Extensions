// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class EnumerableExtensionsTests
{
	[TestMethod]
	public void ForEachTest()
	{
		IList<TestClass> list = [];
		for (int i = 0; i < 10; i++)
			list.Add(new TestClass() { Value = i + 1 });

		int sumOne = list.Sum(x => x.Value);

		list.ForEach(x => ++x.Value);
		int sumTwo = list.Sum(x => x.Value);

		Assert.AreNotEqual(sumOne, sumTwo);
	}

	[TestMethod]
	public void ForEachWithPredicateTest()
	{
		int hits = default;
		IEnumerable<string> strings = ["a", "ab", "b", "bb"];

		strings.ForEach(x => x.Contains('a'), x => hits++);

		Assert.AreEqual(2, hits);
	}

	[TestMethod]
	public void ForEachWithPredicateAndBreakTest()
	{
		int hits = default;
		IEnumerable<string> strings = ["a", "ab", "b", "bb"];

		strings.ForEach(x => x.Contains('b'), x => x.StartsWith("b", StringComparison.OrdinalIgnoreCase), x => hits++);

		Assert.AreEqual(1, hits);
	}
}
