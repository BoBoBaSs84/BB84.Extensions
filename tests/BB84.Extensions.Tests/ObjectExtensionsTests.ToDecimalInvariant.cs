﻿// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class ObjectExtensionsTests
{
	[TestMethod("Object to invariant decimal test")]
	public void ToDecimalInvariant()
	{
		object obj = 3765.2343m;

		decimal d = obj.ToDecimalInvariant();

		Assert.AreEqual(3765.2343m, d);
	}
}
