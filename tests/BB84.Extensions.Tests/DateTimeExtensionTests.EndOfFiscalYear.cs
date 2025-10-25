// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class DateTimeExtensionTests
{
	[TestMethod]
	[DynamicData(nameof(GetEndOfFiscalYearTestData))]
	public void EndOfFiscalYearTest(DateTime value, int startMonth, DateTime expected)
		=> Assert.AreEqual(expected, value.EndOfFiscalYear(startMonth));


	[TestMethod]
	[DataRow(0), DataRow(13)]
	public void EndOfFiscalYearExceptionTest(int startMonth)
		=> Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => new DateTime(2000, 1, 1).EndOfFiscalYear(startMonth));
}
