// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class ObjectExtensionsTests
{
	[TestMethod]
	[DataRow(null, false)]
	[DataRow("", true)]
	[DataRow("test", true)]
	[DataRow(0, true)]
	[DataRow(1f, true)]
	[DataRow(1.0d, true)]
	[DataRow(1L, true)]
	[DataRow(true, true)]
	public void IsNotNullTest(object value, bool expected)
		=> Assert.AreEqual(expected, value.IsNotNull());
}
