// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class LongExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a long is its default value (0).")]
	public void IsDefaultTest()
	{
		long value = default;
		Assert.IsTrue(value.IsDefault());

		value = 15;
		Assert.IsFalse(value.IsDefault());
	}

	[TestMethod]
	[Description("Should determine whether a nullable long is its default value (null).")]
	public void IsDefaultNullableTest()
	{
		long? value = default;
		Assert.IsTrue(value.IsDefault());

		value = null;
		Assert.IsTrue(value.IsDefault());

		value = 15;
		Assert.IsFalse(value.IsDefault());

		value = 0;
		Assert.IsFalse(value.IsDefault());
	}
}
