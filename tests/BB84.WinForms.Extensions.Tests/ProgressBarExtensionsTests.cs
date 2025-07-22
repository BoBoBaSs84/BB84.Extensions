// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Windows.Forms;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public class ProgressBarExtensionsTests
{
	[TestMethod]
	public void WithValueBindingTest()
	{
		var dataSource = new { Value = 50 };
		ProgressBar progressBar = new();

		progressBar.WithValueBinding(dataSource, nameof(progressBar.Value));

		Assert.AreEqual(1, progressBar.DataBindings.Count);
		Assert.AreEqual(nameof(progressBar.Value), progressBar.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, progressBar.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, progressBar.DataBindings[0].DataSourceUpdateMode);
	}
}
