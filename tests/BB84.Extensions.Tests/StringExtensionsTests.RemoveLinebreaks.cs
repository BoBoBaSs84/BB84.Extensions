// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public partial class StringExtensionsTests
{
	[DataTestMethod]
	[DataRow("Unit\rTest", "UnitTest")]
	[DataRow("Unit\r\nTest", "UnitTest")]
	[DataRow("Unit\nTest", "UnitTest")]
	public void RemoveLinebreakTest(string value, string expected)
		=> Assert.AreEqual(expected, value.RemoveLinebreak());
}
