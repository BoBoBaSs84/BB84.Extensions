// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for binding properties of a <see cref="ListBox"/> control to a data source,
/// enabling streamlined data binding for common properties such as <see cref="ListBox.SelectedItem"/>,
/// <see cref="ListBox.SelectedIndex"/> and others.
/// </summary>
public static class ListBoxExtensions
{
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
	/// Binds the <see cref="ListBox.SelectedIndex"/> property of the specified <see cref="ListBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="ListBox.SelectedIndex"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="listBox">The <see cref="ListBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ListBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ListBox WithSelectedIndexBinding(this ListBox listBox, object dataSource, string dataMember)
	{
		listBox.DataBindings.Add(nameof(listBox.SelectedIndex), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return listBox;
	}
}
