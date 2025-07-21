// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class CheckBoxExtensionsTests
{
	[TestMethod]
	public void WithCheckedBindingTest()
	{
		var dataSource = new { Checked = false };
		CheckBox checkBox = new();

		checkBox.WithCheckedBinding(dataSource, nameof(checkBox.Checked));

		Assert.AreEqual(1, checkBox.DataBindings.Count);
		Assert.AreEqual(nameof(checkBox.Checked), checkBox.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, checkBox.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, checkBox.DataBindings[0].DataSourceUpdateMode);
	}
}
