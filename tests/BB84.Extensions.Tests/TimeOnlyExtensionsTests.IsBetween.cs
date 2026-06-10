// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
#if NET6_0_OR_GREATER
namespace BB84.Extensions.Tests;

public sealed partial class TimeOnlyExtensionsTests
{
	[TestMethod]
	[DynamicData(nameof(GetIsBetweenTestData))]
	public void IsBetweenTest(TimeOnly value, TimeOnly start, TimeOnly end, bool expected)
		=> Assert.AreEqual(expected, value.IsBetween(start, end));
}
#endif
