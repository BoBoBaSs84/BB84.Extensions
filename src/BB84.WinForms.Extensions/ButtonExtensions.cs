// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="Button"/> control to simplify data binding.
/// </summary>
/// <remarks>
/// This class includes methods to bind common properties of a <see cref="Button"/> control, such as
/// <see cref="Control.Enabled"/>, <see cref="Control.Text"/>, and <see cref="Control.Visible"/>, to a
/// specified data source. These methods return the same <see cref="Button"/> instance, allowing for
/// method chaining.
/// </remarks>
public static class ButtonExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property of the specified <see cref="Button"/> to a property in the provided data
	/// source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the <see cref="Control.Enabled"/> property whenever the bound
	/// property in the data source changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="button">The <see cref="Button"/> control to bind.</param>
	/// <param name="dataSource">The data source object containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property in the data source to bind to the <see cref="Control.Enabled"/> property.</param>
	/// <returns>
	/// The <see cref="Button"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static Button WithEnabledBinding(this Button button, object dataSource, string dataMember)
	{
		button.DataBindings.Add(nameof(button.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return button;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property of the specified <see cref="Button"/> to a property in the provided data
	/// source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the <see cref="Control.Visible"/> property whenever the bound
	/// property in the data source changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="button">The <see cref="Button"/> control to bind.</param>
	/// <param name="dataSource">The data source object containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property in the data source to bind to the <see cref="Control.Visible"/> property.</param>
	/// <returns>
	/// The <see cref="Button"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static Button WithVisibleBinding(this Button button, object dataSource, string dataMember)
	{
		button.DataBindings.Add(nameof(button.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return button;
	}

	/// <summary>
	/// Binds the <see cref="Control.Text"/> property of the specified <see cref="Button"/> to a property in the provided data
	/// source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the <see cref="Control.Text"/> property whenever the bound
	/// property in the data source changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="button">The <see cref="Button"/> control to bind.</param>
	/// <param name="dataSource">The data source object containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property in the data source to bind to the <see cref="Control.Text"/> property.</param>
	/// <returns>
	/// The <see cref="Button"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static Button WithTextBinding(this Button button, object dataSource, string dataMember)
	{
		button.DataBindings.Add(nameof(button.Text), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return button;
	}
}
