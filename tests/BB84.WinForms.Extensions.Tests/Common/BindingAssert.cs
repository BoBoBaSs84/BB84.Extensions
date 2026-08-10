// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests.Common;

/// <summary>
/// Asserts the outcome of the fluent binding extension methods.
/// </summary>
/// <remarks>
/// Every one of those methods adds exactly one binding with the same defaults, so every test for them
/// made the same four assertions. Naming that expectation once means a change to the defaults shows up
/// in one place instead of in three dozen.
/// </remarks>
internal static class BindingAssert
{
	/// <summary>
	/// Asserts that the component carries exactly one binding for the given property and data source,
	/// using the defaults every property specific extension method applies.
	/// </summary>
	/// <param name="component">The component that was bound.</param>
	/// <param name="propertyName">The name of the property that should be bound.</param>
	/// <param name="dataSource">The data source the property should be bound to.</param>
	internal static void IsSingleBinding(IBindableComponent component, string propertyName, object dataSource)
	{
		Assert.HasCount(1, component.DataBindings);

		Binding binding = component.DataBindings[0];

		Assert.AreEqual(propertyName, binding.PropertyName);
		Assert.AreEqual(dataSource, binding.DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, binding.DataSourceUpdateMode);
		Assert.IsTrue(binding.FormattingEnabled);
	}
}
