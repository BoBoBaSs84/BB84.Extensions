// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class DateTimeExtensionTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetEndOfFiscalYearTestData), DynamicDataSourceType.Method)]
	public void EndOfFiscalYearTest(DateTime value, int startMonth, DateTime expected)
		=> Assert.AreEqual(expected, value.EndOfFiscalYear(startMonth));


	[TestMethod]
	[DataTestMethod, DataRow(0), DataRow(13)]
	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void EndOfFiscalYearExceptionTest(int startMonth)
		=> new DateTime(2000, 1, 1).EndOfFiscalYear(startMonth);
}
