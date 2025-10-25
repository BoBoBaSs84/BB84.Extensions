// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class NumericUpDownExtensionsTests
{
	[TestMethod]
	public void WithValueBindingTest()
	{
		var dataSource = new { Value = 1 };
		NumericUpDown numericUpDown = new();

		numericUpDown.WithValueBinding(dataSource, nameof(numericUpDown.Value));

		Assert.HasCount(1, numericUpDown.DataBindings);
		Assert.AreEqual(nameof(numericUpDown.Value), numericUpDown.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, numericUpDown.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, numericUpDown.DataBindings[0].DataSourceUpdateMode);
	}
}
