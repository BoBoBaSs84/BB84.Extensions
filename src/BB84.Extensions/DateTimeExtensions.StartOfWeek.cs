namespace BB84.Extensions;

public static partial class DateTimeExtensions
{
	/// <summary>
	/// Calculates the first day of the week using the specified date and
	/// the definition of the first day of the week.
	/// </summary>
	/// <param name="dateTime">The date time value to work with.</param>
	/// <param name="startOfWeek">The first day of the week.</param>
	/// <returns>The date of the first day of the week.</returns>
	public static DateTime StartOfWeek(this DateTime dateTime, DayOfWeek startOfWeek = DayOfWeek.Monday)
		=> dateTime.AddDays(-1 * (7 + (dateTime.DayOfWeek - startOfWeek)) % 7).Date;
}
