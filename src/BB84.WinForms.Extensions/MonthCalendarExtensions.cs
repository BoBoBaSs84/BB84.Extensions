// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// The extension methods for the <see cref="MonthCalendar"/> control.
/// </summary>
public static class MonthCalendarExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property of the specified <see cref="MonthCalendar"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Enabled"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="monthCalendar">The <see cref="MonthCalendar"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="MonthCalendar"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static MonthCalendar WithEnabledBinding(this MonthCalendar monthCalendar, object dataSource, string dataMember)
	{
		monthCalendar.DataBindings.Add(nameof(monthCalendar.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return monthCalendar;
	}

	/// <summary>
	/// Binds the <see cref="MonthCalendar.SelectionStart"/> property of the specified <see cref="MonthCalendar"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="MonthCalendar.SelectionStart"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="monthCalendar">The <see cref="MonthCalendar"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="MonthCalendar"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static MonthCalendar WithSelectionStartBinding(this MonthCalendar monthCalendar, object dataSource, string dataMember)
	{
		monthCalendar.DataBindings.Add(nameof(monthCalendar.SelectionStart), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return monthCalendar;
	}

	/// <summary>
	/// Binds the <see cref="MonthCalendar.SelectionEnd"/> property of the specified <see cref="MonthCalendar"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="MonthCalendar.SelectionEnd"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="monthCalendar">The <see cref="MonthCalendar"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="MonthCalendar"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static MonthCalendar WithSelectionEndBinding(this MonthCalendar monthCalendar, object dataSource, string dataMember)
	{
		monthCalendar.DataBindings.Add(nameof(monthCalendar.SelectionEnd), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return monthCalendar;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property of the specified <see cref="MonthCalendar"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Visible"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="monthCalendar">The <see cref="MonthCalendar"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="MonthCalendar"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static MonthCalendar WithVisibleBinding(this MonthCalendar monthCalendar, object dataSource, string dataMember)
	{
		monthCalendar.DataBindings.Add(nameof(monthCalendar.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return monthCalendar;
	}
}
