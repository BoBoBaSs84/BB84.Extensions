// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public partial class StringExtensionsTests
{
	[DataTestMethod]
	[DataRow("Test", true)]
	[DataRow(null, false)]
	[DataRow("", true)]
	[DataRow(" ", true)]
	public void IsNotNullTest(string? value, bool expected)
		=> Assert.AreEqual(expected, value.IsNotNull());

	[DataTestMethod]
	[DataRow("Test", true)]
	[DataRow(null, false)]
	[DataRow("", false)]
	[DataRow(" ", true)]
	public void IsNotNullOrEmptyTest(string? value, bool expected)
		=> Assert.AreEqual(expected, value.IsNotNullOrEmpty());

	[DataTestMethod]
	[DataRow("Test", true)]
	[DataRow(null, false)]
	[DataRow("", false)]
	[DataRow(" ", false)]
	public void IsNotNullOrWhiteSpaceTest(string? value, bool expected)
		=> Assert.AreEqual(expected, value.IsNotNullOrWhiteSpace());
}
