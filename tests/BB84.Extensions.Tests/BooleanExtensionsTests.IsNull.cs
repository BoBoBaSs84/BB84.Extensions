// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public partial class BooleanExtensionsTests
{
	[TestMethod]
	[DataRow(true, false)]
	[DataRow(false, false)]
	[DataRow(null, true)]
	public void IsNullTest(bool? value, bool expected)
		=> Assert.AreEqual(expected, value.IsNull());
}
