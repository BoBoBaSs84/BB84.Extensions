// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class DictionaryExtensionsTests
{
	[TestMethod]
	public void IsNullOrEmptyNullTest()
	{
		IDictionary<string, int>? dict = null;

		Assert.IsTrue(dict.IsNullOrEmpty());
	}

	[TestMethod]
	public void IsNullOrEmptyEmptyTest()
	{
		IDictionary<string, int> dict = new Dictionary<string, int>();

		Assert.IsTrue(dict.IsNullOrEmpty());
	}

	[TestMethod]
	public void IsNullOrEmptyNonEmptyTest()
	{
		IDictionary<string, int> dict = new Dictionary<string, int> { ["a"] = 1 };

		Assert.IsFalse(dict.IsNullOrEmpty());
	}
}
