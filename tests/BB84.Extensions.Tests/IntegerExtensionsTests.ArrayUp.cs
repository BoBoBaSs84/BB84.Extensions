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

		Assert.AreEqual(16, array.Length);
	}

	[TestMethod]
	[Description("Should throw an exception.")]
	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void ArrayUpException()
	{
		int value = 15;
		int maxValue = 0;
		_ = value.ArrayUp(maxValue);
	}
}
