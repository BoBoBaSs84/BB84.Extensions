using System.Globalization;

namespace BB84.Extensions;

public static partial class DateTimeExtensions
{
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

		if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
			value = value.AddDays(3);

		return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(value, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
	}
}
