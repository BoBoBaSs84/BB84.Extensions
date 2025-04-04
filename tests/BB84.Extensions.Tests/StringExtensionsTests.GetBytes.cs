// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public partial class StringExtensionsTests
{
	[DataTestMethod]
	[DataRow("A", new byte[] { 65 })]
	public void GetBytesTest(string stringValue, byte[] expected)
		=> Assert.IsTrue(expected.SequenceEqual(stringValue.GetBytes()));
}
