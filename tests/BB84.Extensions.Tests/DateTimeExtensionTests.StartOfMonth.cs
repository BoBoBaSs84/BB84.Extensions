// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class DateTimeExtensionTests
{
	[TestMethod]
	[DynamicData(nameof(GetStartOfMonthTestData), DynamicDataSourceType.Method)]
	public void StartOfMonthTest(DateTime value, DateTime expected)
		=> Assert.AreEqual(expected, value.StartOfMonth());
}
