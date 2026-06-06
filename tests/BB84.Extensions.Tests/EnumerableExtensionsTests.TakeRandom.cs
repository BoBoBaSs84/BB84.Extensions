// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class EnumerableExtensionsTests
{
	[TestMethod]
	public void TakeRandomShouldReturnElementFromSequence()
	{
		IEnumerable<int> ints = [1, 2, 3, 4, 5];

		int result = ints.TakeRandom();

		Assert.Contains(result, ints);
	}

	[TestMethod]
	public void TakeRandomOrDefaultWithNonEmptySequenceShouldReturnElement()
	{
		IEnumerable<int> ints = [1, 2, 3, 4, 5];

		int? result = ints.TakeRandomOrDefault();

		Assert.IsNotNull(result);
		Assert.Contains(result.Value, ints);
	}

	[TestMethod]
	public void TakeRandomOrDefaultWithEmptySequenceShouldReturnDefault()
	{
		IEnumerable<int> ints = [];

		int result = ints.TakeRandomOrDefault();

		Assert.AreEqual(default, result);
	}

	[TestMethod]
	public void TryTakeRandomWithNonEmptySequenceShouldReturnTrueAndElement()
	{
		IEnumerable<int> ints = [1, 2, 3, 4, 5];

		bool success = ints.TryTakeRandom(out int result);

		Assert.IsTrue(success);
		Assert.Contains(result, ints);
	}

	[TestMethod]
	public void TryTakeRandomWithEmptySequenceShouldReturnFalseAndDefault()
	{
		IEnumerable<int> ints = [];

		bool success = ints.TryTakeRandom(out int result);

		Assert.IsFalse(success);
		Assert.AreEqual(default, result);
	}
}

