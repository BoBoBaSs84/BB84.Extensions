// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

public static partial class DateTimeExtensions
{
	/// <summary>
	/// Returns the last day of the month using the specified date.
	/// </summary>
	/// <param name="dateTime">The date time value to work with.</param>
	/// <returns>The date of the last day of the month.</returns>
	public static DateTime EndOfMonth(this DateTime dateTime)
		=> StartOfMonth(dateTime).AddMonths(1).AddDays(-1);
}
