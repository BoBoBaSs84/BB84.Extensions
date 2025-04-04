// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class MaskedTextBoxExtensionsTests
{
	[TestMethod]
	public void WithEnabledBindingTest()
	{
		MaskedTextBox maskedTextBox = new();

		maskedTextBox.WithEnabledBinding(new object(), nameof(maskedTextBox.Enabled));

		Assert.AreEqual(1, maskedTextBox.DataBindings.Count);
		Assert.AreEqual(nameof(maskedTextBox.Enabled), maskedTextBox.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithTextBindingTest()
	{
		MaskedTextBox maskedTextBox = new();

		maskedTextBox.WithTextBinding(new object(), nameof(maskedTextBox.Text));

		Assert.AreEqual(1, maskedTextBox.DataBindings.Count);
		Assert.AreEqual(nameof(maskedTextBox.Text), maskedTextBox.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		MaskedTextBox maskedTextBox = new();

		maskedTextBox.WithVisibleBinding(new object(), nameof(maskedTextBox.Visible));

		Assert.AreEqual(1, maskedTextBox.DataBindings.Count);
		Assert.AreEqual(nameof(maskedTextBox.Visible), maskedTextBox.DataBindings[0].PropertyName);
	}
}
