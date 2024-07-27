namespace BB84.Extensions;

public static partial class DateTimeExtensions
{
	/// <summary>
	/// Returns the last day of the year using the specified date.
	/// </summary>
	/// <param name="dateTime">The date time value to work with.</param>
	/// <returns>The date of the last day of the year.</returns>
	public static DateTime EndOfYear(this DateTime dateTime)
		=> StartOfYear(dateTime).AddYears(1).AddDays(-1);
}
