﻿// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for binding properties of a <see cref="PictureBox"/> control to a data source,
/// enabling streamlined data binding for common properties such as <see cref="PictureBox.Image"/>.
/// </summary>
public static class PictureBoxExtensions
{
	/// <summary>
	/// Binds the <see cref="PictureBox.Image"/> property to a specified data source and data member.
	/// </summary>
	/// <remarks>
	/// This method creates a two-way binding between the <see cref="PictureBox.Image"/> property and the
	/// specified data member in the data source. Changes to the data member will automatically update the <see
	/// cref="PictureBox.Image"/>  property, and vice versa, if supported by the data source.</remarks>
	/// <param name="pictureBox">The <see cref="PictureBox"/> to which the binding will be applied.</param>
	/// <param name="dataSource">The data source object that provides the value for the binding.</param>
	/// <param name="dataMember">The name of the property or column in the data source to bind to.</param>
	/// <returns>
	/// The <see cref="PictureBox"/> instance with the binding applied, allowing for method chaining.
	/// </returns>
	public static PictureBox WithImageBinding(this PictureBox pictureBox, object dataSource, string dataMember)
	{
		pictureBox.DataBindings.Add(nameof(pictureBox.Image), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return pictureBox;
	}
}
