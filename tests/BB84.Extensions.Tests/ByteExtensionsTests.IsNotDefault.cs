// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class ByteExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a byte is not its default value (0).")]
	public void IsNotDefaultLong()
	{
		byte value = default;
		Assert.IsFalse(value.IsNotDefault());

		value = 15;
		Assert.IsTrue(value.IsNotDefault());
	}

	[TestMethod]
	[Description("Should determine whether a nullable byte is not its default value (null).")]
	public void IsNotDefaultNullableLong()
	{
		byte? value = default;
		Assert.IsFalse(value.IsNotDefault());

		value = null;
		Assert.IsFalse(value.IsNotDefault());

		value = 15;
		Assert.IsTrue(value.IsNotDefault());
	}
}
