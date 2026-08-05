// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.WinForms.Extensions.Controls;
using BB84.WinForms.Extensions.Helpers;

namespace BB84.WinForms.Extensions.Common;

/// <summary>
/// Provides the shared implementation behind the fluent extension methods of the flags controls.
/// </summary>
/// <remarks>
/// The public extension classes keep their concrete parameter and return types, so that compiled
/// callers are unaffected, and forward to these generic members so the logic exists exactly once.
/// The binding itself is handled by <see cref="BindingHelper"/>, like for every other control.
/// </remarks>
internal static class FlagsControlHelper
{
	/// <summary>
	/// Applies the resolver that reads display names from the description attribute of enum values.
	/// </summary>
	internal static TControl WithDescriptionName<TControl>(TControl control)
		where TControl : FlagsControlBase
		=> WithDisplayNameResolver(control, FlagsDisplayResolvers.FromDescriptionAttribute);

	/// <summary>
	/// Applies the resolver that reads display names from the display attribute of enum values.
	/// </summary>
	internal static TControl WithDisplayName<TControl>(TControl control)
		where TControl : FlagsControlBase
		=> WithDisplayNameResolver(control, FlagsDisplayResolvers.FromDisplayAttribute);

	/// <summary>
	/// Applies the resolver used to provide user friendly captions for the flag values.
	/// </summary>
	internal static TControl WithDisplayNameResolver<TControl>(TControl control, Func<Enum, string> resolver)
		where TControl : FlagsControlBase
	{
		control.DisplayNameResolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
		return control;
	}

	/// <summary>
	/// Applies the layout direction used to arrange the flag buttons.
	/// </summary>
	internal static TControl WithFlowDirection<TControl>(TControl control, FlowDirection direction)
		where TControl : FlagsControlBase
	{
		control.FlowDirection = direction;
		return control;
	}
}
