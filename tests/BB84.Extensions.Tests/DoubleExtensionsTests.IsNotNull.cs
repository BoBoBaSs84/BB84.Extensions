﻿// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class DoubleExtensionsTests
{
	[DataTestMethod]
	[DataRow(1.67d, true)]
	[DataRow(null, false)]
	public void IsNotNullTest(double? value, bool expected)
		=> Assert.AreEqual(expected, value.IsNotNull());
}
