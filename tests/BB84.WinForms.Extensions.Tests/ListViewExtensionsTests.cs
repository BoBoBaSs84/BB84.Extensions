﻿// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ListViewExtensionsTests
{
	[TestMethod]
	public void WithEnabledBindingTest()
	{
		ListView listView = new();

		listView.WithEnabledBinding(new object(), nameof(listView.Enabled));

		Assert.AreEqual(1, listView.DataBindings.Count);
		Assert.AreEqual(nameof(listView.Enabled), listView.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		ListView listView = new();

		listView.WithVisibleBinding(new object(), nameof(listView.Visible));

		Assert.AreEqual(1, listView.DataBindings.Count);
		Assert.AreEqual(nameof(listView.Visible), listView.DataBindings[0].PropertyName);
	}
}
