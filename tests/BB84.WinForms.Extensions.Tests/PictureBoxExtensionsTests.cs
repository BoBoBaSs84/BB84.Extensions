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
	public void WithImageBindingShouldBindImage()
	{
		using Bitmap bitmap = new(320, 240);
		var dataSource = new { Image = bitmap };
		using PictureBox pictureBox = new();

		pictureBox.WithImageBinding(dataSource, nameof(pictureBox.Image));

		Assert.HasCount(1, pictureBox.DataBindings);
		Assert.AreEqual(nameof(pictureBox.Image), pictureBox.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, pictureBox.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, pictureBox.DataBindings[0].DataSourceUpdateMode);
	}
}
