// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class DecimalExtensionsTests
{
	[TestMethod]
	public void IsNotNullTrueTest()
	{
		decimal? value = 13.753m;
		Assert.IsTrue(value.IsNotNull());
	}

	[TestMethod]
	public void IsNotNullFalseTest()
	{
		decimal? value = null;
		Assert.IsFalse(value.IsNotNull());
	}
}
