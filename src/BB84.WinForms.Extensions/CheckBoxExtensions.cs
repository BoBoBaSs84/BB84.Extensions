﻿// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for binding properties of a <see cref="CheckBox"/> control to a data source,
/// enabling streamlined data binding for common properties such as <see cref="CheckBox.Checked"/>.
/// </summary>
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

#if NET5_0_OR_GREATER
	/// <summary>
	/// Binds the <see cref="CheckBox.CheckState"/> property of the specified <see cref="CheckBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="CheckBox.CheckState"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="checkBox">The <see cref="CheckBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="CheckBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static CheckBox WithCheckStateBinding(this CheckBox checkBox, object dataSource, string dataMember)
	{
		checkBox.DataBindings.Add(nameof(checkBox.CheckState), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return checkBox;
	}

	/// <summary>
	/// Binds the <see cref="CheckBox.CheckAlign"/> property of the specified <see cref="CheckBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="CheckBox.CheckAlign"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="checkBox">The <see cref="CheckBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="CheckBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static CheckBox WithCheckAlignBinding(this CheckBox checkBox, object dataSource, string dataMember)
	{
		checkBox.DataBindings.Add(nameof(checkBox.CheckAlign), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return checkBox;
	}
#endif
}
