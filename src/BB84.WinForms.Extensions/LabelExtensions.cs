// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="Label"/> control to simplify data binding.
/// </summary>
/// <remarks>
/// This class includes methods to bind common properties of a <see cref="Label"/> control, such as
/// <see cref="Control.Enabled"/>, <see cref="Label.Text"/>, and <see cref="Control.Visible"/>, to a
/// specified data source. These methods return the same <see cref="Label"/> instance, allowing for
/// method chaining.
/// </remarks>
public static class LabelExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property of the specified <see cref="Label"/> to a data source.
	/// </summary>
	/// <remarks>
	/// This method creates a binding between the <see cref="Control.Enabled"/> property and the specified data
	/// member in the data source. The binding updates automatically when the data source changes, using the
	/// <see cref="DataSourceUpdateMode.OnPropertyChanged"/> update mode.
	/// </remarks>
	/// <param name="label">The <see cref="Label"/> control to bind.</param>
	/// <param name="dataSource">The data source object containing the data to bind to.</param>
	/// <param name="dataMember">The name of the property or column in the data source to bind to.</param>
	/// <returns>
	/// The <see cref="Label"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static Label WithEnabledBinding(this Label label, object dataSource, string dataMember)
	{
		label.DataBindings.Add(nameof(label.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return label;
	}

	/// <summary>
	/// Binds the <see cref="Label.Text"/> property of the specified <see cref="Label"/> to a data source.
	/// </summary>
	/// <remarks>
	/// This method creates a binding between the <see cref="Label.Text"/> property and the specified data
	/// member in the data source. The binding updates automatically when the data source changes, using the
	/// <see cref="DataSourceUpdateMode.OnPropertyChanged"/> update mode.
	/// </remarks>
	/// <param name="label">The <see cref="Label"/> control to bind.</param>
	/// <param name="dataSource">The data source object containing the data to bind to.</param>
	/// <param name="dataMember">The name of the property or column in the data source to bind to.</param>
	/// <returns>
	/// The <see cref="Label"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static Label WithTextBinding(this Label label, object dataSource, string dataMember)
	{
		label.DataBindings.Add(nameof(label.Text), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return label;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property of the specified <see cref="Label"/> to a data source.
	/// </summary>
	/// <remarks>
	/// This method creates a binding between the <see cref="Control.Visible"/> property and the specified data
	/// member in the data source. The binding updates automatically when the data source changes, using the
	/// <see cref="DataSourceUpdateMode.OnPropertyChanged"/> update mode.
	/// </remarks>
	/// <param name="label">The <see cref="Label"/> control to bind.</param>
	/// <param name="dataSource">The data source object containing the data to bind to.</param>
	/// <param name="dataMember">The name of the property or column in the data source to bind to.</param>
	/// <returns>
	/// The <see cref="Label"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static Label WithVisibleBinding(this Label label, object dataSource, string dataMember)
	{
		label.DataBindings.Add(nameof(label.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return label;
	}
}
