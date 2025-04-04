// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

[TestClass]
public sealed partial class DateTimeExtensionTests
{
	public static IEnumerable<object[]> GetStartOfWeekTestData()
	{
		yield return new object[] { new DateTime(2023, 9, 5), new DateTime(2023, 9, 4) };
		yield return new object[] { new DateTime(2023, 9, 6), new DateTime(2023, 9, 4) };
		yield return new object[] { new DateTime(2023, 9, 7), new DateTime(2023, 9, 4) };
		yield return new object[] { new DateTime(2023, 9, 8), new DateTime(2023, 9, 4) };
		yield return new object[] { new DateTime(2023, 9, 9), new DateTime(2023, 9, 4) };
	}

	public static IEnumerable<object[]> GetEndOfWeekTestData()
	{
		yield return new object[] { new DateTime(2023, 9, 5), new DateTime(2023, 9, 10) };
		yield return new object[] { new DateTime(2023, 9, 6), new DateTime(2023, 9, 10) };
		yield return new object[] { new DateTime(2023, 9, 7), new DateTime(2023, 9, 10) };
		yield return new object[] { new DateTime(2023, 9, 8), new DateTime(2023, 9, 10) };
		yield return new object[] { new DateTime(2023, 9, 9), new DateTime(2023, 9, 10) };
	}

	public static IEnumerable<object[]> GetStartOfMonthTestData()
	{
		yield return new object[] { new DateTime(2023, 9, 5), new DateTime(2023, 9, 1) };
		yield return new object[] { new DateTime(2023, 9, 6), new DateTime(2023, 9, 1) };
		yield return new object[] { new DateTime(2023, 9, 7), new DateTime(2023, 9, 1) };
		yield return new object[] { new DateTime(2023, 9, 8), new DateTime(2023, 9, 1) };
		yield return new object[] { new DateTime(2023, 9, 9), new DateTime(2023, 9, 1) };
	}

	public static IEnumerable<object[]> GetEndOfMonthTestData()
	{
		yield return new object[] { new DateTime(2023, 9, 5), new DateTime(2023, 9, 30) };
		yield return new object[] { new DateTime(2023, 9, 6), new DateTime(2023, 9, 30) };
		yield return new object[] { new DateTime(2023, 9, 7), new DateTime(2023, 9, 30) };
		yield return new object[] { new DateTime(2023, 9, 8), new DateTime(2023, 9, 30) };
		yield return new object[] { new DateTime(2023, 9, 9), new DateTime(2023, 9, 30) };
	}

	public static IEnumerable<object[]> GetStartOfYearTestData()
	{
		yield return new object[] { new DateTime(2023, 9, 5), new DateTime(2023, 1, 1) };
		yield return new object[] { new DateTime(2023, 4, 6), new DateTime(2023, 1, 1) };
		yield return new object[] { new DateTime(2022, 9, 7), new DateTime(2022, 1, 1) };
		yield return new object[] { new DateTime(2013, 9, 8), new DateTime(2013, 1, 1) };
		yield return new object[] { new DateTime(2024, 12, 31), new DateTime(2024, 1, 1) };
	}

	public static IEnumerable<object[]> GetEndOfYearTestData()
	{
		yield return new object[] { new DateTime(2023, 9, 5), new DateTime(2023, 12, 31) };
		yield return new object[] { new DateTime(2023, 5, 6), new DateTime(2023, 12, 31) };
		yield return new object[] { new DateTime(2021, 1, 7), new DateTime(2021, 12, 31) };
		yield return new object[] { new DateTime(2022, 12, 8), new DateTime(2022, 12, 31) };
		yield return new object[] { new DateTime(2024, 4, 9), new DateTime(2024, 12, 31) };
	}

	public static IEnumerable<object[]> GetStartOfFiscalYearTestData()
	{
		yield return new object[] { new DateTime(2001, 1, 1), 10, new DateTime(2000, 10, 1) };
		yield return new object[] { new DateTime(2023, 4, 6), 7, new DateTime(2022, 7, 1) };
		yield return new object[] { new DateTime(2022, 9, 7), 1, new DateTime(2022, 1, 1) };
		yield return new object[] { new DateTime(2013, 9, 8), 2, new DateTime(2013, 2, 1) };
		yield return new object[] { new DateTime(2024, 12, 31), 4, new DateTime(2024, 4, 1) };
	}

	public static IEnumerable<object[]> GetEndOfFiscalYearTestData()
	{
		yield return new object[] { new DateTime(2001, 1, 1), 10, new DateTime(2001, 9, 30) };
		yield return new object[] { new DateTime(2022, 11, 6), 7, new DateTime(2023, 6, 30) };
		yield return new object[] { new DateTime(2022, 9, 7), 1, new DateTime(2022, 12, 31) };
		yield return new object[] { new DateTime(2013, 9, 8), 2, new DateTime(2014, 1, 31) };
		yield return new object[] { new DateTime(2024, 12, 31), 4, new DateTime(2025, 3, 31) };
	}

	public static IEnumerable<object[]> GetWeekOfYearTestData()
	{
		yield return new object[] { new DateTime(2000, 3, 31), 13 };
		yield return new object[] { new DateTime(1900, 5, 31), 22 };
		yield return new object[] { new DateTime(2100, 12, 31), 52 };
		yield return new object[] { new DateTime(2200, 10, 31), 44 };
		yield return new object[] { new DateTime(2300, 8, 31), 35 };
	}
}
