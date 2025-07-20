// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class GroupBoxExtensionsTests
{
	[TestMethod]
	public void WithEnabledBindingTest()
	{
		GroupBox groupBox = new();

		groupBox.WithEnabledBinding(new object(), nameof(groupBox.Enabled));

		Assert.AreEqual(1, groupBox.DataBindings.Count);
		Assert.AreEqual(nameof(groupBox.Enabled), groupBox.DataBindings[0].PropertyName);
	}

	[TestMethod()]
	public void WithTextBindingTest()
	{
		GroupBox groupBox = new();

		groupBox.WithTextBinding(new object(), nameof(groupBox.Text));

		Assert.AreEqual(1, groupBox.DataBindings.Count);
		Assert.AreEqual(nameof(groupBox.Text), groupBox.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		GroupBox groupBox = new();

		groupBox.WithVisibleBinding(new object(), nameof(groupBox.Visible));

		Assert.AreEqual(1, groupBox.DataBindings.Count);
		Assert.AreEqual(nameof(groupBox.Visible), groupBox.DataBindings[0].PropertyName);
	}
}
