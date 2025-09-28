// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public partial class StringExtensionsTests
{
	[TestMethod]
	[DataRow("Unit Test", "UnitTest")]
	[DataRow("Unit  Test", "UnitTest")]
	public void RemoveWhitespaceTest(string value, string expected)
		=> Assert.AreEqual(expected, value.RemoveWhitespace());
}
