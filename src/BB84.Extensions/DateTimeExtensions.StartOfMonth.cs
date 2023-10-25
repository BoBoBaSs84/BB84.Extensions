namespace BB84.Extensions;

public static partial class DateTimeExtensions
{
	/// <summary>
	/// Calculates the first day of the month using the specified date.
	/// </summary>
	/// <param name="dateTime">The date time value to work with.</param>
	/// <returns>The date of the first day of the month.</returns>
	public static DateTime StartOfMonth(this DateTime dateTime)
		=> new(dateTime.Year, dateTime.Month, 1);
}
