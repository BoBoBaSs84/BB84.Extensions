// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.Extensions;

namespace BB84.Extensions.Tests;

public sealed partial class EnumeratorExtensionsTests
{
	[TestMethod]
	public void GetValuesTest()
	{
		TestType type = TestType.None;

		IEnumerable<TestType> list = type.GetValues();

		Assert.AreEqual(3, list.Count());
	}
}
