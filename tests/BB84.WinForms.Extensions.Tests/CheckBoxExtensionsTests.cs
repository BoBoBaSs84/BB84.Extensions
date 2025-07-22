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
	public void WithCheckedBinding_ShouldBindChecked()
	{
		var dataSource = new { Checked = false };
		CheckBox checkBox = new();

		checkBox.WithCheckedBinding(dataSource, nameof(checkBox.Checked));

		Assert.AreEqual(1, checkBox.DataBindings.Count);
		Assert.AreEqual(nameof(checkBox.Checked), checkBox.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, checkBox.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, checkBox.DataBindings[0].DataSourceUpdateMode);
	}
#if NET5_0_OR_GREATER

	[TestMethod]
	public void WithCheckStateBinding_ShouldBindCheckState()
	{
		var dataSource = new { CheckState = CheckState.Unchecked };
		CheckBox checkBox = new();

		checkBox.WithCheckStateBinding(dataSource, nameof(checkBox.CheckState));
		Assert.AreEqual(1, checkBox.DataBindings.Count);

		Assert.AreEqual(nameof(checkBox.CheckState), checkBox.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, checkBox.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, checkBox.DataBindings[0].DataSourceUpdateMode);
	}

	[TestMethod]
	public void WithCheckAlignBinding_ShouldBindCheckAlign()
	{
		var dataSource = new { CheckAlign = ContentAlignment.MiddleLeft };
		CheckBox checkBox = new();

		checkBox.WithCheckAlignBinding(dataSource, nameof(checkBox.CheckAlign));

		Assert.AreEqual(1, checkBox.DataBindings.Count);
		Assert.AreEqual(nameof(checkBox.CheckAlign), checkBox.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, checkBox.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, checkBox.DataBindings[0].DataSourceUpdateMode);
	}
#endif
}
