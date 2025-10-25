// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class MonthCalendarExtensionsTests
{
	[TestMethod]
	public void WithSelectionRangeBindingShouldBindSelectionRange()
	{
		var dataSource = new { SelectionRange = new SelectionRange(DateTime.MinValue, DateTime.MaxValue) };
		MonthCalendar monthCalendar = new();

		monthCalendar.WithSelectionRangeBinding(dataSource, nameof(monthCalendar.SelectionRange));

		Assert.HasCount(1, monthCalendar.DataBindings);
		Assert.AreEqual(nameof(monthCalendar.SelectionRange), monthCalendar.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, monthCalendar.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, monthCalendar.DataBindings[0].DataSourceUpdateMode);
	}
}
