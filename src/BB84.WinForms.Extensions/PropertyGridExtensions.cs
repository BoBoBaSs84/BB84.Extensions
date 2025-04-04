// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// The extension methods for the <see cref="PropertyGrid"/> control.
/// </summary>
public static class PropertyGridExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property to the specified data source.
	/// </summary>
	/// <param name="propertyGrid">The <see cref="PropertyGrid"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="PropertyGrid"/> control instance, so that multiple calls can be chained.</returns>
	public static PropertyGrid WithEnabledBinding(this PropertyGrid propertyGrid, object dataSource, string dataMember)
	{
		propertyGrid.DataBindings.Add(nameof(propertyGrid.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return propertyGrid;
	}

	/// <summary>
	/// Binds the <see cref="PropertyGrid.SelectedObject"/> property to the specified data source.
	/// </summary>
	/// <param name="propertyGrid">The <see cref="PropertyGrid"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="PropertyGrid"/> control instance, so that multiple calls can be chained.</returns>
	public static PropertyGrid WithSelectedObjectBinding(this PropertyGrid propertyGrid, object dataSource, string dataMember)
	{
		propertyGrid.DataBindings.Add(nameof(propertyGrid.SelectedObject), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return propertyGrid;
	}

	/// <summary>
	/// Binds the <see cref="PropertyGrid.Text"/> property to the specified data source.
	/// </summary>
	/// <param name="propertyGrid">The <see cref="PropertyGrid"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="PropertyGrid"/> control instance, so that multiple calls can be chained.</returns>
	public static PropertyGrid WithTextBinding(this PropertyGrid propertyGrid, object dataSource, string dataMember)
	{
		propertyGrid.DataBindings.Add(nameof(propertyGrid.Text), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return propertyGrid;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property to the specified data source.
	/// </summary>
	/// <param name="propertyGrid">The <see cref="PropertyGrid"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="PropertyGrid"/> control instance, so that multiple calls can be chained.</returns>
	public static PropertyGrid WithVisibleBinding(this PropertyGrid propertyGrid, object dataSource, string dataMember)
	{
		propertyGrid.DataBindings.Add(nameof(propertyGrid.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return propertyGrid;
	}
}
