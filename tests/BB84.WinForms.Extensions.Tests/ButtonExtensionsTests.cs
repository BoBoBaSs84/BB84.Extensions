// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ButtonExtensionsTests
{
	[TestMethod]
	public void WithEnabledBindingTest()
	{
		Button button = new();

		button.WithEnabledBinding(new object(), nameof(button.Enabled));

		Assert.AreEqual(1, button.DataBindings.Count);
		Assert.AreEqual(nameof(button.Enabled), button.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		Button button = new();

		button.WithVisibleBinding(new object(), nameof(button.Visible));

		Assert.AreEqual(1, button.DataBindings.Count);
		Assert.AreEqual(nameof(button.Visible), button.DataBindings[0].PropertyName);
	}
}
