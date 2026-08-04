// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class ShortExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a short is not its default value (0).")]
	public void IsNotDefaultTest()
	{
		short value = default;
		Assert.IsFalse(value.IsNotDefault());

		value = 15;
		Assert.IsTrue(value.IsNotDefault());
	}

	[TestMethod]
	[Description("Should determine whether a nullable short is not its default value (null).")]
	public void IsNotDefaultNullableTest()
	{
		short? value = default;
		Assert.IsFalse(value.IsNotDefault());

		value = null;
		Assert.IsFalse(value.IsNotDefault());

		value = 15;
		Assert.IsTrue(value.IsNotDefault());

		value = 0;
		Assert.IsTrue(value.IsNotDefault());
	}
}
