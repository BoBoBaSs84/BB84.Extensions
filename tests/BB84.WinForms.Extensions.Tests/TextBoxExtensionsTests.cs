// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class TextBoxExtensionsTests
{
	[TestMethod]
	public void WithEnabledBindingTest()
	{
		TextBox textBox = new();

		textBox.WithEnabledBinding(new object(), nameof(textBox.Enabled));

		Assert.AreEqual(1, textBox.DataBindings.Count);
		Assert.AreEqual(nameof(textBox.Enabled), textBox.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithTextBindingTest()
	{
		TextBox textBox = new();

		textBox.WithTextBinding(new object(), nameof(textBox.Text));

		Assert.AreEqual(1, textBox.DataBindings.Count);
		Assert.AreEqual(nameof(textBox.Text), textBox.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		TextBox textBox = new();

		textBox.WithVisibleBinding(new object(), nameof(textBox.Visible));

		Assert.AreEqual(1, textBox.DataBindings.Count);
		Assert.AreEqual(nameof(textBox.Visible), textBox.DataBindings[0].PropertyName);
	}
}
