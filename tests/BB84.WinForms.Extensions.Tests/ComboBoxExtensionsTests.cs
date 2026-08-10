// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.WinForms.Extensions.Tests.Common;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ComboBoxExtensionsTests
{
	[TestMethod]
	public void WithSelectedItemBindingTest()
	{
		var dataSource = new { SelectedItem = "Item1" };
		using ComboBox comboBox = new();

		comboBox.WithSelectedItemBinding(dataSource, nameof(comboBox.SelectedItem));

		BindingAssert.IsSingleBinding(comboBox, nameof(comboBox.SelectedItem), dataSource);
	}

	[TestMethod]
	public void WithSelectedIndexBindingTest()
	{
		var dataSource = new { SelectedIndex = 1 };
		using ComboBox comboBox = new();

		comboBox.WithSelectedIndexBinding(dataSource, nameof(comboBox.SelectedIndex));

		BindingAssert.IsSingleBinding(comboBox, nameof(comboBox.SelectedIndex), dataSource);
	}
}
