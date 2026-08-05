// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.WinForms.Extensions.Common;

namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides a general purpose data binding extension method for any bindable component.
/// </summary>
/// <remarks>
/// The property specific extension methods, such as <see cref="ControlExtensions.WithTextBinding(Control, object, string)"/>,
/// always bind with formatting enabled and <see cref="DataSourceUpdateMode.OnPropertyChanged"/>. This class
/// is the escape hatch for the cases those defaults do not fit, and for control properties that have no
/// dedicated method.
/// </remarks>
public static class BindableComponentExtensions
{
	/// <summary>
	/// Binds the specified property of the component to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// Pass <paramref name="propertyName"/> and <paramref name="dataMember"/> using <see langword="nameof"/>
	/// to keep them verified by the compiler.
	/// </remarks>
	/// <typeparam name="TComponent">The type of the component to bind.</typeparam>
	/// <param name="component">The component to bind.</param>
	/// <param name="propertyName">The name of the property on the component to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <param name="formattingEnabled">
	/// <see langword="true"/> to format the displayed data; otherwise, <see langword="false"/>.
	/// </param>
	/// <param name="updateMode">
	/// Determines when the data source is updated with changes made to the bound property.
	/// </param>
	/// <returns>
	/// The component with the binding applied, allowing for method chaining.
	/// </returns>
	/// <exception cref="ArgumentNullException">
	/// Thrown if <paramref name="component"/> or <paramref name="dataSource"/> is <see langword="null"/>.
	/// </exception>
	public static TComponent WithBinding<TComponent>(this TComponent component, string propertyName, object dataSource, string dataMember, bool formattingEnabled = true, DataSourceUpdateMode updateMode = DataSourceUpdateMode.OnPropertyChanged)
		where TComponent : IBindableComponent
		=> BindingHelper.Bind(component, propertyName, dataSource, dataMember, formattingEnabled, updateMode);
}
