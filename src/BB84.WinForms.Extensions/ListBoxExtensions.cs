// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Collections;

namespace BB84.WinForms.Extensions;

/// <summary>
/// The extension methods for the <see cref="ListBox"/> control.
/// </summary>
public static class ListBoxExtensions
{
	/// <summary>
	/// Sets the data source for the specified <see cref="ListBox"/> and returns the updated instance.
	/// </summary>
	/// <param name="listBox">The <see cref="ListBox"/> to set the data source for.</param>
	/// <param name="dataSource">The data source to bind to the <see cref="ListBox"/>. Can be any
	/// object that implements <see cref="IEnumerable"/> or other supported data source types.</param>
	/// <returns>
	/// The <see cref="ListBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ListBox WithDataSource(this ListBox listBox, object dataSource)
	{
		listBox.DataSource = dataSource;
		return listBox;
	}

	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property of the specified <see cref="ListBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Enabled"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="listBox">The <see cref="ListBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ListBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ListBox WithEnabledBinding(this ListBox listBox, object dataSource, string dataMember)
	{
		listBox.DataBindings.Add(nameof(listBox.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return listBox;
	}

	/// <summary>
	/// Binds the <see cref="ListBox.SelectedItem"/> property of the specified <see cref="ListBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="ListBox.SelectedItem"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="listBox">The <see cref="ListBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ListBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ListBox WithSelectedItemBinding(this ListBox listBox, object dataSource, string dataMember)
	{
		listBox.DataBindings.Add(nameof(listBox.SelectedItem), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return listBox;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property of the specified <see cref="ListBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Visible"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="listBox">The <see cref="ListBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ListBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ListBox WithVisibleBinding(this ListBox listBox, object dataSource, string dataMember)
	{
		listBox.DataBindings.Add(nameof(listBox.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return listBox;
	}
}
