// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.WinForms.Extensions.Common;
using BB84.WinForms.Extensions.Controls;

namespace BB84.WinForms.Extensions.Tests.Common;

/// <summary>
/// Covers the designer substitution that lets the abstract flags control base be opened in the designer.
/// </summary>
[TestClass]
public sealed class AbstractControlDescriptionProviderTests
{
	[TestMethod]
	[Description("Should report the concrete type when asked to reflect over the abstract one.")]
	public void GetReflectionTypeShouldSubstituteTheAbstractType()
	{
		AbstractControlDescriptionProvider<FlagsControlBase, FlagsCheckBox> provider = new();

		Type reflectionType = provider.GetReflectionType(typeof(FlagsControlBase), null);

		Assert.AreEqual(typeof(FlagsCheckBox), reflectionType);
	}

	[TestMethod]
	[Description("Should leave a derived type untouched.")]
	public void GetReflectionTypeShouldPassDerivedTypesThrough()
	{
		AbstractControlDescriptionProvider<FlagsControlBase, FlagsCheckBox> provider = new();

		Type reflectionType = provider.GetReflectionType(typeof(FlagsRadioButton), null);

		Assert.AreEqual(typeof(FlagsRadioButton), reflectionType);
	}

	[TestMethod]
	[Description("Should create the concrete type when asked to instantiate the abstract one.")]
	public void CreateInstanceShouldSubstituteTheAbstractType()
	{
		AbstractControlDescriptionProvider<FlagsControlBase, FlagsCheckBox> provider = new();

		using IDisposable? instance = provider.CreateInstance(null, typeof(FlagsControlBase), null, null) as IDisposable;

		Assert.IsInstanceOfType<FlagsCheckBox>(instance);
	}

	[TestMethod]
	[Description("Should create a derived type as requested.")]
	public void CreateInstanceShouldPassDerivedTypesThrough()
	{
		AbstractControlDescriptionProvider<FlagsControlBase, FlagsCheckBox> provider = new();

		using IDisposable? instance = provider.CreateInstance(null, typeof(FlagsRadioButton), null, null) as IDisposable;

		Assert.IsInstanceOfType<FlagsRadioButton>(instance);
	}
}
