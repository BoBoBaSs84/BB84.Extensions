using System.Globalization;

namespace BB84.Extensions;

public static partial class DateTimeExtensions
{
	/// <summary>
	/// Returns the week of the year that includes the date in the specified <paramref name="dateTime"/> value.
	/// </summary>
	/// <remarks>
	/// The outcome dependes on the <paramref name="cultureInfo"/> parameter.
	/// The method does not conform to ISO 8601.
	/// </remarks>
	/// <param name="dateTime">A date and time value.</param>
	/// <param name="cultureInfo">The specific culture to use.</param>
	/// <returns>
	/// A positive integer that represents the week of the year that includes the date in the time parameter.
	/// </returns>
	public static int WeekOfYear(this DateTime dateTime, CultureInfo? cultureInfo = null)
	{
		cultureInfo ??= CultureInfo.InvariantCulture;
		int week = cultureInfo.Calendar.GetWeekOfYear(
			time: dateTime,
			rule: cultureInfo.DateTimeFormat.CalendarWeekRule,
			firstDayOfWeek: cultureInfo.DateTimeFormat.FirstDayOfWeek
			);

		return week;
	}
}
