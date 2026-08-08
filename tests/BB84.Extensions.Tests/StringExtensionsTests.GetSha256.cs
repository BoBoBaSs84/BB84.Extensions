// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Text;

namespace BB84.Extensions.Tests;

public partial class StringExtensionsTests
{
	[TestMethod]
	public void GetSHA256WithUtf8Test()
	{
		string value = "UnitTest";

		string result = value.GetSHA256();

		Assert.AreEqual("9F629BE9A63456097B80045FAD64ED7F49EDECCBD689CF69D8CC8296BB5276F3", result);
	}

	[TestMethod]
	public void GetSHA256WithAsciiTest()
	{
		string value = "UnitTest";

		string result = value.GetSHA256(Encoding.ASCII);

		Assert.AreEqual("9F629BE9A63456097B80045FAD64ED7F49EDECCBD689CF69D8CC8296BB5276F3", result);
	}

	[TestMethod]
	public void GetSHA256WithUnicodeTest()
	{
		string value = "UnitTest";

		string result = value.GetSHA256(Encoding.Unicode);

		Assert.AreEqual("0A499BEAB1F54EF055D81FEFD9F93C28BB9088D2E6D79042D487F73A8D6E7B6B", result);
	}
}
