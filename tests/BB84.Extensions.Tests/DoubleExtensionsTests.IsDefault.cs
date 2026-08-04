// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class DoubleExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a double is its default value (0).")]
	public void IsDefaultTest()
	{
		double value = default;
		Assert.IsTrue(value.IsDefault());

		value = 15;
		Assert.IsFalse(value.IsDefault());

		value = -0.0d;
		Assert.IsTrue(value.IsDefault());

		value = double.NaN;
		Assert.IsFalse(value.IsDefault());
	}

	[TestMethod]
	[Description("Should determine whether a nullable double is its default value (null).")]
	public void IsDefaultNullableTest()
	{
		double? value = default;
		Assert.IsTrue(value.IsDefault());

		value = null;
		Assert.IsTrue(value.IsDefault());

		value = 15;
		Assert.IsFalse(value.IsDefault());

		value = 0;
		Assert.IsFalse(value.IsDefault());
	}
}
