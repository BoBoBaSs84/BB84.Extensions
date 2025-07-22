// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Collections;

namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="ListControl"/> class to simplify data binding.
/// </summary>
/// <remarks>
/// This class includes methods to bind common properties of a <see cref="ListControl"/> class, such as
/// <see cref="ListControl.DataSource"/>.
/// These methods return the same <see cref="ListControl"/> instance, allowing for method chaining.
/// </remarks>
public static class ListControlExtensions
{
	/// <summary>
	/// Binds the <see cref="ListControl.DataSource"/> property of the specified <see cref="ListControl"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <param name="listControl">The <see cref="ListControl"/> to bind.</param>
	/// <param name="dataSource">
	/// The data source to bind to the <see cref="ListControl.DataSource"/>. Can be any object that
	/// implements <see cref="IEnumerable"/> or other supported data source types.
	/// </param>
	/// <returns>
	/// The <see cref="ListControl"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ListControl WithDataSourceBinding(this ListControl listControl, object dataSource)
	{
		listControl.DataSource = dataSource;
		return listControl;
	}

	/// <summary>
	/// Binds the <see cref="ListControl.SelectedValue"/> property of the specified <see cref="ListControl"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="ListControl.SelectedValue"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="listControl">The <see cref="ListControl"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ListControl"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ListControl WithSelectedValueBinding(this ListControl listControl, object dataSource, string dataMember)
	{
		listControl.DataBindings.Add(nameof(listControl.SelectedValue), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return listControl;
	}
}
