// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class LabelExtensionsTests
{
	[TestMethod]
	public void WithEnabledBindingTest()
	{
		Label label = new();

		label.WithEnabledBinding(new object(), nameof(label.Enabled));

		Assert.AreEqual(1, label.DataBindings.Count);
		Assert.AreEqual(nameof(label.Enabled), label.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithTextBindingTest()
	{
		Label label = new();

		label.WithTextBinding(new object(), nameof(label.Text));

		Assert.AreEqual(1, label.DataBindings.Count);
		Assert.AreEqual(nameof(label.Text), label.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		Label label = new();

		label.WithVisibleBinding(new object(), nameof(label.Visible));

		Assert.AreEqual(1, label.DataBindings.Count);
		Assert.AreEqual(nameof(label.Visible), label.DataBindings[0].PropertyName);
	}
}
