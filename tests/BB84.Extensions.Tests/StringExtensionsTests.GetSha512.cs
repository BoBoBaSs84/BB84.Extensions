// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public partial class StringExtensionsTests
{
	[TestMethod]
	public void GetSha512Utf8Test()
	{
		string value = "UnitTest";

		string result = value.GetSha512Utf8();

		Assert.AreEqual("E67958D980D4534131BA29EE59DEF22DF37656D8D433F7AF5667E7E88BC38282325EE4BD278827BC5376466A5F753E0CB8ABF7768EF8B4B819F32A64AA585EBB", result);
	}

	[TestMethod]
	public void GetSha512AsciiTest()
	{
		string value = "UnitTest";

		string result = value.GetSha512Ascii();

		Assert.AreEqual("E67958D980D4534131BA29EE59DEF22DF37656D8D433F7AF5667E7E88BC38282325EE4BD278827BC5376466A5F753E0CB8ABF7768EF8B4B819F32A64AA585EBB", result);
	}

	[TestMethod]
	public void GetSha512UnicodeTest()
	{
		string value = "UnitTest";

		string result = value.GetSha512Unicode();

		Assert.AreEqual("FB2F0779A02DE57B50ABFD2A6F3DBA321A30F371A987D3EB93B7A1D98CD0C9714F166C664028A5E32CC20B4CB82EB9D5CCACBE301C833D824DAF819E49006C9F", result);
	}
}
