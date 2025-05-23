// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="PropertyGrid"/> control to simplify data binding.
/// </summary>
/// <remarks>
/// This class includes methods to bind common properties of a <see cref="PropertyGrid"/> control, such as
/// <see cref="Control.Enabled"/>, <see cref="PropertyGrid.SelectedObject"/>, <see cref="Control.Visible"/>,
/// and <see cref="Control.Text"/>, to a specified data source. These methods return the same
/// <see cref="PropertyGrid"/> instance, enabling method chaining for cleaner and more concise code.
/// </remarks>
public static class PropertyGridExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property of the specified <see cref="PropertyGrid"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Enabled"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="propertyGrid">The <see cref="PropertyGrid"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="PropertyGrid"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static PropertyGrid WithEnabledBinding(this PropertyGrid propertyGrid, object dataSource, string dataMember)
	{
		propertyGrid.DataBindings.Add(nameof(propertyGrid.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return propertyGrid;
	}

	/// <summary>
	/// Binds the <see cref="PropertyGrid.SelectedObject"/> property of the specified <see cref="PropertyGrid"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="PropertyGrid.SelectedObject"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="propertyGrid">The <see cref="PropertyGrid"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="PropertyGrid"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static PropertyGrid WithSelectedObjectBinding(this PropertyGrid propertyGrid, object dataSource, string dataMember)
	{
		propertyGrid.DataBindings.Add(nameof(propertyGrid.SelectedObject), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return propertyGrid;
	}

	/// <summary>
	/// Binds the <see cref="PropertyGrid.Text"/> property of the specified <see cref="PropertyGrid"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="PropertyGrid.Text"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="propertyGrid">The <see cref="PropertyGrid"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="PropertyGrid"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static PropertyGrid WithTextBinding(this PropertyGrid propertyGrid, object dataSource, string dataMember)
	{
		propertyGrid.DataBindings.Add(nameof(propertyGrid.Text), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return propertyGrid;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property of the specified <see cref="PropertyGrid"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Visible"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="propertyGrid">The <see cref="PropertyGrid"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="PropertyGrid"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static PropertyGrid WithVisibleBinding(this PropertyGrid propertyGrid, object dataSource, string dataMember)
	{
		propertyGrid.DataBindings.Add(nameof(propertyGrid.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return propertyGrid;
	}
}
