// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class StringExtensionsTests
{
	[TestMethod]
	public void EqualsCaseSensitiveTest()
	{
		string stringValue = "UnitTest";

		bool result = stringValue.EqualsCaseSensitive("unittest");

		Assert.IsFalse(result);
	}

	[TestMethod]
	public void EqualsIgnoreCaseTest()
	{
		string stringValue = "UnitTest";

		bool result = stringValue.EqualsIgnoreCase("unittest");

		Assert.IsTrue(result);
	}
}
