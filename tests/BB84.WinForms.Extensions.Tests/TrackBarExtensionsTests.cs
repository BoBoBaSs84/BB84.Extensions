// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class TrackBarExtensionsTests
{
	[TestMethod]
	public void WithValueBindingTest()
	{
		var dataSource = new { Value = 50 };
		TrackBar trackBar = new();

		trackBar.WithValueBinding(dataSource, nameof(trackBar.Value));

		Assert.AreEqual(1, trackBar.DataBindings.Count);
		Assert.AreEqual(nameof(trackBar.Value), trackBar.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, trackBar.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, trackBar.DataBindings[0].DataSourceUpdateMode);
	}
}
