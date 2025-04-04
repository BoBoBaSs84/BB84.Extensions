// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

#if NETFRAMEWORK
[TestClass]
public sealed class DataGridExtensionsTests
{
	[TestMethod]
	public void WithDataSourceTest()
	{
		DataGrid dataGrid = new();

		dataGrid.WithDataSource(new List<int>());

		Assert.IsNotNull(dataGrid.DataSource);
		Assert.IsInstanceOfType<List<int>>(dataGrid.DataSource);
	}

	[TestMethod]
	public void WithEnabledBindingTest()
	{
		DataGrid dataGrid = new();

		dataGrid.WithEnabledBinding(new object(), nameof(dataGrid.Enabled));

		Assert.AreEqual(1, dataGrid.DataBindings.Count);
		Assert.AreEqual(nameof(dataGrid.Enabled), dataGrid.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		DataGrid dataGrid = new();

		dataGrid.WithVisibleBinding(new object(), nameof(dataGrid.Visible));

		Assert.AreEqual(1, dataGrid.DataBindings.Count);
		Assert.AreEqual(nameof(dataGrid.Visible), dataGrid.DataBindings[0].PropertyName);
	}
}
#endif
