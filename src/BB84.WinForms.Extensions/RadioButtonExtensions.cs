// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="RadioButton"/> control to simplify data binding.
/// </summary>
/// <remarks>
/// This class includes methods to bind common properties of a <see cref="RadioButton"/> control, such as
/// <see cref="RadioButton.Checked"/>, <see cref="Control.Enabled"/>, <see cref="Control.Text"/>, and
/// <see cref="Control.Visible"/>, to a specified data source. These methods return the same <see cref="RadioButton"/>
/// instance, allowing for method chaining.
/// </remarks>
public static class RadioButtonExtensions
{
	/// <summary>
	/// Binds the <see cref="RadioButton.Checked"/> property of the specified <see cref="RadioButton"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="RadioButton.Checked"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="radioButton">The <see cref="RadioButton"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="RadioButton"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static RadioButton WithCheckedBinding(this RadioButton radioButton, object dataSource, string dataMember)
	{
		radioButton.DataBindings.Add(nameof(radioButton.Checked), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return radioButton;
	}

	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property of the specified <see cref="RadioButton"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Enabled"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="radioButton">The <see cref="RadioButton"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="RadioButton"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static RadioButton WithEnabledBinding(this RadioButton radioButton, object dataSource, string dataMember)
	{
		radioButton.DataBindings.Add(nameof(radioButton.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return radioButton;
	}

	/// <summary>
	/// Binds the <see cref="ButtonBase.Text"/> property of the specified <see cref="RadioButton"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="ButtonBase.Text"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="radioButton">The <see cref="RadioButton"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="RadioButton"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static RadioButton WithTextBinding(this RadioButton radioButton, object dataSource, string dataMember)
	{
		radioButton.DataBindings.Add(nameof(radioButton.Text), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return radioButton;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property of the specified <see cref="RadioButton"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Visible"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="radioButton">The <see cref="RadioButton"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="RadioButton"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static RadioButton WithVisibleBinding(this RadioButton radioButton, object dataSource, string dataMember)
	{
		radioButton.DataBindings.Add(nameof(radioButton.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return radioButton;
	}
}
