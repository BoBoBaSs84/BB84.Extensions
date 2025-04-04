// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class EnumeratorExtensionsTests
{
	[TestMethod]
	public void GetIntTest()
	{
		TestType type = TestType.Two;

		int value = type.GetInt();

		Assert.AreEqual(2, value);
	}
}
