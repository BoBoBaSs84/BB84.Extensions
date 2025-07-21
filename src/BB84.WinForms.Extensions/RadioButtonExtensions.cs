// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for binding properties of a <see cref="RadioButton"/> control to a data source,
/// enabling streamlined data binding for common properties such as <see cref="RadioButton.Checked"/>.
/// </summary>
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
}
