namespace BB84.Extensions;

public static partial class DateTimeExtensions
{
	/// <summary>
	/// Returns the first day of the year using the specified date.
	/// </summary>
	/// <param name="dateTime">The date time value to work with.</param>
	/// <returns>The date of the first day of the year.</returns>
	public static DateTime StartOfYear(this DateTime dateTime)
		=> new(dateTime.Year, 1, 1);
}
