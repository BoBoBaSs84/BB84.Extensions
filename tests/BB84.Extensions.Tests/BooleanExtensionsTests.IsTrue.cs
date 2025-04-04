// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public partial class BooleanExtensionsTests
{
	[DataTestMethod]
	[DataRow(true, true)]
	[DataRow(false, false)]
	public void IsTrueTest(bool value, bool expected)
		=> Assert.AreEqual(expected, value.IsTrue());

	[DataTestMethod]
	[DataRow(true, true)]
	[DataRow(false, false)]
	[DataRow(null, false)]
	public void NullableIsTrueTest(bool? value, bool expected)
		=> Assert.AreEqual(expected, value.IsTrue());
}
