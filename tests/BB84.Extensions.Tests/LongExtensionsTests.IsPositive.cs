// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class LongExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a long or nullable long is a positive value.")]
	public void IsPositiveTest()
	{
		long value = 1;
		Assert.IsTrue(value.IsPositive());

		value = -1;
		Assert.IsFalse(value.IsPositive());

		value = 0;
		Assert.IsFalse(value.IsPositive());

		long? nullableValue = -1;
		Assert.IsFalse(nullableValue.IsPositive());

		nullableValue = 1;
		Assert.IsTrue(nullableValue.IsPositive());

		nullableValue = null;
		Assert.IsFalse(nullableValue.IsPositive());

		nullableValue = 0;
		Assert.IsFalse(nullableValue.IsPositive());
	}
}
