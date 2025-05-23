// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="RichTextBox"/> control to simplify data binding.
/// </summary>
/// <remarks>
/// These extension methods allow developers to easily bind common properties of a <see cref="RichTextBox"/>
/// (such as <see cref="Control.Enabled"/>, <see cref="RichTextBox.Text"/>, and <see cref="Control.Visible"/>)
/// to a data source. Each method returns the same <see cref="RichTextBox"/> instance, enabling method chaining.
/// </remarks>
public static class RichTextBoxExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property of the specified <see cref="RichTextBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Enabled"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="richTextBox">The <see cref="RichTextBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="RichTextBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static RichTextBox WithEnabledBinding(this RichTextBox richTextBox, object dataSource, string dataMember)
	{
		richTextBox.DataBindings.Add(nameof(richTextBox.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return richTextBox;
	}

	/// <summary>
	/// Binds the <see cref="RichTextBox.Text"/> property of the specified <see cref="RichTextBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="RichTextBox.Text"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="richTextBox">The <see cref="RichTextBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="RichTextBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static RichTextBox WithTextBinding(this RichTextBox richTextBox, object dataSource, string dataMember)
	{
		richTextBox.DataBindings.Add(nameof(richTextBox.Text), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return richTextBox;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property of the specified <see cref="RichTextBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Visible"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="richTextBox">The <see cref="RichTextBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="RichTextBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static RichTextBox WithVisibleBinding(this RichTextBox richTextBox, object dataSource, string dataMember)
	{
		richTextBox.DataBindings.Add(nameof(richTextBox.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return richTextBox;
	}
}
