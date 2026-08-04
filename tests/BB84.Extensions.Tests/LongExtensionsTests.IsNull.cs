// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class LongExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a nullable long is null.")]
	public void IsNullTest()
	{
		long? value = default;
		Assert.IsTrue(value.IsNull());

		value = null;
		Assert.IsTrue(value.IsNull());

		value = 15;
		Assert.IsFalse(value.IsNull());
	}
}
