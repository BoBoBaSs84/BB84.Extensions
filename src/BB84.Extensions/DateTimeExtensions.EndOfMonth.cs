namespace BB84.Extensions;

public static partial class DateTimeExtensions
{
	/// <summary>
	/// Calculates the last day of the month using the specified date.
	/// </summary>
	/// <param name="dateTime">The date time value to work with.</param>
	/// <returns>The date of the last day of the month.</returns>
	public static DateTime EndOfMonth(this DateTime dateTime)
		=> StartOfMonth(dateTime).AddMonths(1).AddDays(-1);
}
