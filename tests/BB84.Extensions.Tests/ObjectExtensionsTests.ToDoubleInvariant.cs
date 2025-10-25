// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class ObjectExtensionsTests
{
	[TestMethod(DisplayName = "Object to invariant double test")]
	public void ToDoubleInvariant()
	{
		object obj = 123.987d;

		double d = obj.ToDoubleInvariant();

		Assert.AreEqual(123.987d, d);
	}
}
