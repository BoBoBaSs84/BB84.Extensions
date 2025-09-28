// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public partial class StringExtensionsTests
{
	[TestMethod]
	[DataRow("Test", false)]
	[DataRow(null, true)]
	[DataRow("", false)]
	[DataRow(" ", false)]
	public void IsNullTest(string? value, bool expected)
		=> Assert.AreEqual(expected, value.IsNull());

	[TestMethod]
	[DataRow("Test", false)]
	[DataRow(null, true)]
	[DataRow("", true)]
	[DataRow(" ", false)]
	public void IsNullOrEmptyTest(string? value, bool expected)
		=> Assert.AreEqual(expected, value.IsNullOrEmpty());

	[TestMethod]
	[DataRow("Test", false)]
	[DataRow(null, true)]
	[DataRow("", true)]
	[DataRow(" ", true)]
	public void IsNullOrWhiteSpaceTest(string? value, bool expected)
		=> Assert.AreEqual(expected, value.IsNullOrWhiteSpace());
}
