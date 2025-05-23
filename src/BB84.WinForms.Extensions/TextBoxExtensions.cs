// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="TextBox"/> control to simplify data binding.
/// </summary>
/// <remarks>
/// These extension methods allow developers to easily bind common properties of a <see cref="TextBox"/>
/// (such as <see cref="Control.Enabled"/>, <see cref="TextBox.Text"/>, and <see cref="Control.Visible"/>)
/// to a data source. Each method returns the same <see cref="TextBox"/> instance, enabling method chaining.
/// </remarks>
public static class TextBoxExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property of the specified <see cref="TextBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Enabled"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="textBox">The <see cref="TextBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="TextBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static TextBox WithEnabledBinding(this TextBox textBox, object dataSource, string dataMember)
	{
		textBox.DataBindings.Add(nameof(textBox.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return textBox;
	}

	/// <summary>
	/// Binds the <see cref="TextBox.Text"/> property of the specified <see cref="TextBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="TextBox.Text"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="textBox">The <see cref="TextBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="TextBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static TextBox WithTextBinding(this TextBox textBox, object dataSource, string dataMember)
	{
		textBox.DataBindings.Add(nameof(textBox.Text), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return textBox;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property of the specified <see cref="TextBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Visible"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="textBox">The <see cref="TextBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="TextBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static TextBox WithVisibleBinding(this TextBox textBox, object dataSource, string dataMember)
	{
		textBox.DataBindings.Add(nameof(textBox.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return textBox;
	}
}
