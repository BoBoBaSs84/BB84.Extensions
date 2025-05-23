// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// The extension methods for the <see cref="DateTimePicker"/> control.
/// </summary>
public static class DateTimePickerExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property of the specified <see cref="DateTimePicker"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Enabled"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="dateTimePicker">The <see cref="DateTimePicker"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="DateTimePicker"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static DateTimePicker WithEnabledBinding(this DateTimePicker dateTimePicker, object dataSource, string dataMember)
	{
		dateTimePicker.DataBindings.Add(nameof(dateTimePicker.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return dateTimePicker;
	}

	/// <summary>
	/// Binds the <see cref="DateTimePicker.MaxDate"/> property of the specified <see cref="DateTimePicker"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="DateTimePicker.MaxDate"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="dateTimePicker">The <see cref="DateTimePicker"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="DateTimePicker"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static DateTimePicker WithMaxDateBinding(this DateTimePicker dateTimePicker, object dataSource, string dataMember)
	{
		dateTimePicker.DataBindings.Add(nameof(dateTimePicker.MaxDate), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return dateTimePicker;
	}

	/// <summary>
	/// Binds the <see cref="DateTimePicker.MinDate"/> property of the specified <see cref="DateTimePicker"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="DateTimePicker.MinDate"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="dateTimePicker">The <see cref="DateTimePicker"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="DateTimePicker"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static DateTimePicker WithMinDateBinding(this DateTimePicker dateTimePicker, object dataSource, string dataMember)
	{
		dateTimePicker.DataBindings.Add(nameof(dateTimePicker.MinDate), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return dateTimePicker;
	}

	/// <summary>
	/// Binds the <see cref="DateTimePicker.Value"/> property of the specified <see cref="DateTimePicker"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="DateTimePicker.Value"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="dateTimePicker">The <see cref="DateTimePicker"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="DateTimePicker"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static DateTimePicker WithValueBinding(this DateTimePicker dateTimePicker, object dataSource, string dataMember)
	{
		dateTimePicker.DataBindings.Add(nameof(dateTimePicker.Value), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return dateTimePicker;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property of the specified <see cref="DateTimePicker"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Visible"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="dateTimePicker">The <see cref="DateTimePicker"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="DateTimePicker"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static DateTimePicker WithVisibleBinding(this DateTimePicker dateTimePicker, object dataSource, string dataMember)
	{
		dateTimePicker.DataBindings.Add(nameof(dateTimePicker.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return dateTimePicker;
	}
}
