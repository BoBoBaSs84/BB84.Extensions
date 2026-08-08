// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Collections;

using BB84.WinForms.Extensions.Common;

namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for binding properties of a <see cref="DataGridView"/> control to a data source,
/// enabling streamlined data binding for common properties such as <see cref="DataGridView.DataSource"/> and
/// others.
/// </summary>
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
	/// <exception cref="ArgumentNullException">
	/// Thrown if <paramref name="dataGridView"/> or <paramref name="dataSource"/> is <see langword="null"/>.
	/// </exception>
	public static DataGridView WithDataSourceBinding(this DataGridView dataGridView, object dataSource)
	{
		Guard.ThrowIfNull(dataGridView);
		Guard.ThrowIfNull(dataSource);

		dataGridView.DataSource = dataSource;
		return dataGridView;
	}
}
