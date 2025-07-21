// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Collections;

namespace BB84.WinForms.Extensions;

#if NETFRAMEWORK
/// <summary>
/// Provides extension methods for binding properties of a <see cref="DataGrid"/> control to a data source,
/// enabling streamlined data binding for common properties such as <see cref="DataGrid.DataSource"/> and
/// others.
/// </summary>
public static class DataGridExtensions
{
	/// <summary>
	/// Sets the data source for the specified <see cref="DataGrid"/> and returns the updated instance.
	/// </summary>
	/// <param name="dataGrid">The <see cref="DataGrid"/> to set the data source for.</param>
	/// <param name="dataSource">The data source to bind to the <see cref="DataGrid.DataSource"/>. Can be any
	/// object that implements <see cref="IEnumerable"/> or other supported data source types.</param>
	/// <returns>
	/// The <see cref="DataGrid"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static DataGrid WithDataSourceBinding(this DataGrid dataGrid, object dataSource)
	{
		dataGrid.DataSource = dataSource;
		return dataGrid;
	}
}
#endif
