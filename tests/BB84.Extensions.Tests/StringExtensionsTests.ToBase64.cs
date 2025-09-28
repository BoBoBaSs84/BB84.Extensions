// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Text;

namespace BB84.Extensions.Tests;

public sealed partial class StringExtensionsTests
{
	[TestMethod]
	[DataRow("VW5pdFRlc3Q=", "UnitTest")]
	[DataRow("", "")]
	public void ToBase64Test(string expected, string value)
		=> Assert.AreEqual(expected, value.ToBase64(Encoding.UTF8));
}
