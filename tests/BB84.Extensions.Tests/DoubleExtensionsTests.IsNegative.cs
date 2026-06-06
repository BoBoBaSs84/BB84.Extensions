// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class DoubleExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a double or nullable double is a negative value.")]
	public void IsNegativeTest()
	{
		double value = -1;
		Assert.IsTrue(value.IsNegative());

		value = 1;
		Assert.IsFalse(value.IsNegative());

		value = 0;
		Assert.IsFalse(value.IsNegative());

		double? nullableValue = -1;
		Assert.IsTrue(nullableValue.IsNegative());

		nullableValue = 1;
		Assert.IsFalse(nullableValue.IsNegative());

		nullableValue = null;
		Assert.IsFalse(nullableValue.IsNegative());

		nullableValue = 0;
		Assert.IsFalse(nullableValue.IsNegative());
	}
}
