// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.WinForms.Extensions.Tests.Common;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ControlExtensionsTests
{
	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithEnabledBindingShouldBindEnabledProperty(Type type)
	{
		using Control control = TestControlFactory.Create<Control>(type);
		var dataSource = new { Enabled = true };

		control.WithEnabledBinding(dataSource, nameof(dataSource.Enabled));

		BindingAssert.IsSingleBinding(control, nameof(control.Enabled), dataSource);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithTagBindingShouldBindEnabledProperty(Type type)
	{
		using Control control = TestControlFactory.Create<Control>(type);
		var dataSource = new { Tag = new object() };

		control.WithTagBinding(dataSource, nameof(dataSource.Tag));

		BindingAssert.IsSingleBinding(control, nameof(control.Tag), dataSource);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithTextBindingShouldBindTextProperty(Type type)
	{
		using Control control = TestControlFactory.Create<Control>(type);
		var dataSource = new { Text = "Test" };

		control.WithTextBinding(dataSource, nameof(dataSource.Text));

		BindingAssert.IsSingleBinding(control, nameof(control.Text), dataSource);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithVisibleBindingShouldBindVisibleProperty(Type type)
	{
		using Control control = TestControlFactory.Create<Control>(type);
		var dataSource = new { Visible = true };

		control.WithVisibleBinding(dataSource, nameof(dataSource.Visible));

		BindingAssert.IsSingleBinding(control, nameof(control.Visible), dataSource);
	}

	private static IEnumerable<object[]> TestData()
		=> TestControlFactory.TestData<Control>();
}
