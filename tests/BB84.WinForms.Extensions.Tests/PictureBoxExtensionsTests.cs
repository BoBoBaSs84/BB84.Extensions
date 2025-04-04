// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class PictureBoxExtensionsTests
{
	[TestMethod]
	public void WithEnabledBindingTest()
	{
		PictureBox pictureBox = new();

		pictureBox.WithEnabledBinding(new object(), nameof(pictureBox.Enabled));

		Assert.AreEqual(1, pictureBox.DataBindings.Count);
		Assert.AreEqual(nameof(pictureBox.Enabled), pictureBox.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithErrorImageBindingTest()
	{
		PictureBox pictureBox = new();

		pictureBox.WithErrorImageBinding(new object(), nameof(pictureBox.ErrorImage));

		Assert.AreEqual(1, pictureBox.DataBindings.Count);
		Assert.AreEqual(nameof(pictureBox.ErrorImage), pictureBox.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithImageBindingTest()
	{
		PictureBox pictureBox = new();

		pictureBox.WithImageBinding(new object(), nameof(pictureBox.Image));

		Assert.AreEqual(1, pictureBox.DataBindings.Count);
		Assert.AreEqual(nameof(pictureBox.Image), pictureBox.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		PictureBox pictureBox = new();

		pictureBox.WithVisibleBinding(new object(), nameof(pictureBox.Visible));

		Assert.AreEqual(1, pictureBox.DataBindings.Count);
		Assert.AreEqual(nameof(pictureBox.Visible), pictureBox.DataBindings[0].PropertyName);
	}
}
