// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class DictionaryExtensionsTests
{
	[TestMethod]
	public void GetOrAddExistingKeyTest()
	{
		Dictionary<string, int> dict = new() { ["a"] = 1 };
		bool factoryCalled = false;

		int result = dict.GetOrAdd("a", _ => { factoryCalled = true; return 99; });

		Assert.AreEqual(1, result);
		Assert.IsFalse(factoryCalled);
	}

	[TestMethod]
	public void GetOrAddMissingKeyTest()
	{
		Dictionary<string, int> dict = [];

		int result = dict.GetOrAdd("b", k => k.Length);

		Assert.AreEqual(1, result);
		Assert.IsTrue(dict.ContainsKey("b"));
	}

	[TestMethod]
	public void GetOrAddNullDictTest()
	{
		IDictionary<string, int> dict = default!;

		Assert.ThrowsExactly<ArgumentNullException>(() => dict.GetOrAdd("key", _ => 0));
	}

	[TestMethod]
	public void GetOrAddNullFactoryTest()
	{
		IDictionary<string, int> dict = new Dictionary<string, int>();

		Assert.ThrowsExactly<ArgumentNullException>(() => dict.GetOrAdd("key", null!));
	}
}
