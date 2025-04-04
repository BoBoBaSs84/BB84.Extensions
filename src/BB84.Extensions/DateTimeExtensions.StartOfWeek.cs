// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

public static partial class DateTimeExtensions
{
	/// <summary>
	/// Returns the first day of the week using the specified date and
	/// the definition of the first day of the week.
	/// </summary>
	/// <param name="dateTime">The date time value to work with.</param>
	/// <param name="startOfWeek">The first day of the week.</param>
	/// <returns>The date of the first day of the week.</returns>
	public static DateTime StartOfWeek(this DateTime dateTime, DayOfWeek startOfWeek = DayOfWeek.Monday)
		=> dateTime.AddDays(-1 * (7 + (dateTime.DayOfWeek - startOfWeek)) % 7).Date;
}
