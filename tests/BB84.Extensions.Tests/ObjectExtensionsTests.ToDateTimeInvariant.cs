// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class ObjectExtensionsTests
{
	[TestMethod("Object to invariant date time test")]
	public void ToDateTimeInvariant()
	{
		object obj = DateTime.MaxValue;

		DateTime dt = obj.ToDateTimeInvariant();

		Assert.AreEqual(DateTime.MaxValue, dt);
	}
}
