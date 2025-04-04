// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class RichTextBoxExtensionsTests
{
	[TestMethod]
	public void WithEnabledBindingTest()
	{
		RichTextBox richTextBox = new();

		richTextBox.WithEnabledBinding(new object(), nameof(richTextBox.Enabled));

		Assert.AreEqual(1, richTextBox.DataBindings.Count);
		Assert.AreEqual(nameof(richTextBox.Enabled), richTextBox.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithTextBindingTest()
	{
		RichTextBox richTextBox = new();

		richTextBox.WithTextBinding(new object(), nameof(richTextBox.Text));

		Assert.AreEqual(1, richTextBox.DataBindings.Count);
		Assert.AreEqual(nameof(richTextBox.Text), richTextBox.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		RichTextBox richTextBox = new();

		richTextBox.WithVisibleBinding(new object(), nameof(richTextBox.Visible));

		Assert.AreEqual(1, richTextBox.DataBindings.Count);
		Assert.AreEqual(nameof(richTextBox.Visible), richTextBox.DataBindings[0].PropertyName);
	}
}
