// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class ListExtensionsTests
{
	[TestMethod]
	public void TakeRandomShouldReturnElementFromList()
	{
		IList<int> list = [1, 2, 3, 4, 5];

		int result = list.TakeRandom();

		Assert.Contains(result, list);
	}

	[TestMethod]
	public void TakeRandomOrDefaultWithNonEmptyListShouldReturnElement()
	{
		IList<int> list = [1, 2, 3, 4, 5];

		int? result = list.TakeRandomOrDefault();

		Assert.IsNotNull(result);
		Assert.Contains(result.Value, list);
	}

	[TestMethod]
	public void TakeRandomOrDefaultWithEmptyListShouldReturnDefault()
	{
		IList<int> list = [];

		int result = list.TakeRandomOrDefault();

		Assert.AreEqual(default, result);
	}

	[TestMethod]
	public void TryTakeRandomWithNonEmptyListShouldReturnTrueAndElement()
	{
		IList<int> list = [1, 2, 3, 4, 5];

		bool success = list.TryTakeRandom(out int result);

		Assert.IsTrue(success);
		Assert.Contains(result, list);
	}

	[TestMethod]
	public void TryTakeRandomWithEmptyListShouldReturnFalseAndDefault()
	{
		IList<int> list = [];

		bool success = list.TryTakeRandom(out int result);

		Assert.IsFalse(success);
		Assert.AreEqual(default, result);
	}
}
