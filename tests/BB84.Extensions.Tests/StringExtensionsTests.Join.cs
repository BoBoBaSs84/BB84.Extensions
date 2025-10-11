// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class StringExtensionsTests
{
	[TestMethod]
	[DynamicData(nameof(GetJoinTestData), DynamicDataSourceType.Method)]
	public void JoinTest(string[] values, string separator, string expected)
		=> Assert.AreEqual(expected, values.Join(separator));
}
