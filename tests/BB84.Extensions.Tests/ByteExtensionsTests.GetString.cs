// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public partial class ByteExtensionsTests
{
	[TestMethod]
	[DataRow(new byte[] { 65 }, "A")]
	public void GetStringTest(byte[] inputBuffer, string expected)
		=> Assert.AreEqual(expected, inputBuffer.GetString());
}
