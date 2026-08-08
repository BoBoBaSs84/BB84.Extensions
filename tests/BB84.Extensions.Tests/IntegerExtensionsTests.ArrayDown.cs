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
	public void ArrayDown()
	{
		int value = 15;
		int minValue = 0;

		int[] array = value.ArrayDown(minValue);

		Assert.HasCount(16, array);
	}

	[TestMethod]
	[Description("Should throw an exception.")]
	public void ArrayDownException()
	{
		int value = 0;
		int minValue = 15;
		_ = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => _ = value.ArrayDown(minValue));
	}

	[TestMethod]
	[Description("Should start at the given minimum instead of padding the array with leading zeros.")]
	public void ArrayDownShouldNotPadWithLeadingZeros()
	{
		int value = 10;
		int minValue = 5;

		int[] array = value.ArrayDown(minValue);

		Assert.HasCount(6, array);
		Assert.AreEqual(5, array[0]);
		Assert.AreEqual(10, array[5]);
	}

	[TestMethod]
	[Description("Should support a negative minimum value.")]
	public void ArrayDownShouldSupportNegativeValues()
	{
		int value = 2;
		int minValue = -2;

		int[] array = value.ArrayDown(minValue);

		Assert.HasCount(5, array);
		Assert.AreEqual(-2, array[0]);
		Assert.AreEqual(2, array[4]);
	}
}
