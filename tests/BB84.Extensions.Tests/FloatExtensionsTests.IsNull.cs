// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public partial class FloatExtensionsTests
{
	[DataTestMethod]
	[DataRow(1.67f, false)]
	[DataRow(null, true)]
	public void IsNullTest(float? value, bool expected)
		=> Assert.AreEqual(expected, value.IsNull());
}
