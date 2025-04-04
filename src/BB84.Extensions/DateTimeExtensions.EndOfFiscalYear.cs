// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

public static partial class DateTimeExtensions
{
	/// <summary>
	/// Returns the end date of the fiscal year using the specified <paramref name="value"/>
	/// and the definition of the <paramref name="startMonth"/> of the fiscal year.
	/// </summary>
	/// <param name="value">The date time value to work with.</param>
	/// <param name="startMonth">The first month of the fiscal year.</param>
	/// <returns>The end date of the fiscal year.</returns>
	/// <exception cref="ArgumentOutOfRangeException"></exception>
	public static DateTime EndOfFiscalYear(this DateTime value, int startMonth = 10)
	{
		if (startMonth is < 1 or > 12)
			throw new ArgumentOutOfRangeException(nameof(startMonth), "Must be between 1 and 12.");

		DateTime endOfFiscalYear = StartOfFiscalYear(value, startMonth).AddYears(1).AddDays(-1);

		return endOfFiscalYear;
	}
}
