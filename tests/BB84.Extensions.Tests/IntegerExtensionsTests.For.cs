﻿// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class IntegerExtensionsTests
{
	[TestMethod]
	[Description("Should iterate over an integer array.")]
	public void For()
	{
		int iterationCount = default;
		int value = 15;

		value.For(x => iterationCount++);

		Assert.AreEqual(value, iterationCount);
	}
}
