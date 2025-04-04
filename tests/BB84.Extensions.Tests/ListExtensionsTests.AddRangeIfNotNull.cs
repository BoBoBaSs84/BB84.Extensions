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
		IList<TestClass> target = new List<TestClass>();
		IEnumerable<TestClass> items = new List<TestClass>() { new(), default! };

		target.AddRangeIfNotNull(items);

		Assert.AreEqual(1, target.Count);
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentNullException))]
	public void AddRangeIfNotNullTargetNullTest()
	{
		IList<TestClass> target = default!;
		IEnumerable<TestClass> items = new List<TestClass>() { new() };

		target.AddRangeIfNotNull(items);
	}

	[TestMethod]
	public void AddRangeIfNotNullItemsNullTest()
	{
		IList<TestClass> target = new List<TestClass>();
		IEnumerable<TestClass> items = default!;

		target.AddRangeIfNotNull(items);

		Assert.AreEqual(0, target.Count);
	}

	[TestMethod]
	public void AddRangeIfNotNullItemsEmptyTest()
	{
		IList<TestClass> target = new List<TestClass>();
		IEnumerable<TestClass> items = new List<TestClass>();

		target.AddRangeIfNotNull(items);

		Assert.AreEqual(0, target.Count);
	}
}
