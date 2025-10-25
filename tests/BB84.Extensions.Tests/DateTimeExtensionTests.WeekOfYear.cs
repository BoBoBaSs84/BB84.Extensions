// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class DateTimeExtensionTests
{
	[TestMethod]
	[DynamicData(nameof(GetWeekOfYearTestData))]
	public void WeekOfYearTest(DateTime dateTime, int expected)
		=> Assert.AreEqual(expected, dateTime.WeekOfYear());
}
