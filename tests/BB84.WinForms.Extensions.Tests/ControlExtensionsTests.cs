// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ControlExtensionsTests
{
	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithEnabledBindingShouldBindEnabledProperty(Control control)
	{
		var dataSource = new { Enabled = true };

		control.WithEnabledBinding(dataSource, nameof(dataSource.Enabled));

		Assert.HasCount(1, control.DataBindings);
		Assert.AreEqual(nameof(control.Enabled), control.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, control.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, control.DataBindings[0].DataSourceUpdateMode);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithTagBindingShouldBindEnabledProperty(Control control)
	{
		var dataSource = new { Tag = new object() };

		control.WithTagBinding(dataSource, nameof(dataSource.Tag));

		Assert.HasCount(1, control.DataBindings);
		Assert.AreEqual(nameof(control.Tag), control.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, control.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, control.DataBindings[0].DataSourceUpdateMode);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithTextBindingShouldBindTextProperty(Control control)
	{
		var dataSource = new { Text = "Test" };

		control.WithTextBinding(dataSource, nameof(dataSource.Text));

		Assert.HasCount(1, control.DataBindings);
		Assert.AreEqual(nameof(control.Text), control.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, control.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, control.DataBindings[0].DataSourceUpdateMode);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithVisibleBindingShouldBindVisibleProperty(Control control)
	{
		var dataSource = new { Visible = true };

		control.WithVisibleBinding(dataSource, nameof(dataSource.Visible));

		Assert.HasCount(1, control.DataBindings);
		Assert.AreEqual(nameof(control.Visible), control.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, control.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, control.DataBindings[0].DataSourceUpdateMode);
	}

	private static IEnumerable<object[]> TestData()
		=> TestControlFactory.TestData<Control>();
}
