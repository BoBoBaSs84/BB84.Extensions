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

		Assert.AreEqual(16, array.Length);
	}

	[TestMethod]
	[Description("Should throw an exception.")]
	public void ArrayDownException()
	{
		int value = 0;
		int minValue = 15;
		Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => _ = value.ArrayDown(minValue));
	}
}
