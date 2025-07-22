// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="Control"/> class to simplify data binding.
/// </summary>
/// <remarks>
/// This class includes methods to bind common properties of a <see cref="Control"/> class, such as
/// <see cref="Control.Enabled"/>, <see cref="Control.Text"/> and <see cref="Control.Visible"/>, to a
/// specified data source. These methods return the same <see cref="Control"/> instance, allowing for
/// method chaining.
/// </remarks>
public static class ControlExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property of the specified <see cref="Control"/> to a
	/// property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Enabled"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="control">The <see cref="Control"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="Control"/> class with the binding applied, allowing for method chaining.
	/// </returns>
	public static Control WithEnabledBinding(this Control control, object dataSource, string dataMember)
	{
		control.DataBindings.Add(nameof(control.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return control;
	}

	/// <summary>
	/// Binds the <see cref="Control.Tag"/> property of the specified <see cref="GroupBox"/> to a
	/// property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Tag"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="control">The <see cref="Control"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="Control"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static Control WithTagBinding(this Control control, object dataSource, string dataMember)
	{
		control.DataBindings.Add(nameof(control.Tag), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return control;
	}

	/// <summary>
	/// Binds the <see cref="Control.Text"/> property of the specified <see cref="Control"/> to a
	/// property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Text"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="control">The <see cref="Control"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="Control"/> class with the binding applied, allowing for method chaining.
	/// </returns>
	public static Control WithTextBinding(this Control control, object dataSource, string dataMember)
	{
		control.DataBindings.Add(nameof(control.Text), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return control;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property of the specified <see cref="GroupBox"/> to a
	/// property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Visible"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="control">The <see cref="Control"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="Control"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static Control WithVisibleBinding(this Control control, object dataSource, string dataMember)
	{
		control.DataBindings.Add(nameof(control.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return control;
	}
}
