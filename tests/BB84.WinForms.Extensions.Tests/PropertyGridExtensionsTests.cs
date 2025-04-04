// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class PropertyGridExtensionsTests
{
	[TestMethod]
	public void WithEnabledBindingTest()
	{
		PropertyGrid propertyGrid = new();

		propertyGrid.WithEnabledBinding(new object(), nameof(propertyGrid.Enabled));

		Assert.AreEqual(1, propertyGrid.DataBindings.Count);
		Assert.AreEqual(nameof(propertyGrid.Enabled), propertyGrid.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithSelectedObjectBindingTest()
	{
		PropertyGrid propertyGrid = new();

		propertyGrid.WithSelectedObjectBinding(new object(), nameof(propertyGrid.SelectedObject));

		Assert.AreEqual(1, propertyGrid.DataBindings.Count);
		Assert.AreEqual(nameof(propertyGrid.SelectedObject), propertyGrid.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithTextBindingTest()
	{
		PropertyGrid propertyGrid = new();

		propertyGrid.WithTextBinding(new object(), nameof(propertyGrid.Text));

		Assert.AreEqual(1, propertyGrid.DataBindings.Count);
		Assert.AreEqual(nameof(propertyGrid.Text), propertyGrid.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		PropertyGrid propertyGrid = new();

		propertyGrid.WithVisibleBinding(new object(), nameof(propertyGrid.Visible));

		Assert.AreEqual(1, propertyGrid.DataBindings.Count);
		Assert.AreEqual(nameof(propertyGrid.Visible), propertyGrid.DataBindings[0].PropertyName);
	}
}
