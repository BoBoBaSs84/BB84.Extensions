// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class DataGridViewExtensionsTests
{
	[TestMethod]
	public void WithDataSourceBindingShouldBindDataSource()
	{
		var dataSource = new List<string> { "Item1", "Item2", "Item3" };
		DataGridView dataGridView = new();

		dataGridView.WithDataSourceBinding(dataSource);

		Assert.AreEqual(dataSource, dataGridView.DataSource);
	}
}
