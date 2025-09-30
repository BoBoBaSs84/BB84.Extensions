// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class BooleanExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a bool is its default value (false).")]
	public void IsDefaultLong()
	{
		bool value = default;
		Assert.IsTrue(value.IsDefault());

		value = true;
		Assert.IsFalse(value.IsDefault());
	}

	[TestMethod]
	[Description("Should determine whether a nullable bool is its default value (null).")]
	public void IsDefaultNullableLong()
	{
		bool? value = default;
		Assert.IsTrue(value.IsDefault());

		value = null;
		Assert.IsTrue(value.IsDefault());

		value = false;
		Assert.IsFalse(value.IsDefault());

		value = true;
		Assert.IsFalse(value.IsDefault());
	}
}
