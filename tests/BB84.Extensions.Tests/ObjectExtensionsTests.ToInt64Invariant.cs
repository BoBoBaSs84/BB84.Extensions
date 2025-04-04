// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class ObjectExtensionsTests
{
	[TestMethod("Object to invariant long test")]
	public void ToInt64Invariant()
	{
		object value = long.MaxValue;

		long l = value.ToInt64Invariant();

		Assert.AreEqual(long.MaxValue, l);
	}
}
