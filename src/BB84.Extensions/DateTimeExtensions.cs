// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Globalization;

namespace BB84.Extensions;

/// <summary>
/// The date time extensions class.
/// </summary>
public static class DateTimeExtensions
{
	/// <summary>
	/// Returns the end date of the fiscal year using the specified <paramref name="value"/>
	/// and the definition of the <paramref name="startMonth"/> of the fiscal year.
	/// </summary>
	/// <param name="value">The date time value to work with.</param>
	/// <param name="startMonth">The first month of the fiscal year.</param>
	/// <returns>The end date of the fiscal year.</returns>
	/// <exception cref="ArgumentOutOfRangeException"></exception>
	public static DateTime EndOfFiscalYear(this DateTime value, int startMonth = 10)
	{
		if (startMonth is < 1 or > 12)
			throw new ArgumentOutOfRangeException(nameof(startMonth), "Must be between 1 and 12.");

		DateTime endOfFiscalYear = StartOfFiscalYear(value, startMonth).AddYears(1).AddDays(-1);

		return endOfFiscalYear;
	}

	/// <summary>
	/// Returns the last day of the month using the specified date.
	/// </summary>
	/// <param name="dateTime">The date time value to work with.</param>
	/// <returns>The date of the last day of the month.</returns>
	public static DateTime EndOfMonth(this DateTime dateTime)
		=> StartOfMonth(dateTime).AddMonths(1).AddDays(-1);

	/// <summary>
	/// Returns the last day of the week using the specified date and
	/// the definition of the first day of the week.
	/// </summary>
	/// <param name="dateTime">The date time value to work with.</param>
	/// <param name="startOfWeek">The first day of the week.</param>
	/// <returns>The date of the last day of the week.</returns>
	public static DateTime EndOfWeek(this DateTime dateTime, DayOfWeek startOfWeek = DayOfWeek.Monday)
		=> StartOfWeek(dateTime, startOfWeek).AddDays(6);

	/// <summary>
	/// Returns the last day of the year using the specified date.
	/// </summary>
	/// <param name="dateTime">The date time value to work with.</param>
	/// <returns>The date of the last day of the year.</returns>
	public static DateTime EndOfYear(this DateTime dateTime)
		=> StartOfYear(dateTime).AddYears(1).AddDays(-1);

	/// <summary>
	/// Returns the start date of the fiscal year using the specified date <paramref name="value"/>
	/// and the definition of the <paramref name="startMonth"/> of the fiscal year.
	/// </summary>
	/// <param name="value">The date time value to work with.</param>
	/// <param name="startMonth">The first month of the fiscal year.</param>
	/// <returns>The start date of the fiscal year.</returns>
	/// <exception cref="ArgumentOutOfRangeException"></exception>

	public static DateTime StartOfFiscalYear(this DateTime value, int startMonth = 10)
	{
		if (startMonth is < 1 or > 12)
			throw new ArgumentOutOfRangeException(nameof(startMonth), "Must be between 1 and 12.");

		DateTime startOfFiscalYear = new(value.Year, startMonth, 1);

		return startOfFiscalYear < value ? startOfFiscalYear : startOfFiscalYear.AddYears(-1);
	}

	/// <summary>
	/// Returns the first day of the month using the specified date.
	/// </summary>
	/// <param name="dateTime">The date time value to work with.</param>
	/// <returns>The date of the first day of the month.</returns>
	public static DateTime StartOfMonth(this DateTime dateTime)
		=> new(dateTime.Year, dateTime.Month, 1);

	/// <summary>
	/// Returns the first day of the week using the specified date and
	/// the definition of the first day of the week.
	/// </summary>
	/// <param name="dateTime">The date time value to work with.</param>
	/// <param name="startOfWeek">The first day of the week.</param>
	/// <returns>The date of the first day of the week.</returns>
	public static DateTime StartOfWeek(this DateTime dateTime, DayOfWeek startOfWeek = DayOfWeek.Monday)
		=> dateTime.AddDays(-1 * (7 + (dateTime.DayOfWeek - startOfWeek)) % 7).Date;

	/// <summary>
	/// Returns the first day of the year using the specified date.
	/// </summary>
	/// <param name="dateTime">The date time value to work with.</param>
	/// <returns>The date of the first day of the year.</returns>
	public static DateTime StartOfYear(this DateTime dateTime)
		=> new(dateTime.Year, 1, 1);

	/// <summary>
	/// Returns the week of the year that includes the date in the specified <paramref name="value"/>.
	/// </summary>
	/// <remarks>
	/// The method does conform to ISO 8601.
	/// </remarks>
	/// <param name="value">A date and time value.</param>
	/// <returns>
	/// A positive integer that represents the week of the year that includes the date in the time parameter.
	/// </returns>
	public static int WeekOfYear(this DateTime value)
	{
		DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(value);

		if (day is >= DayOfWeek.Monday and <= DayOfWeek.Wednesday)
			value = value.AddDays(3);

		return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(value, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
	}
}
