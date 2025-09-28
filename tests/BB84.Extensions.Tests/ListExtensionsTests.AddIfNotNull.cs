// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class ListExtensionsTests
{
	[TestMethod]
	public void AddIfNotNullTest()
	{
		IList<TestClass> target = [];
		TestClass item = new();

		target.AddIfNotNull(item);

		Assert.HasCount(1, target);
	}

	[TestMethod]
	public void AddIfNotNullItemNullTest()
	{
		IList<TestClass> target = [];
		TestClass item = default!;

		target.AddIfNotNull(item);

		Assert.IsEmpty(target);
	}

	[TestMethod]
	public void AddIfNotNullTargetNullTest()
	{
		IList<TestClass> target = default!;
		TestClass item = new();

		Assert.ThrowsExactly<ArgumentNullException>(() => target.AddIfNotNull(item));
	}
}
