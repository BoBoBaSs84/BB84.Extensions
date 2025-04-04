// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class ObjectExtensionsTests
{
	[DataTestMethod("Object to invariant string test")]
	[DataRow("UnitTest", "UnitTest")]
	[DataRow(null, "")]
	public void ToStringInvariant(object value, string expected)
		=> Assert.AreEqual(expected, value.ToStringInvariant());
}
