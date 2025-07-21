// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for binding properties of a <see cref="ComboBox"/> control to a data source,
/// enabling streamlined data binding for common properties such as <see cref="ComboBox.SelectedItem"/>,
/// <see cref="ComboBox.SelectedIndex"/> and others.
/// </summary>
public static class ComboBoxExtensions
{
	/// <summary>
	/// Binds the <see cref="ComboBox.SelectedItem"/> property of the specified <see cref="ComboBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="ComboBox.SelectedItem"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="comboBox">The <see cref="ComboBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ComboBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ComboBox WithSelectedItemBinding(this ComboBox comboBox, object dataSource, string dataMember)
	{
		comboBox.DataBindings.Add(nameof(comboBox.SelectedItem), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return comboBox;
	}

	/// <summary>
	/// Binds the <see cref="ComboBox.SelectedIndex"/> property of the specified <see cref="ComboBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="ComboBox.SelectedIndex"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="comboBox">The <see cref="ComboBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ComboBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ComboBox WithSelectedIndexBinding(this ComboBox comboBox, object dataSource, string dataMember)
	{
		comboBox.DataBindings.Add(nameof(comboBox.SelectedIndex), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return comboBox;
	}
}
