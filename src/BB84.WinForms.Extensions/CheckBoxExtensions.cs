// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="CheckBox"/> control to simplify data binding.
/// </summary>
/// <remarks>
/// This class includes methods to bind common properties of a <see cref="CheckBox"/> control, such as
/// <see cref="CheckBox.Checked"/>, <see cref="Control.Enabled"/>, <see cref="Control.Text"/>, and
/// <see cref="Control.Visible"/>, to a specified data source. These methods return the same <see cref="CheckBox"/>
/// instance, allowing for method chaining.
/// </remarks>
public static class CheckBoxExtensions
{
	/// <summary>
	/// Binds the <see cref="CheckBox.Checked"/> property of the specified <see cref="CheckBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="CheckBox.Checked"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="checkBox">The <see cref="CheckBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="CheckBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static CheckBox WithCheckedBinding(this CheckBox checkBox, object dataSource, string dataMember)
	{
		checkBox.DataBindings.Add(nameof(checkBox.Checked), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return checkBox;
	}

	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property of the specified <see cref="CheckBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Enabled"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="checkBox">The <see cref="CheckBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="CheckBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static CheckBox WithEnabledBinding(this CheckBox checkBox, object dataSource, string dataMember)
	{
		checkBox.DataBindings.Add(nameof(checkBox.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return checkBox;
	}

	/// <summary>
	/// Binds the <see cref="ButtonBase.Text"/> property of the specified <see cref="CheckBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="ButtonBase.Text"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="checkBox">The <see cref="CheckBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="CheckBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static CheckBox WithTextBinding(this CheckBox checkBox, object dataSource, string dataMember)
	{
		checkBox.DataBindings.Add(nameof(checkBox.Text), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return checkBox;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property of the specified <see cref="CheckBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Visible"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="checkBox">The <see cref="CheckBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="CheckBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static CheckBox WithVisibleBinding(this CheckBox checkBox, object dataSource, string dataMember)
	{
		checkBox.DataBindings.Add(nameof(checkBox.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return checkBox;
	}
}
