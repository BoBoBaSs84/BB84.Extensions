// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class ListExtensionsTests
{
	[TestMethod]
	public void AddRangeIfNotNullTest()
	{
		IList<TestClass> target = [];
		IEnumerable<TestClass> items = [new(), default!];

		target.AddRangeIfNotNull(items);

		Assert.HasCount(1, target);
	}

	[TestMethod]
	public void AddRangeIfNotNullTargetNullTest()
	{
		IList<TestClass> target = default!;
		IEnumerable<TestClass> items = [new()];

		Assert.ThrowsExactly<ArgumentNullException>(() => target.AddRangeIfNotNull(items));
	}

	[TestMethod]
	public void AddRangeIfNotNullItemsNullTest()
	{
		IList<TestClass> target = [];
		IEnumerable<TestClass> items = default!;

		target.AddRangeIfNotNull(items);

		Assert.IsEmpty(target);
	}

	[TestMethod]
	public void AddRangeIfNotNullItemsEmptyTest()
	{
		IList<TestClass> target = [];
		IEnumerable<TestClass> items = [];

		target.AddRangeIfNotNull(items);

		Assert.IsEmpty(target);
	}
}
