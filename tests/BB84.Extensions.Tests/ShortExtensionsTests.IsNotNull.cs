// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class ShortExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a nullable short is not null.")]
	public void IsNotNullTest()
	{
		short? value = default;
		Assert.IsFalse(value.IsNotNull());

		value = null;
		Assert.IsFalse(value.IsNotNull());

		value = 15;
		Assert.IsTrue(value.IsNotNull());
	}
}
