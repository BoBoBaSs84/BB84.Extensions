// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// The extension methods for the <see cref="Button"/> control.
/// </summary>
public static class ButtonExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property to the specified data source.
	/// </summary>
	/// <param name="button">The <see cref="Button"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="Button"/> control instance, so that multiple calls can be chained.</returns>
	public static Button WithEnabledBinding(this Button button, object dataSource, string dataMember)
	{
		button.DataBindings.Add(nameof(button.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return button;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property to the specified data source.
	/// </summary>
	/// <param name="button">The <see cref="Button"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="Button"/> control instance, so that multiple calls can be chained.</returns>
	public static Button WithVisibleBinding(this Button button, object dataSource, string dataMember)
	{
		button.DataBindings.Add(nameof(button.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return button;
	}
}
