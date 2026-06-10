// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
#if NET6_0_OR_GREATER
using System.Globalization;

namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for <see cref="DateOnly"/> to simplify common date-related calculations,
/// such as determining the start or end of a month, week, or year, as well as calculating the week of
/// the year.
/// </summary>
/// <remarks>
/// These methods mirror the functionality available in <see cref="DateTimeExtensions"/> and are
/// designed for use with the <see cref="DateOnly"/> type introduced in .NET 6.
/// </remarks>
public static class DateOnlyExtensions
{
	/// <summary>
	/// Calculates the last day of the month for the specified <paramref name="value"/>.
	/// </summary>
	/// <remarks>
	/// This method determines the end of the month by calculating the first day of the next month and
	/// subtracting one day.
	/// </remarks>
	/// <param name="value">The date for which to determine the last day of the month.</param>
	/// <returns>A <see cref="DateOnly"/> instance representing the last day of the month.</returns>
	public static DateOnly EndOfMonth(this DateOnly value)
		=> value.ToDateTime().EndOfMonth().ToDateOnly();

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
	/// <returns>A <see cref="DateOnly"/> instance representing the last day of the week.</returns>
	public static DateOnly EndOfWeek(this DateOnly value, DayOfWeek startOfWeek = DayOfWeek.Monday)
		=> value.ToDateTime().EndOfWeek(startOfWeek).ToDateOnly();

	/// <summary>
	/// Calculates the last day of the year for the specified <paramref name="value"/>.
	/// </summary>
	/// <remarks>
	/// This method calculates the end of the year by determining the first day of the next year and
	/// subtracting one day.
	/// </remarks>
	/// <param name="value">The <see cref="DateOnly"/> value for which to determine the end of the year.</param>
	/// <returns>A <see cref="DateOnly"/> instance representing the last day of the year.</returns>
	public static DateOnly EndOfYear(this DateOnly value)
		=> value.ToDateTime().EndOfYear().ToDateOnly();

	/// <summary>
	/// Calculates the first day of the month for the specified <paramref name="value"/>.
	/// </summary>
	/// <param name="value">The date for which to determine the first day of the month.</param>
	/// <returns>A <see cref="DateOnly"/> instance representing the first day of the month.</returns>
	public static DateOnly StartOfMonth(this DateOnly value)
		=> value.ToDateTime().StartOfMonth().ToDateOnly();

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
	/// <returns>A <see cref="DateOnly"/> instance representing the start of the week.</returns>
	public static DateOnly StartOfWeek(this DateOnly value, DayOfWeek startOfWeek = DayOfWeek.Monday)
		=> value.ToDateTime().StartOfWeek(startOfWeek).ToDateOnly();

	/// <summary>
	/// Returns a <see cref="DateOnly"/> representing the first day of the year for the specified
	/// <paramref name="value"/>.
	/// </summary>
	/// <param name="value">The date for which the start of the year is calculated.</param>
	/// <returns>A <see cref="DateOnly"/> instance representing the start of the year.</returns>
	public static DateOnly StartOfYear(this DateOnly value)
		=> value.ToDateTime().StartOfYear().ToDateOnly();

	/// <summary>
	/// Calculates the week of the year for the specified <paramref name="value"/>.
	/// </summary>
	/// <remarks>
	/// When using the default parameters (<see cref="CalendarWeekRule.FirstFourDayWeek"/> and
	/// <see cref="DayOfWeek.Monday"/>), this method returns an ISO 8601-compliant week number.
	/// </remarks>
	/// <param name="value">The <see cref="DateOnly"/> value for which to determine the week of the year.</param>
	/// <param name="rule">The <see cref="CalendarWeekRule"/> to use for the calculation.</param>
	/// <param name="firstDayOfWeek">The <see cref="DayOfWeek"/> that is considered the first day of the week.</param>
	/// <returns>An integer representing the week of the year.</returns>
	public static int WeekOfYear(this DateOnly value, CalendarWeekRule rule = CalendarWeekRule.FirstFourDayWeek, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
		=> value.ToDateTime().WeekOfYear(rule, firstDayOfWeek);

	/// <summary>
	/// Converts a <see cref="DateOnly"/> to a <see cref="DateTime"/> by combining it with the specified
	/// <see cref="TimeOnly"/>. If no time is provided, the resulting <see cref="DateTime"/> will have the
	/// default time of 00:00:00.000.
	/// </summary>
	/// <param name="date">The <see cref="DateOnly"/> to convert.</param>
	/// <param name="time">The optional <see cref="TimeOnly"/> to combine with the date.</param>
	/// <returns>A <see cref="DateTime"/> representing the combined date and time.</returns>
	public static DateTime ToDateTime(this DateOnly date, TimeOnly? time = null) => time is null
			? new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0, DateTimeKind.Unspecified)
			: new DateTime(date.Year, date.Month, date.Day, time.Value.Hour, time.Value.Minute, time.Value.Second, time.Value.Millisecond, DateTimeKind.Unspecified);
}
#endif
