﻿// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Text;

namespace BB84.Extensions.Tests;

public sealed partial class StringExtensionsTests
{
	[DataTestMethod]
	[DataRow("UnitTest", "VW5pdFRlc3Q=")]
	[DataRow("", "")]
	public void FromBase64Test(string expected, string value)
		=> Assert.AreEqual(expected, value.FromBase64(Encoding.UTF8));

	[DataTestMethod]
	[DataRow("%")]
	[DataRow("$")]
	[DataRow("#")]
	[ExpectedException(typeof(ArgumentException))]
	public void FromBase64ExceptionTest(string value)
		=> value.FromBase64();
}
