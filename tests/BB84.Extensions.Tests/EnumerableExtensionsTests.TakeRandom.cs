// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class EnumerableExtensionsTests
{
	[TestMethod]
	public void TakeRandom()
	{
		IEnumerable<int> ints = [1, 2, 3, 4, 5];

		int i = ints.TakeRandom();

		Assert.IsTrue(ints.Contains(i));
	}
}
