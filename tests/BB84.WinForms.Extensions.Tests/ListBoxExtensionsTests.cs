// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ListBoxExtensionsTests
{

	[TestMethod]
	public void WithSelectedItemBinding_ShouldBindSelectedItem()
	{
		var dataSource = new { SelectedItem = "Item1" };
		ListBox listBox = new();

		listBox.WithSelectedItemBinding(dataSource, nameof(listBox.SelectedItem));

		Assert.AreEqual(1, listBox.DataBindings.Count);
		Assert.AreEqual(nameof(listBox.SelectedItem), listBox.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, listBox.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, listBox.DataBindings[0].DataSourceUpdateMode);
	}

	[TestMethod]
	public void WithSelectedIndexBinding_ShouldBindSelectedIndex()
	{
		var dataSource = new { SelectedIndex = 1 };
		ListBox listBox = new();

		listBox.WithSelectedIndexBinding(dataSource, nameof(listBox.SelectedIndex));

		Assert.AreEqual(1, listBox.DataBindings.Count);
		Assert.AreEqual(nameof(listBox.SelectedIndex), listBox.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, listBox.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, listBox.DataBindings[0].DataSourceUpdateMode);
	}
}
