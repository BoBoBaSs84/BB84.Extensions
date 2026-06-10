// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public partial class ByteExtensionsTests
{
	[TestMethod]
	[DataRow("This is a long test string for testing stuff.", "78AD0FEA85FA4DB12590C0250E28B224DE44C2FE846A10B20632EF586CD31E83")]
	[DataRow("This is another long test string for testing stuff.", "226D150598387B11979B2F6BEE5306275F9EE96D3F30FE3AD3DE9BABF9174DE0")]
	public void GetSHA256StringTest(string input, string expected)
		=> Assert.AreEqual(expected, input.GetBytes().GetSHA256String());
}
