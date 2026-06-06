// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class DoubleExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a double or nullable double is a non negative value.")]
	public void IsNonNegativeTest()
	{
		double value = -1;
		Assert.IsFalse(value.IsNonNegative());

		value = 1;
		Assert.IsTrue(value.IsNonNegative());

		value = 0;
		Assert.IsTrue(value.IsNonNegative());

		double? nullableValue = -1;
		Assert.IsFalse(nullableValue.IsNonNegative());

		nullableValue = 1;
		Assert.IsTrue(nullableValue.IsNonNegative());

		nullableValue = null;
		Assert.IsFalse(nullableValue.IsNonNegative());

		nullableValue = 0;
		Assert.IsTrue(nullableValue.IsNonNegative());
	}
}
