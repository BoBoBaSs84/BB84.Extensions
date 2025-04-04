// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public partial class StringExtensionsTests
{
	[TestMethod]
	public void GetMd5Utf8Test()
	{
		string value = "UnitTest";

		string result = value.GetMd5Utf8();

		Assert.AreEqual("37ADC7DB47085615AF6389C9C50AF7B9", result);
	}

	[TestMethod]
	public void GetMd5UnicodeTest()
	{
		string value = "UnitTest";

		string result = value.GetMd5Unicode();

		Assert.AreEqual("000C23A22CE00D7163E8FF10A23FCDC3", result);
	}

	[TestMethod]
	public void GetMd5AsciiTest()
	{
		string value = "UnitTest";

		string result = value.GetMd5Ascii();

		Assert.AreEqual("37ADC7DB47085615AF6389C9C50AF7B9", result);
	}
}
