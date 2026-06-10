// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class DictionaryExtensionsTests
{
	[TestMethod]
	public void GetOrDefaultExistingKeyTest()
	{
		IDictionary<string, int> dict = new Dictionary<string, int> { ["a"] = 1 };

		int result = dict.GetOrDefault("a");

		Assert.AreEqual(1, result);
	}

	[TestMethod]
	public void GetOrDefaultMissingKeyTest()
	{
		IDictionary<string, int> dict = new Dictionary<string, int>();

		int result = dict.GetOrDefault("missing");

		Assert.AreEqual(default, result);
	}

	[TestMethod]
	public void GetOrDefaultMissingKeyWithCustomDefaultTest()
	{
		IDictionary<string, int> dict = new Dictionary<string, int>();

		int result = dict.GetOrDefault("missing", 42);

		Assert.AreEqual(42, result);
	}

	[TestMethod]
	public void GetOrDefaultNullDictTest()
	{
		IDictionary<string, int> dict = default!;

		Assert.ThrowsExactly<ArgumentNullException>(() => dict.GetOrDefault("key"));
	}
}
