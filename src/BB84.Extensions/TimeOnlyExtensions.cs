// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
#if NET6_0_OR_GREATER
namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for <see cref="TimeOnly"/> to simplify common time-related calculations.
/// </summary>
public static class TimeOnlyExtensions
{
	/// <summary>
	/// Determines whether the specified <paramref name="value"/> falls within the time range
	/// [<paramref name="start"/>, <paramref name="end"/>), where the start is inclusive and the end
	/// is exclusive.
	/// </summary>
	/// <remarks>
	/// When <paramref name="start"/> is less than or equal to <paramref name="end"/>, the range is
	/// treated as a normal (non-midnight-crossing) range. When <paramref name="start"/> is greater
	/// than <paramref name="end"/>, the range is treated as a midnight-crossing range (e.g., 22:00 to
	/// 02:00).
	/// </remarks>
	/// <param name="value">The <see cref="TimeOnly"/> value to check.</param>
	/// <param name="start">The inclusive start of the time range.</param>
	/// <param name="end">The exclusive end of the time range.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is within the range; otherwise,
	/// <see langword="false"/>.
	/// </returns>
	public static bool IsBetween(this TimeOnly value, TimeOnly start, TimeOnly end)
		=> start <= end ? value >= start && value < end : value >= start || value < end;

	/// <summary>
	/// Converts a <see cref="TimeOnly"/> to a <see cref="DateTime"/> by combining it with the specified
	/// <see cref="DateOnly"/>. If no date is provided, the resulting <see cref="DateTime"/> will have the
	/// default date of 0001-01-01.
	/// </summary>
	/// <param name="time">The <see cref="TimeOnly"/> to convert.</param>
	/// <param name="date">The optional <see cref="DateOnly"/> to combine with the time.</param>
	/// <returns>A <see cref="DateTime"/> representing the combined date and time.</returns>
	public static DateTime ToDateTime(this TimeOnly time, DateOnly? date = null) => date is null
			? new DateTime(1, 1, 1, time.Hour, time.Minute, time.Second, time.Millisecond, DateTimeKind.Unspecified)
			: new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, time.Hour, time.Minute, time.Second, time.Millisecond, DateTimeKind.Unspecified);
}
#endif
