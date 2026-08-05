// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.ComponentModel;

namespace BB84.WinForms.Extensions.Common;

/// <summary>
/// Substitutes a concrete type whenever the designer asks for an instance of an abstract control type.
/// </summary>
/// <remarks>
/// The Windows Forms designer renders an inherited control by instantiating its base class, which
/// fails with "the designer must create an instance ... but it cannot because the type is declared
/// as abstract" for an abstract base. Applying this provider to the abstract type redirects the
/// reflection type and the instantiation to <typeparamref name="TConcrete"/>, so the derived
/// controls can be opened in the designer. Derived types pass through untouched and nothing changes
/// at runtime, because only the designer takes this path.
/// </remarks>
/// <typeparam name="TAbstract">The abstract control type to substitute.</typeparam>
/// <typeparam name="TConcrete">The concrete type created in its place.</typeparam>
public sealed class AbstractControlDescriptionProvider<TAbstract, TConcrete> : TypeDescriptionProvider
	where TAbstract : class
	where TConcrete : TAbstract
{
	/// <summary>
	/// Initializes a new instance of the <see cref="AbstractControlDescriptionProvider{TAbstract, TConcrete}"/> class.
	/// </summary>
	public AbstractControlDescriptionProvider()
		: base(TypeDescriptor.GetProvider(typeof(TAbstract)))
	{ }

	/// <inheritdoc/>
	public override Type GetReflectionType(Type objectType, object? instance)
		=> base.GetReflectionType(objectType == typeof(TAbstract) ? typeof(TConcrete) : objectType, instance);

	/// <inheritdoc/>
	public override object? CreateInstance(IServiceProvider? provider, Type objectType, Type[]? argTypes, object?[]? args)
		=> base.CreateInstance(provider, objectType == typeof(TAbstract) ? typeof(TConcrete) : objectType, argTypes, args);
}
