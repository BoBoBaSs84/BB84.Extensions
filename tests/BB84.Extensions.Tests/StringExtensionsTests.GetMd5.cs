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
	public void GetMD5WithUtf8Test()
	{
		string value = "UnitTest";

		string result = value.GetMD5();

		Assert.AreEqual("37ADC7DB47085615AF6389C9C50AF7B9", result);
	}

	[TestMethod]
	public void GetMD5WithUnicodeTest()
	{
		string value = "UnitTest";

		string result = value.GetMD5(Encoding.Unicode);

		Assert.AreEqual("000C23A22CE00D7163E8FF10A23FCDC3", result);
	}

	[TestMethod]
	public void GetMD5WithAsciiTest()
	{
		string value = "UnitTest";

		string result = value.GetMD5(Encoding.ASCII);

		Assert.AreEqual("37ADC7DB47085615AF6389C9C50AF7B9", result);
	}
}
