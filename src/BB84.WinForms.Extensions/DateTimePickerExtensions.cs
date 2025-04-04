﻿// Copyright: 2023 Robert Peter Meyer
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
	/// Binds the <see cref="Control.Enabled"/> property to the specified data source.
	/// </summary>
	/// <param name="dateTimePicker">The <see cref="DateTimePicker"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="DateTimePicker"/> control instance, so that multiple calls can be chained.</returns>
	public static DateTimePicker WithEnabledBinding(this DateTimePicker dateTimePicker, object dataSource, string dataMember)
	{
		dateTimePicker.DataBindings.Add(nameof(dateTimePicker.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return dateTimePicker;
	}

	/// <summary>
	/// Binds the <see cref="DateTimePicker.MaxDate"/> property to the specified data source.
	/// </summary>
	/// <param name="dateTimePicker">The <see cref="DateTimePicker"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="DateTimePicker"/> control instance, so that multiple calls can be chained.</returns>
	public static DateTimePicker WithMaxDateBinding(this DateTimePicker dateTimePicker, object dataSource, string dataMember)
	{
		dateTimePicker.DataBindings.Add(nameof(dateTimePicker.MaxDate), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return dateTimePicker;
	}

	/// <summary>
	/// Binds the <see cref="DateTimePicker.MinDate"/> property to the specified data source.
	/// </summary>
	/// <param name="dateTimePicker">The <see cref="DateTimePicker"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="DateTimePicker"/> control instance, so that multiple calls can be chained.</returns>
	public static DateTimePicker WithMinDateBinding(this DateTimePicker dateTimePicker, object dataSource, string dataMember)
	{
		dateTimePicker.DataBindings.Add(nameof(dateTimePicker.MinDate), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return dateTimePicker;
	}

	/// <summary>
	/// Binds the <see cref="DateTimePicker.Value"/> property to the specified data source.
	/// </summary>
	/// <param name="dateTimePicker">The <see cref="DateTimePicker"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="DateTimePicker"/> control instance, so that multiple calls can be chained.</returns>
	public static DateTimePicker WithValueBinding(this DateTimePicker dateTimePicker, object dataSource, string dataMember)
	{
		dateTimePicker.DataBindings.Add(nameof(dateTimePicker.Value), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return dateTimePicker;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property to the specified data source.
	/// </summary>
	/// <param name="dateTimePicker">The <see cref="DateTimePicker"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="DateTimePicker"/> control instance, so that multiple calls can be chained.</returns>
	public static DateTimePicker WithVisibleBinding(this DateTimePicker dateTimePicker, object dataSource, string dataMember)
	{
		dateTimePicker.DataBindings.Add(nameof(dateTimePicker.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return dateTimePicker;
	}
}
