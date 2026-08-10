// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.WinForms.Extensions.Tests.Common;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class MonthCalendarExtensionsTests
{
	[TestMethod]
	public void WithSelectionRangeBindingShouldBindSelectionRange()
	{
		var dataSource = new { SelectionRange = new SelectionRange(DateTime.MinValue, DateTime.MaxValue) };
		using MonthCalendar monthCalendar = new();

		monthCalendar.WithSelectionRangeBinding(dataSource, nameof(monthCalendar.SelectionRange));

		BindingAssert.IsSingleBinding(monthCalendar, nameof(monthCalendar.SelectionRange), dataSource);
	}
}
