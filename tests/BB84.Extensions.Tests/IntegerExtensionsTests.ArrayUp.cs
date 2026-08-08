// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class IntegerExtensionsTests
{
	[TestMethod]
	[Description("Should create an array of integers to a given maximum.")]
	public void ArrayUp()
	{
		int value = 0;
		int maxValue = 15;

		int[] array = value.ArrayUp(maxValue);

		Assert.HasCount(16, array);
	}

	[TestMethod]
	[Description("Should throw an exception.")]
	public void ArrayUpException()
	{
		int value = 15;
		int maxValue = 0;
		_ = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => _ = value.ArrayUp(maxValue));
	}

	[TestMethod]
	[Description("Should start at the given value instead of padding the array with leading zeros.")]
	public void ArrayUpShouldNotPadWithLeadingZeros()
	{
		int value = 5;
		int maxValue = 10;

		int[] array = value.ArrayUp(maxValue);

		Assert.HasCount(6, array);
		Assert.AreEqual(5, array[0]);
		Assert.AreEqual(10, array[5]);
	}

	[TestMethod]
	[Description("Should support a negative starting value.")]
	public void ArrayUpShouldSupportNegativeValues()
	{
		int value = -2;
		int maxValue = 2;

		int[] array = value.ArrayUp(maxValue);

		Assert.HasCount(5, array);
		Assert.AreEqual(-2, array[0]);
		Assert.AreEqual(2, array[4]);
	}
}
