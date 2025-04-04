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
		RadioButton radioButton = new();

		radioButton.WithCheckedBinding(new object(), nameof(radioButton.Checked));

		Assert.AreEqual(1, radioButton.DataBindings.Count);
		Assert.AreEqual(nameof(radioButton.Checked), radioButton.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithEnabledBindingTest()
	{
		RadioButton radioButton = new();

		radioButton.WithEnabledBinding(new object(), nameof(radioButton.Enabled));

		Assert.AreEqual(1, radioButton.DataBindings.Count);
		Assert.AreEqual(nameof(radioButton.Enabled), radioButton.DataBindings[0].PropertyName);
	}

	[TestMethod()]
	public void WithTextBindingTest()
	{
		RadioButton radioButton = new();

		radioButton.WithTextBinding(new object(), nameof(radioButton.Text));

		Assert.AreEqual(1, radioButton.DataBindings.Count);
		Assert.AreEqual(nameof(radioButton.Text), radioButton.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		RadioButton radioButton = new();

		radioButton.WithVisibleBinding(new object(), nameof(radioButton.Visible));

		Assert.AreEqual(1, radioButton.DataBindings.Count);
		Assert.AreEqual(nameof(radioButton.Visible), radioButton.DataBindings[0].PropertyName);
	}
}
