// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Common;

/// <summary>
/// Provides the shared implementation behind the fluent binding extension methods.
/// </summary>
/// <remarks>
/// The extension classes forward to this helper so the <see cref="ControlBindingsCollection.Add(string, object, string, bool, DataSourceUpdateMode)"/>
/// call and its argument validation exist exactly once. The constraint is <see cref="IBindableComponent"/>
/// rather than <see cref="Control"/>, because <see cref="ToolStripItem"/> is a <see cref="System.ComponentModel.Component"/>
/// and not a <see cref="Control"/>, yet still exposes bindings.
/// </remarks>
internal static class BindingHelper
{
	/// <summary>
	/// The formatting setting every property specific extension method binds with.
	/// </summary>
	/// <remarks>
	/// This and <see cref="DefaultUpdateMode"/> are constants so that
	/// <see cref="BindableComponentExtensions.WithBinding{TComponent}(TComponent, string, object, string, bool, DataSourceUpdateMode)"/>
	/// can use them as its optional parameter defaults. Otherwise the policy would have to be written
	/// out in both places and could drift.
	/// </remarks>
	internal const bool DefaultFormattingEnabled = true;

	/// <summary>
	/// The update mode every property specific extension method binds with.
	/// </summary>
	internal const DataSourceUpdateMode DefaultUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

	/// <summary>
	/// Adds a binding for the given component property and returns the component for chaining.
	/// </summary>
	internal static TComponent Bind<TComponent>(TComponent component, string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode updateMode)
		where TComponent : IBindableComponent
	{
		Guard.ThrowIfNull(component);
		Guard.ThrowIfNull(dataSource);

		component.DataBindings.Add(propertyName, dataSource, dataMember, formattingEnabled, updateMode);
		return component;
	}

	/// <summary>
	/// Adds a binding using the defaults applied by all property specific extension methods,
	/// which are formatting enabled and <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </summary>
	internal static TComponent Bind<TComponent>(TComponent component, string propertyName, object dataSource, string dataMember)
		where TComponent : IBindableComponent
		=> Bind(component, propertyName, dataSource, dataMember, DefaultFormattingEnabled, DefaultUpdateMode);
}
