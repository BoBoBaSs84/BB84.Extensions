// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using BB84.WinForms.Extensions.Common;
using BB84.WinForms.Extensions.Controls;
using BB84.WinForms.Extensions.Helper;

namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for binding and working with the flags controls.
/// </summary>
/// <remarks>
/// The methods are generic in the control type and constrained to <see cref="FlagsControlBase"/>, so a
/// chain keeps the concrete type of whatever it started with and any control derived from the base is
/// covered without a class of its own. This replaces the per-control extension classes, which were
/// identical apart from the receiver type.
/// </remarks>
public static class FlagsControlExtensions
{
	/// <summary>
	/// Sets the <see cref="FlagsControlBase.DisplayNameResolver"/> of the specified control to a
	/// resolver that retrieves display names from the <see cref="DescriptionAttribute"/> of enum values.
	/// </summary>
	/// <typeparam name="TControl">The type of the flags control.</typeparam>
	/// <param name="control">The control to configure.</param>
	/// <returns>
	/// The same control instance, so that additional configuration can be chained fluently.
	/// </returns>
	/// <exception cref="ArgumentNullException">
	/// Thrown if <paramref name="control"/> is <see langword="null"/>.
	/// </exception>
	public static TControl WithDescriptionName<TControl>(this TControl control)
		where TControl : FlagsControlBase
		=> control.WithDisplayNameResolver(FlagsDisplayResolvers.FromDescriptionAttribute);

	/// <summary>
	/// Sets the <see cref="FlagsControlBase.DisplayNameResolver"/> of the specified control to a
	/// resolver that retrieves display names from the <see cref="DisplayAttribute"/> of enum values.
	/// </summary>
	/// <typeparam name="TControl">The type of the flags control.</typeparam>
	/// <param name="control">The control to configure.</param>
	/// <returns>
	/// The same control instance, so that additional configuration can be chained fluently.
	/// </returns>
	/// <exception cref="ArgumentNullException">
	/// Thrown if <paramref name="control"/> is <see langword="null"/>.
	/// </exception>
	public static TControl WithDisplayName<TControl>(this TControl control)
		where TControl : FlagsControlBase
		=> control.WithDisplayNameResolver(FlagsDisplayResolvers.FromDisplayAttribute);

	/// <summary>
	/// Sets the <see cref="FlagsControlBase.DisplayNameResolver"/> used to provide user-friendly captions.
	/// </summary>
	/// <typeparam name="TControl">The type of the flags control.</typeparam>
	/// <param name="control">The control to configure.</param>
	/// <param name="resolver">The delegate that resolves a display name for each flag value.</param>
	/// <returns>
	/// The same control instance, so that additional configuration can be chained fluently.
	/// </returns>
	/// <exception cref="ArgumentNullException">
	/// Thrown if <paramref name="control"/> or <paramref name="resolver"/> is <see langword="null"/>.
	/// </exception>
	public static TControl WithDisplayNameResolver<TControl>(this TControl control, Func<Enum, string> resolver)
		where TControl : FlagsControlBase
	{
		Guard.ThrowIfNull(control);
		Guard.ThrowIfNull(resolver);

		control.DisplayNameResolver = resolver;
		return control;
	}

	/// <summary>
	/// Sets the <see cref="FlagsControlBase.FlowDirection"/> property of the specified control.
	/// </summary>
	/// <typeparam name="TControl">The type of the flags control.</typeparam>
	/// <param name="control">The control to modify.</param>
	/// <param name="direction">The <see cref="FlowDirection"/> value to set.</param>
	/// <returns>
	/// The same control instance, so that additional configuration can be chained fluently.
	/// </returns>
	/// <exception cref="ArgumentNullException">
	/// Thrown if <paramref name="control"/> is <see langword="null"/>.
	/// </exception>
	public static TControl WithFlowDirection<TControl>(this TControl control, FlowDirection direction)
		where TControl : FlagsControlBase
	{
		Guard.ThrowIfNull(control);

		control.FlowDirection = direction;
		return control;
	}

	/// <summary>
	/// Binds the <see cref="FlagsControlBase.SelectedValue"/> property of the specified control to a
	/// property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the
	/// <see cref="FlagsControlBase.SelectedValue"/> property changes, using
	/// <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <typeparam name="TControl">The type of the flags control.</typeparam>
	/// <param name="control">The control to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The control with the binding applied, allowing for method chaining.
	/// </returns>
	/// <exception cref="ArgumentNullException">
	/// Thrown if <paramref name="control"/> or <paramref name="dataSource"/> is <see langword="null"/>.
	/// </exception>
	public static TControl WithSelectedValueBinding<TControl>(this TControl control, object dataSource, string dataMember)
		where TControl : FlagsControlBase
		=> BindingHelper.Bind(control, nameof(FlagsControlBase.SelectedValue), dataSource, dataMember);
}
