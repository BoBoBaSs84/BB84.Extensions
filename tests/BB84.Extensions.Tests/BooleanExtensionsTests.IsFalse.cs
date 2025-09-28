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
	[DataRow(false, true)]
	public void IsFalseTest(bool value, bool expected)
		=> Assert.AreEqual(expected, value.IsFalse());

	[TestMethod]
	[DataRow(true, false)]
	[DataRow(false, true)]
	[DataRow(null, false)]
	public void NullableIsFalseTest(bool? value, bool expected)
		=> Assert.AreEqual(expected, value.IsFalse());
}
