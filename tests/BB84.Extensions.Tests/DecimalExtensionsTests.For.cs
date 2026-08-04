// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class DecimalExtensionsTests
{
	[TestMethod]
	[Description("Should iterate over a decimal range.")]
	public void For()
	{
		int iterationCount = default;
		decimal value = 15;

		value.For(x => iterationCount++);

		Assert.AreEqual(value, iterationCount);
	}

	[TestMethod]
	[Description("Should not iterate when the decimal value is zero or negative.")]
	public void ForWithNonPositiveValue()
	{
		int iterationCount = default;
		decimal value = -15;

		value.For(x => iterationCount++);

		Assert.AreEqual(0, iterationCount);
	}
}
