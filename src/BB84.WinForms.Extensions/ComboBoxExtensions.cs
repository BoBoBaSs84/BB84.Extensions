﻿// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Collections;

namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for binding properties of a <see cref="ComboBox"/> control to a data source,
/// enabling streamlined data binding for common properties such as <see cref="ComboBox.DataSource"/>,
/// <see cref="Control.Enabled"/>, <see cref="Control.Visible"/>, and others.
/// </summary>
/// <remarks>
/// These extension methods simplify the process of binding <see cref="ComboBox"/> properties to a data
/// source by encapsulating the creation of <see cref="Binding"/> objects.
/// Each method returns the same <see cref="ComboBox"/> instance, allowing for method chaining.
/// </remarks>
public static class ComboBoxExtensions
{
	/// <summary>
	/// Sets the data source for the specified <see cref="ComboBox"/> and returns the updated instance.
	/// </summary>
	/// <param name="comboBox">The <see cref="ComboBox"/> to set the data source for.</param>
	/// <param name="dataSource">The data source to bind to the <see cref="ComboBox.DataSource"/>. Can be any
	/// object that implements <see cref="IEnumerable"/> or other supported data source types.</param>
	/// <returns>
	/// The <see cref="ComboBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ComboBox WithDataSource(this ComboBox comboBox, object dataSource)
	{
		comboBox.DataSource = dataSource;
		return comboBox;
	}

	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property of the specified <see cref="ComboBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Enabled"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="comboBox">The <see cref="ComboBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ComboBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ComboBox WithEnabledBinding(this ComboBox comboBox, object dataSource, string dataMember)
	{
		comboBox.DataBindings.Add(nameof(comboBox.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return comboBox;
	}

	/// <summary>
	/// Binds the <see cref="ComboBox.SelectedItem"/> property of the specified <see cref="ComboBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="ComboBox.SelectedItem"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="comboBox">The <see cref="ComboBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ComboBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ComboBox WithSelectedItemBinding(this ComboBox comboBox, object dataSource, string dataMember)
	{
		comboBox.DataBindings.Add(nameof(comboBox.SelectedItem), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return comboBox;
	}

	/// <summary>
	/// Binds the <see cref="ComboBox.SelectedIndex"/> property of the specified <see cref="ComboBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="ComboBox.SelectedIndex"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="comboBox">The <see cref="ComboBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ComboBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ComboBox WithSelectedIndexBinding(this ComboBox comboBox, object dataSource, string dataMember)
	{
		comboBox.DataBindings.Add(nameof(comboBox.SelectedIndex), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return comboBox;
	}

	/// <summary>
	/// Binds the <see cref="ListControl.SelectedValue"/> property of the specified <see cref="ComboBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="ListControl.SelectedValue"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="comboBox">The <see cref="ComboBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ComboBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ComboBox WithSelectedValueBinding(this ComboBox comboBox, object dataSource, string dataMember)
	{
		comboBox.DataBindings.Add(nameof(comboBox.SelectedValue), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return comboBox;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property of the specified <see cref="ComboBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Visible"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="comboBox">The <see cref="ComboBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ComboBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ComboBox WithVisibleBinding(this ComboBox comboBox, object dataSource, string dataMember)
	{
		comboBox.DataBindings.Add(nameof(comboBox.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return comboBox;
	}
}
