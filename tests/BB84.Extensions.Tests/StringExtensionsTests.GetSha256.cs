// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public partial class StringExtensionsTests
{
	[TestMethod]
	public void GetSha256Utf8Test()
	{
		string value = "UnitTest";

		string result = value.GetSha256Utf8();

		Assert.AreEqual("9F629BE9A63456097B80045FAD64ED7F49EDECCBD689CF69D8CC8296BB5276F3", result);
	}

	[TestMethod]
	public void GetSha256AsciiTest()
	{
		string value = "UnitTest";

		string result = value.GetSha256Ascii();

		Assert.AreEqual("9F629BE9A63456097B80045FAD64ED7F49EDECCBD689CF69D8CC8296BB5276F3", result);
	}

	[TestMethod]
	public void GetSha256UnicodeTest()
	{
		string value = "UnitTest";

		string result = value.GetSha256Unicode();

		Assert.AreEqual("0A499BEAB1F54EF055D81FEFD9F93C28BB9088D2E6D79042D487F73A8D6E7B6B", result);
	}
}
