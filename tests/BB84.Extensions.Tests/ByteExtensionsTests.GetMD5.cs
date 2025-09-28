// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public partial class ByteExtensionsTests
{
	[TestMethod]
	[DataRow("This is a long test string for testing stuff.", new byte[] { 110, 210, 233, 118, 188, 223, 107, 174, 201, 37, 20, 45, 24, 79, 27, 32 })]
	public void GetMD5Test(string input, byte[] expected)
		=> Assert.IsTrue(input.GetBytes().GetMD5().SequenceEqual(expected));

	[TestMethod]
	[DataRow("This is a long test string for testing stuff.", "6ED2E976BCDF6BAEC925142D184F1B20")]
	[DataRow("This is another long test string for testing stuff.", "6FC0FE279AD9DFF7C2DC0DC7F2087167")]
	public void GetMD5StringTest(string input, string expected)
		=> Assert.AreEqual(expected, input.GetBytes().GetMD5String());
}
