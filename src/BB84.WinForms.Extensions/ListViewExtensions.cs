// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for binding properties of a <see cref="ListView"/> control
/// to a data source, enabling streamlined data binding for common properties such as
/// <see cref="Control.Enabled"/> and <see cref="Control.Visible"/>.
/// </summary>
/// <remarks>
/// These extension methods simplify the process of binding <see cref="ListView"/> properties to a data
/// source by encapsulating the creation of <see cref="Binding"/> objects.
/// Each method returns the same <see cref="ListView"/> instance, allowing for method chaining.
/// </remarks>
public static class ListViewExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property of the specified <see cref="ListView"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Enabled"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="listView">The <see cref="ListView"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ListView"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ListView WithEnabledBinding(this ListView listView, object dataSource, string dataMember)
	{
		listView.DataBindings.Add(nameof(listView.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return listView;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property of the specified <see cref="ListView"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Visible"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="listView">The <see cref="ListView"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ListView"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ListView WithVisibleBinding(this ListView listView, object dataSource, string dataMember)
	{
		listView.DataBindings.Add(nameof(listView.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return listView;
	}
}
