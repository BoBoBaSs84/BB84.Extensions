// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Globalization;

namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for <see cref="DateTime"/> to simplify common date-related calculations,
/// such as determining the start or end of a fiscal year, month, week, or year, as well as calculating
/// the ISO 8601 week of the year.
/// </summary>
/// <remarks>
/// This class includes methods for working with fiscal years, months, weeks, and years, offering
/// functionality such as retrieving the start or end date of these periods. It also provides a
/// method to calculate the ISO 8601-compliant week of the year. These methods are designed to enhance
/// productivity when working with date and time values in .NET applications.
/// </remarks>
public static class DateTimeExtensions
{
	/// <summary>
	/// Calculates the end date of the fiscal year based on the specified start month.
	/// </summary>
	/// <param name="value">The date used to determine the fiscal year.</param>
	/// <param name="startMonth">The month in which the fiscal year starts.</param>
	/// <returns>
	/// A <see cref="DateTime"/> representing the last day of the fiscal year that includes the specified date.
	/// </returns>
	/// <exception cref="ArgumentOutOfRangeException">
	/// Thrown if <paramref name="startMonth"/> is less than 1 or greater than 12.
	/// </exception>
	public static DateTime EndOfFiscalYear(this DateTime value, int startMonth = 10)
	{
		if (startMonth is < 1 or > 12)
			throw new ArgumentOutOfRangeException(nameof(startMonth), "Must be between 1 and 12.");

		DateTime endOfFiscalYear = StartOfFiscalYear(value, startMonth).AddYears(1).AddDays(-1);

		return endOfFiscalYear;
	}

	/// <summary>
	/// Calculates the last day of the month for the specified date time <paramref name="value"/>.
	/// </summary>
	/// <remarks>
	/// This method determines the end of the month by calculating the first day of the next month and
	/// subtracting one day.
	/// </remarks>
	/// <param name="value">The date for which to determine the last day of the month.</param>
	/// <returns>A <see cref="DateTime"/> instance representing the last day of the month.</returns>
	public static DateTime EndOfMonth(this DateTime value)
		=> StartOfMonth(value).AddMonths(1).AddDays(-1);

	/// <summary>
	/// Calculates the end date of the week for the specified <paramref name="value"/>, based on the
	/// given start day of the week.
	/// </summary>
	/// <remarks>
	/// The method assumes a 7-day week and calculates the end of the week by adding six days to the
	/// start of the week. The result is based on the <paramref name="startOfWeek"/> parameter, which
	/// determines the first day of the week.
	/// </remarks>
	/// <param name="value">The date for which to calculate the end of the week.</param>
	/// <param name="startOfWeek">The day considered as the start of the week.</param>
	/// <returns>A <see cref="DateTime"/> instance representing the last day of the week.</returns>
	public static DateTime EndOfWeek(this DateTime value, DayOfWeek startOfWeek = DayOfWeek.Monday)
		=> StartOfWeek(value, startOfWeek).AddDays(6);

	/// <summary>
	/// Calculates the last day of the year for the specified <paramref name="value"/>.
	/// </summary>
	/// <remarks>
	/// This method calculates the end of the year by determining the first day of the next year and
	/// subtracting one day.
	/// </remarks>
	/// <param name="value">The <see cref="DateTime"/> value for which to determine the end of the year.</param>
	/// <returns>
	/// A <see cref="DateTime"/> instance representing the last day of the year.</returns>
	public static DateTime EndOfYear(this DateTime value)
		=> StartOfYear(value).AddYears(1).AddDays(-1);

	/// <summary>
	/// Calculates the start date of the fiscal year based on the specified start month.
	/// </summary>
	/// <param name="value">The date used to determine the fiscal year.</param>
	/// <param name="startMonth">The month in which the fiscal year starts.</param>
	/// <returns>
	/// A <see cref="DateTime"/> representing the first day of the fiscal year that includes the specified date.
	/// </returns>
	/// <exception cref="ArgumentOutOfRangeException">
	/// Thrown if <paramref name="startMonth"/> is less than 1 or greater than 12.
	/// </exception>
	public static DateTime StartOfFiscalYear(this DateTime value, int startMonth = 10)
	{
		if (startMonth is < 1 or > 12)
			throw new ArgumentOutOfRangeException(nameof(startMonth), "Must be between 1 and 12.");

		DateTime startOfFiscalYear = new(value.Year, startMonth, 1);

		return startOfFiscalYear <= value ? startOfFiscalYear : startOfFiscalYear.AddYears(-1);
	}

	/// <summary>
	/// Calculates the first day of the month for the specified <paramref name="value"/>.
	/// </summary>
	/// <param name="value">The date and time for which to determine the start of the month.</param>
	/// <returns>A <see cref="DateTime"/> instance representing the first day of the month.</returns>
	public static DateTime StartOfMonth(this DateTime value)
		=> new(value.Year, value.Month, 1);

	/// <summary>
	/// Calculates the date of the start of the week for the specified <paramref name="value"/>,
	/// using the provided <paramref name="startOfWeek"/> as the first day of the week.
	/// </summary>
	/// <remarks>
	/// This method calculates the start of the week by determining the difference between the specified 
	/// date's day of the week and the provided <paramref name="startOfWeek"/>. The result is adjusted to
	/// ensure it falls within the same week.
	/// </remarks>
	/// <param name="value">The date for which to calculate the start of the week.</param>
	/// <param name="startOfWeek">The day to consider as the first day of the week.</param>
	/// <returns>A <see cref="DateTime"/> instance representing the start of the week.</returns>
	public static DateTime StartOfWeek(this DateTime value, DayOfWeek startOfWeek = DayOfWeek.Monday)
		=> value.AddDays(-1 * (7 + (value.DayOfWeek - startOfWeek)) % 7).Date;

	/// <summary>
	/// Returns a <see cref="DateTime"/> representing the first day of the year for the specified <paramref name="value"/>.
	/// </summary>
	/// <param name="value">The date for which the start of the year is calculated.</param>
	/// <returns>A <see cref="DateTime"/> instance representing the start of the year.</returns>
	public static DateTime StartOfYear(this DateTime value)
		=> new(value.Year, 1, 1);

	/// <summary>
	/// Returns an enumerable collection of dates from the start date to the end date, inclusive.
	/// </summary>
	/// <param name="startValue">The date to start from.</param>
	/// <param name="endValue">The date to end at.</param>
	/// <returns>
	/// An <see cref="IEnumerable{DateTime}"/> containing all dates from <paramref name="startValue"/>
	/// until <paramref name="endValue"/>, inclusive.
	/// </returns>
	/// <exception cref="ArgumentException">
	/// Thrown if <paramref name="endValue"/> is less than <paramref name="startValue"/>.
	/// </exception>
	public static IEnumerable<DateTime> Until(this DateTime startValue, DateTime endValue)
	{
		if (endValue < startValue)
			throw new ArgumentOutOfRangeException(nameof(endValue), "End date must be greater than or equal to start date.");

		for (DateTime date = startValue.Date; date <= endValue.Date; date = date.AddDays(1))
			yield return date;
	}

	/// <summary>
	/// Calculates the week of the year for the specified <paramref name="value"/> according to the ISO 8601 standard.
	/// </summary>
	/// <remarks>
	/// This method uses the <see cref="CultureInfo.InvariantCulture"/> calendar to calculate the week of the year.
	/// If the specified date falls on a Monday, Tuesday, or Wednesday, it adjusts the date forward by three days
	/// to ensure correct week calculation according to the ISO 8601 standard.
	/// </remarks>
	/// <param name="value">The <see cref="DateTime"/> value for which to determine the week of the year.</param>
	/// <returns>
	/// An integer representing the week of the year, based on the ISO 8601 standard, where the first week of the year
	/// is the one containing at least four days and Monday is considered the first day of the week.
	/// </returns>
	public static int WeekOfYear(this DateTime value)
	{
		DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(value);

		if (day is >= DayOfWeek.Monday and <= DayOfWeek.Wednesday)
			value = value.AddDays(3);

		return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(value, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
	}
}
