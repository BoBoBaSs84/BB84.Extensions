// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// The extension methods for the <see cref="RadioButton"/> control.
/// </summary>
public static class RadioButtonExtensions
{
	/// <summary>
	/// Binds the <see cref="RadioButton.Checked"/> property to the specified data source.
	/// </summary>
	/// <param name="radioButton">The <see cref="RadioButton"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="RadioButton"/> control instance, so that multiple calls can be chained.</returns>
	public static RadioButton WithCheckedBinding(this RadioButton radioButton, object dataSource, string dataMember)
	{
		radioButton.DataBindings.Add(nameof(radioButton.Checked), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return radioButton;
	}

	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property to the specified data source.
	/// </summary>
	/// <param name="radioButton">The <see cref="RadioButton"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="RadioButton"/> control instance, so that multiple calls can be chained.</returns>
	public static RadioButton WithEnabledBinding(this RadioButton radioButton, object dataSource, string dataMember)
	{
		radioButton.DataBindings.Add(nameof(radioButton.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return radioButton;
	}

	/// <summary>
	/// Binds the <see cref="Control.Text"/> property to the specified data source.
	/// </summary>
	/// <param name="radioButton">The <see cref="RadioButton"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="RadioButton"/> control instance, so that multiple calls can be chained.</returns>
	public static RadioButton WithTextBinding(this RadioButton radioButton, object dataSource, string dataMember)
	{
		radioButton.DataBindings.Add(nameof(radioButton.Text), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return radioButton;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property to the specified data source.
	/// </summary>
	/// <param name="radioButton">The <see cref="RadioButton"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="RadioButton"/> control instance, so that multiple calls can be chained.</returns>
	public static RadioButton WithVisibleBinding(this RadioButton radioButton, object dataSource, string dataMember)
	{
		radioButton.DataBindings.Add(nameof(radioButton.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return radioButton;
	}
}
