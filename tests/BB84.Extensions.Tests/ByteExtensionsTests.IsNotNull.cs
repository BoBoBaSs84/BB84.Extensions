﻿// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public partial class ByteExtensionsTests
{
	[DataTestMethod]
	[DataRow(byte.MinValue, true)]
	[DataRow(null, false)]
	public void IsNotNullTest(byte? value, bool expected)
		=> Assert.AreEqual(expected, value.IsNotNull());

	[DataTestMethod]
	[DataRow(new byte[] { 0 }, true)]
	[DataRow(null, false)]
	public void IsNotNullTest(byte[]? value, bool expected)
		=> Assert.AreEqual(expected, value.IsNotNull());
}
