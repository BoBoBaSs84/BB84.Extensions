// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Collections;

namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for binding properties of a <see cref="DataGridView"/> control to a data source,
/// enabling streamlined data binding for common properties such as <see cref="DataGridView.DataSource"/>,
/// <see cref="Control.Enabled"/>, <see cref="Control.Visible"/>, and others.
/// </summary>
/// <remarks>
/// These extension methods simplify the process of binding <see cref="DataGridView"/> properties to a data
/// source by encapsulating the creation of <see cref="Binding"/> objects.
/// Each method returns the same <see cref="DataGridView"/> instance, allowing for method chaining.
/// </remarks>
public static class DataGridViewExtensions
{
	/// <summary>
	/// Sets the data source for the specified <see cref="DataGridView"/> and returns the updated instance.
	/// </summary>
	/// <param name="dataGridView">The <see cref="DataGridView"/> to set the data source for.</param>
	/// <param name="dataSource">The data source to bind to the <see cref="DataGridView.DataSource"/>. Can be any
	/// object that implements <see cref="IEnumerable"/> or other supported data source types.</param>
	/// <returns>
	/// The <see cref="DataGridView"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static DataGridView WithDataSource(this DataGridView dataGridView, object dataSource)
	{
		dataGridView.DataSource = dataSource;
		return dataGridView;
	}

	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property of the specified <see cref="DataGridView"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Enabled"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="dataGridView">The <see cref="DataGridView"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="DataGridView"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static DataGridView WithEnabledBinding(this DataGridView dataGridView, object dataSource, string dataMember)
	{
		dataGridView.DataBindings.Add(nameof(dataGridView.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return dataGridView;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property of the specified <see cref="DataGridView"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Visible"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="dataGridView">The <see cref="DataGridView"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="DataGridView"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static DataGridView WithVisibleBinding(this DataGridView dataGridView, object dataSource, string dataMember)
	{
		dataGridView.DataBindings.Add(nameof(dataGridView.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return dataGridView;
	}
}
