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
	public void WithEnabledBindingTest()
	{
		NumericUpDown numericUpDown = new();

		numericUpDown.WithEnabledBinding(new object(), nameof(numericUpDown.Enabled));

		Assert.AreEqual(1, numericUpDown.DataBindings.Count);
		Assert.AreEqual(nameof(numericUpDown.Enabled), numericUpDown.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithValueBindingTest()
	{
		NumericUpDown numericUpDown = new();

		numericUpDown.WithValueBinding(new object(), nameof(numericUpDown.Value));

		Assert.AreEqual(1, numericUpDown.DataBindings.Count);
		Assert.AreEqual(nameof(numericUpDown.Value), numericUpDown.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		NumericUpDown numericUpDown = new();

		numericUpDown.WithVisibleBinding(new object(), nameof(numericUpDown.Visible));

		Assert.AreEqual(1, numericUpDown.DataBindings.Count);
		Assert.AreEqual(nameof(numericUpDown.Visible), numericUpDown.DataBindings[0].PropertyName);
	}
}
