// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ComboBoxExtensionsTests
{
	[TestMethod]
	public void WithDataSourceTest()
	{
		ComboBox comboBox = new();

		comboBox.WithDataSource(new List<int>());

		Assert.IsNotNull(comboBox.DataSource);
		Assert.IsInstanceOfType<List<int>>(comboBox.DataSource);
	}

	[TestMethod]
	public void WithEnabledBindingTest()
	{
		ComboBox comboBox = new();

		comboBox.WithEnabledBinding(new object(), nameof(comboBox.Enabled));

		Assert.AreEqual(1, comboBox.DataBindings.Count);
		Assert.AreEqual(nameof(comboBox.Enabled), comboBox.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithSelectedItemBindingTest()
	{
		ComboBox comboBox = new();

		comboBox.WithSelectedItemBinding(new object(), nameof(comboBox.SelectedItem));

		Assert.AreEqual(1, comboBox.DataBindings.Count);
		Assert.AreEqual(nameof(comboBox.SelectedItem), comboBox.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithSelectedIndexBindingTest()
	{
		ComboBox comboBox = new();

		comboBox.WithSelectedIndexBinding(new object(), nameof(comboBox.SelectedIndex));
		
		Assert.AreEqual(1, comboBox.DataBindings.Count);
		Assert.AreEqual(nameof(comboBox.SelectedIndex), comboBox.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithSelectedValueBindingTest()
	{
		ComboBox comboBox = new();
		
		comboBox.WithSelectedValueBinding(new object(), nameof(comboBox.SelectedValue));
		
		Assert.AreEqual(1, comboBox.DataBindings.Count);
		Assert.AreEqual(nameof(comboBox.SelectedValue), comboBox.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		ComboBox comboBox = new();

		comboBox.WithVisibleBinding(new object(), nameof(comboBox.Visible));

		Assert.AreEqual(1, comboBox.DataBindings.Count);
		Assert.AreEqual(nameof(comboBox.Visible), comboBox.DataBindings[0].PropertyName);
	}
}
