// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class DictionaryExtensionsTests
{
	[TestMethod]
	public void IsNotNullOrEmptyNullTest()
	{
		IDictionary<string, int>? dict = null;

		Assert.IsFalse(dict.IsNotNullOrEmpty());
	}

	[TestMethod]
	public void IsNotNullOrEmptyEmptyTest()
	{
		IDictionary<string, int> dict = new Dictionary<string, int>();

		Assert.IsFalse(dict.IsNotNullOrEmpty());
	}

	[TestMethod]
	public void IsNotNullOrEmptyNonEmptyTest()
	{
		IDictionary<string, int> dict = new Dictionary<string, int> { ["a"] = 1 };

		Assert.IsTrue(dict.IsNotNullOrEmpty());
	}
}
