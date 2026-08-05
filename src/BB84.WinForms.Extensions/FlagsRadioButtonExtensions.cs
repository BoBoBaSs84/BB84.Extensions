// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using BB84.WinForms.Extensions.Common;
using BB84.WinForms.Extensions.Controls;

namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for binding and working with the <see cref="FlagsRadioButton"/> control.
/// </summary>
public static class FlagsRadioButtonExtensions
{
	/// <summary>
	/// Sets the <see cref="FlagsControlBase.DisplayNameResolver"/> of the specified <see cref="FlagsRadioButton"/>
	/// to a resolver that retrieves display names from the <see cref="DescriptionAttribute"/> of enum values.
	/// </summary>
	/// <param name="radioButton">The <see cref="FlagsRadioButton"/> to configure.</param>
	/// <returns>
	/// The same <see cref="FlagsRadioButton"/> instance, so that additional configuration can be chained fluently.
	/// </returns>
	public static FlagsRadioButton WithDescriptionName(this FlagsRadioButton radioButton)
		=> FlagsControlHelper.WithDescriptionName(radioButton);

	/// <summary>
	/// Sets the <see cref="FlagsControlBase.DisplayNameResolver"/> of the specified <see cref="FlagsRadioButton"/>
	/// to a resolver that retrieves display names from the <see cref="DisplayAttribute"/> of enum values.
	/// </summary>
	/// <param name="radioButton">The <see cref="FlagsRadioButton"/> to configure.</param>
	/// <returns>
	/// The same <see cref="FlagsRadioButton"/> instance, so that additional configuration can be chained fluently.
	/// </returns>
	public static FlagsRadioButton WithDisplayName(this FlagsRadioButton radioButton)
		=> FlagsControlHelper.WithDisplayName(radioButton);

	/// <summary>
	/// Sets the <see cref="FlagsControlBase.DisplayNameResolver"/> used to provide user-friendly captions.
	/// </summary>
	/// <param name="radioButton">The <see cref="FlagsRadioButton"/> to configure.</param>
	/// <param name="resolver">The delegate that resolves a display name for each flag value.</param>
	/// <returns>
	/// The same <see cref="FlagsRadioButton"/> instance, so that additional configuration can be chained fluently.
	/// </returns>
	public static FlagsRadioButton WithDisplayNameResolver(this FlagsRadioButton radioButton, Func<Enum, string> resolver)
		=> FlagsControlHelper.WithDisplayNameResolver(radioButton, resolver);

	/// <summary>
	/// Sets the <see cref="FlagsControlBase.FlowDirection"/> property of the specified <see cref="FlagsRadioButton"/> to the given <see cref="FlowDirection"/> value.
	/// </summary>
	/// <param name="radioButton">The <see cref="FlagsRadioButton"/> to modify.</param>
	/// <param name="direction">The <see cref="FlowDirection"/> value to set.</param>
	/// <returns>
	/// The same <see cref="FlagsRadioButton"/> instance, so that additional configuration can be chained fluently.
	/// </returns>
	public static FlagsRadioButton WithFlowDirection(this FlagsRadioButton radioButton, FlowDirection direction)
		=> FlagsControlHelper.WithFlowDirection(radioButton, direction);

	/// <summary>
	/// Binds the <see cref="FlagsControlBase.SelectedValue"/> property of the specified <see cref="FlagsRadioButton"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="FlagsControlBase.SelectedValue"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="radioButton">The <see cref="FlagsRadioButton"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="FlagsRadioButton"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static FlagsRadioButton WithSelectedValueBinding(this FlagsRadioButton radioButton, object dataSource, string dataMember)
		=> BindingHelper.Bind(radioButton, nameof(radioButton.SelectedValue), dataSource, dataMember);
}
