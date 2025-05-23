// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="MaskedTextBox"/> control to simplify data binding.
/// </summary>
/// <remarks>
/// These extension methods allow developers to easily bind common properties of a <see cref="MaskedTextBox"/>
/// (such as <see cref="Control.Enabled"/>, <see cref="MaskedTextBox.Text"/>, and <see cref="Control.Visible"/>)
/// to a data source. Each method returns the same <see cref="MaskedTextBox"/> instance, enabling method chaining.
/// </remarks>
public static class MaskedTextBoxExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property of the specified <see cref="MaskedTextBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Enabled"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="maskedTextBox">The <see cref="MaskedTextBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="MaskedTextBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static MaskedTextBox WithEnabledBinding(this MaskedTextBox maskedTextBox, object dataSource, string dataMember)
	{
		maskedTextBox.DataBindings.Add(nameof(maskedTextBox.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return maskedTextBox;
	}

	/// <summary>
	/// Binds the <see cref="MaskedTextBox.Text"/> property of the specified <see cref="MaskedTextBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="MaskedTextBox.Text"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="maskedTextBox">The <see cref="MaskedTextBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="MaskedTextBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static MaskedTextBox WithTextBinding(this MaskedTextBox maskedTextBox, object dataSource, string dataMember)
	{
		maskedTextBox.DataBindings.Add(nameof(maskedTextBox.Text), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return maskedTextBox;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property of the specified <see cref="MaskedTextBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Visible"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="maskedTextBox">The <see cref="MaskedTextBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="MaskedTextBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static MaskedTextBox WithVisibleBinding(this MaskedTextBox maskedTextBox, object dataSource, string dataMember)
	{
		maskedTextBox.DataBindings.Add(nameof(maskedTextBox.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return maskedTextBox;
	}
}
