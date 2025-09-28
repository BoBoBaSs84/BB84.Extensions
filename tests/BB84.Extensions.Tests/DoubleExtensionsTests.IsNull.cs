// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class DoubleExtensionsTests
{
	[TestMethod]
	[DataRow(1.67d, false)]
	[DataRow(null, true)]
	public void IsNullTest(double? value, bool expected)
		=> Assert.AreEqual(expected, value.IsNull());
}
