using System.Globalization;

namespace BB84.Extensions;

public static partial class DateTimeExtensions
{
	/// <summary>
	/// Returns the week of the year that includes the date in the specified <paramref name="dateTime"/> value.
	/// </summary>
	/// <remarks>
	/// The outcome dependes on the <see cref="CultureInfo.CurrentCulture"/> information.
	/// The method does not conform to ISO 8601.
	/// </remarks>
	/// <param name="dateTime">A date and time value.</param>
	/// <returns>
	/// A positive integer that represents the week of the year that includes the date in the time parameter.
	/// </returns>
	public static int WeekOfYear(this DateTime dateTime)
	{
		CultureInfo culture = CultureInfo.CurrentCulture;
		int week = culture.Calendar.GetWeekOfYear(
			time: dateTime,
			rule: culture.DateTimeFormat.CalendarWeekRule,
			firstDayOfWeek: culture.DateTimeFormat.FirstDayOfWeek
			);

		return week;
	}
}
