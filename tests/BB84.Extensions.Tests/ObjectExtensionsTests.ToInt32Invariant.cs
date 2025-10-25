// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;
public sealed partial class ObjectExtensionsTests
{
	[TestMethod(DisplayName = "Object to invariant int test")]
	public void ToInt32Invariant()
	{
		object obj = 5;

		int i = obj.ToInt32Invariant();

		Assert.AreEqual(5, i);
	}
}
