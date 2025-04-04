// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public class ProgressBarExtensionsTests
{
	[TestMethod]
	public void WithEnabledBindingTest()
	{
		ProgressBar progressBar = new();

		progressBar.WithEnabledBinding(new object(), nameof(progressBar.Enabled));

		Assert.AreEqual(1, progressBar.DataBindings.Count);
		Assert.AreEqual(nameof(progressBar.Enabled), progressBar.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithMinimumBindingTest()
	{
		ProgressBar progressBar = new();

		progressBar.WithMinimumBinding(new object(), nameof(progressBar.Minimum));

		Assert.AreEqual(1, progressBar.DataBindings.Count);
		Assert.AreEqual(nameof(progressBar.Minimum), progressBar.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithMaximumBindingTest()
	{
		ProgressBar progressBar = new();

		progressBar.WithMaximumBinding(new object(), nameof(progressBar.Maximum));

		Assert.AreEqual(1, progressBar.DataBindings.Count);
		Assert.AreEqual(nameof(progressBar.Maximum), progressBar.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithValueBindingTest()
	{
		ProgressBar progressBar = new();

		progressBar.WithValueBinding(new object(), nameof(progressBar.Value));

		Assert.AreEqual(1, progressBar.DataBindings.Count);
		Assert.AreEqual(nameof(progressBar.Value), progressBar.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		ProgressBar progressBar = new();

		progressBar.WithVisibleBinding(new object(), nameof(progressBar.Visible));

		Assert.AreEqual(1, progressBar.DataBindings.Count);
		Assert.AreEqual(nameof(progressBar.Visible), progressBar.DataBindings[0].PropertyName);
	}
}
