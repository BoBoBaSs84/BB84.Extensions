// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.WinForms.Extensions.Tests.Common;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ListBoxExtensionsTests
{

	[TestMethod]
	public void WithSelectedItemBindingShouldBindSelectedItem()
	{
		var dataSource = new { SelectedItem = "Item1" };
		using ListBox listBox = new();

		listBox.WithSelectedItemBinding(dataSource, nameof(listBox.SelectedItem));

		BindingAssert.IsSingleBinding(listBox, nameof(listBox.SelectedItem), dataSource);
	}

	[TestMethod]
	public void WithSelectedIndexBindingShouldBindSelectedIndex()
	{
		var dataSource = new { SelectedIndex = 1 };
		using ListBox listBox = new();

		listBox.WithSelectedIndexBinding(dataSource, nameof(listBox.SelectedIndex));

		BindingAssert.IsSingleBinding(listBox, nameof(listBox.SelectedIndex), dataSource);
	}
}
