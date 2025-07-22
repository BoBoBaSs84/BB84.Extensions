// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class RadioButtonExtensionsTests
{
	[TestMethod]
	public void WithCheckedBindingTest()
	{
		var dataSource = new { Checked = false };
		RadioButton radioButton = new();

		radioButton.WithCheckedBinding(dataSource, nameof(radioButton.Checked));

		Assert.AreEqual(1, radioButton.DataBindings.Count);
		Assert.AreEqual(nameof(radioButton.Checked), radioButton.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, radioButton.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, radioButton.DataBindings[0].DataSourceUpdateMode);
	}
}
