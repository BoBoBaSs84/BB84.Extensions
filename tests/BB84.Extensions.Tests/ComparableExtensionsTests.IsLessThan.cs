// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public partial class ComparableExtensionsTests
{
	[DataRow(0, 0, false)]
	[DataRow(1, 0, false)]
	[DataRow(0, 1, true)]
	[DataTestMethod]
	public void IsLessThan(int value, int otherValue, bool expected)
		=> Assert.AreEqual(expected, value.IsLessThan(otherValue));
}
