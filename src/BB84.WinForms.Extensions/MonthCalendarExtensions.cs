// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="MonthCalendar"/> class to simplify data binding.
/// </summary>
/// <remarks>
/// This class includes methods to bind common properties of a <see cref="MonthCalendar"/> class,
/// such as <see cref="MonthCalendar.SelectionRange"/>. 
/// These methods return the same <see cref="MonthCalendar"/> instance, allowing for method chaining.
/// </remarks>
public static class MonthCalendarExtensions
{
	/// <summary>
	/// Binds the <see cref="MonthCalendar.SelectionRange"/> property of the specified <see cref="MonthCalendar"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="MonthCalendar.SelectionRange"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="monthCalendar">The <see cref="MonthCalendar"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="MonthCalendar"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static MonthCalendar WithSelectionRangeBinding(this MonthCalendar monthCalendar, object dataSource, string dataMember)
	{
		monthCalendar.DataBindings.Add(nameof(monthCalendar.SelectionRange), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return monthCalendar;
	}
}
