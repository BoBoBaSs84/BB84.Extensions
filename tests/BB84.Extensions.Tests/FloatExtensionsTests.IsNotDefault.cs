// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class FloatExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a float is not its default value (0).")]
	public void IsNotDefaultTest()
	{
		float value = default;
		Assert.IsFalse(value.IsNotDefault());

		value = 15;
		Assert.IsTrue(value.IsNotDefault());

		value = -0.0f;
		Assert.IsFalse(value.IsNotDefault());

		value = float.NaN;
		Assert.IsTrue(value.IsNotDefault());
	}

	[TestMethod]
	[Description("Should determine whether a nullable float is not its default value (null).")]
	public void IsNotDefaultNullableTest()
	{
		float? value = default;
		Assert.IsFalse(value.IsNotDefault());

		value = null;
		Assert.IsFalse(value.IsNotDefault());

		value = 15;
		Assert.IsTrue(value.IsNotDefault());

		value = 0;
		Assert.IsTrue(value.IsNotDefault());
	}
}
