// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// The extension methods for the <see cref="MaskedTextBox"/> control.
/// </summary>
public static class MaskedTextBoxExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property to the specified data source.
	/// </summary>
	/// <param name="maskedTextBox">The <see cref="MaskedTextBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="TextBox"/> control instance, so that multiple calls can be chained.</returns>
	public static MaskedTextBox WithEnabledBinding(this MaskedTextBox maskedTextBox, object dataSource, string dataMember)
	{
		maskedTextBox.DataBindings.Add(nameof(maskedTextBox.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return maskedTextBox;
	}

	/// <summary>
	/// Binds the <see cref="MaskedTextBox.Text"/> property to the specified data source.
	/// </summary>
	/// <param name="maskedTextBox">The <see cref="MaskedTextBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="MaskedTextBox"/> control instance, so that multiple calls can be chained.</returns>
	public static MaskedTextBox WithTextBinding(this MaskedTextBox maskedTextBox, object dataSource, string dataMember)
	{
		maskedTextBox.DataBindings.Add(nameof(maskedTextBox.Text), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return maskedTextBox;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property to the specified data source.
	/// </summary>
	/// <param name="maskedTextBox">The <see cref="MaskedTextBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="MaskedTextBox"/> control instance, so that multiple calls can be chained.</returns>
	public static MaskedTextBox WithVisibleBinding(this MaskedTextBox maskedTextBox, object dataSource, string dataMember)
	{
		maskedTextBox.DataBindings.Add(nameof(maskedTextBox.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return maskedTextBox;
	}
}
