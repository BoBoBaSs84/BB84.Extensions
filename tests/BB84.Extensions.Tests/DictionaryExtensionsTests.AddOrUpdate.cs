// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class DictionaryExtensionsTests
{
	[TestMethod]
	public void AddOrUpdateNewKeyTest()
	{
		Dictionary<string, int> dict = [];

		int result = dict.AddOrUpdate("a", 10, (_, v) => v + 1);

		Assert.AreEqual(10, result);
		Assert.AreEqual(10, dict["a"]);
	}

	[TestMethod]
	public void AddOrUpdateExistingKeyTest()
	{
		Dictionary<string, int> dict = new() { ["a"] = 5 };

		int result = dict.AddOrUpdate("a", 10, (_, v) => v + 1);

		Assert.AreEqual(6, result);
		Assert.AreEqual(6, dict["a"]);
	}

	[TestMethod]
	public void AddOrUpdateNullDictTest()
	{
		IDictionary<string, int> dict = default!;

		Assert.ThrowsExactly<ArgumentNullException>(() => dict.AddOrUpdate("key", 1, (_, v) => v));
	}

	[TestMethod]
	public void AddOrUpdateNullFactoryTest()
	{
		IDictionary<string, int> dict = new Dictionary<string, int>();

		Assert.ThrowsExactly<ArgumentNullException>(() => dict.AddOrUpdate("key", 1, null!));
	}
}
