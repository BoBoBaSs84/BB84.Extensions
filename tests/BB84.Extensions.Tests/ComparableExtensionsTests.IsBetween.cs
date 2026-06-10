// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public partial class ComparableExtensionsTests
{
	// Inclusive (default)
	[DataRow(5, 1, 10, true, true)]
	[DataRow(1, 1, 10, true, true)]
	[DataRow(10, 1, 10, true, true)]
	[DataRow(0, 1, 10, true, false)]
	[DataRow(11, 1, 10, true, false)]
	// Exclusive
	[DataRow(5, 1, 10, false, true)]
	[DataRow(1, 1, 10, false, false)]
	[DataRow(10, 1, 10, false, false)]
	[DataRow(0, 1, 10, false, false)]
	[DataRow(11, 1, 10, false, false)]
	[TestMethod]
	public void IsBetween(int value, int min, int max, bool inclusive, bool expected)
		=> Assert.AreEqual(expected, value.IsBetween(min, max, inclusive));

	[TestMethod]
	public void IsBetweenShouldThrowArgumentOutOfRangeException()
		=> Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => 5.IsBetween(10, 1));
}
