// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class ByteExtensionsTests
{
	[DataTestMethod]
	[DataRow(new byte[] { 85, 110, 105, 116, 84, 101, 115, 116 }, "VW5pdFRlc3Q=")]
	[DataRow(new byte[0], "")]
	public void FromBase64Test(byte[] expected, string value)
		=> Assert.IsTrue(expected.SequenceEqual(value.FromBase64()));
}
