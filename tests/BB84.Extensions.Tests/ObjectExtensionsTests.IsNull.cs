// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class ObjectExtensionsTests
{
	[DataTestMethod]
	[DataRow(null, true)]
	[DataRow("", false)]
	[DataRow("test", false)]
	[DataRow(0, false)]
	[DataRow(1f, false)]
	[DataRow(1.0d, false)]
	[DataRow(1L, false)]
	[DataRow(true, false)]
	public void IsNullTest(object value, bool expected)
		=> Assert.AreEqual(expected, value.IsNull());
}
