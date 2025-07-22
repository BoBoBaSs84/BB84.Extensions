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
	public void WithSelectedItemBindingTest()
	{
		var dataSource = new { SelectedItem = "Item1" };
		ComboBox comboBox = new();

		comboBox.WithSelectedItemBinding(dataSource, nameof(comboBox.SelectedItem));

		Assert.AreEqual(1, comboBox.DataBindings.Count);
		Assert.AreEqual(nameof(comboBox.SelectedItem), comboBox.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, comboBox.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, comboBox.DataBindings[0].DataSourceUpdateMode);
	}

	[TestMethod]
	public void WithSelectedIndexBindingTest()
	{
		var dataSource = new { SelectedIndex = 1 };
		ComboBox comboBox = new();

		comboBox.WithSelectedIndexBinding(dataSource, nameof(comboBox.SelectedIndex));

		Assert.AreEqual(1, comboBox.DataBindings.Count);
		Assert.AreEqual(nameof(comboBox.SelectedIndex), comboBox.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, comboBox.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, comboBox.DataBindings[0].DataSourceUpdateMode);
	}
}
