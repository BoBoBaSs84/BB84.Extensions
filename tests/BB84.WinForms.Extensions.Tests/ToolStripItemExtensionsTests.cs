// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
#if NET8_0_OR_GREATER
using BB84.WinForms.Extensions.Tests.Common;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ToolStripItemExtensionsTests
{
	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithEnabledBindingShouldBindEnabledProperty(Type type)
	{
		using ToolStripItem item = TestControlFactory.Create<ToolStripItem>(type);
		var dataSource = new { Enabled = true };

		item.WithEnabledBinding(dataSource, nameof(dataSource.Enabled));

		BindingAssert.IsSingleBinding(item, nameof(item.Enabled), dataSource);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithTextBindingShouldBindTextProperty(Type type)
	{
		using ToolStripItem item = TestControlFactory.Create<ToolStripItem>(type);
		var dataSource = new { Text = "Test" };

		item.WithTextBinding(dataSource, nameof(dataSource.Text));

		BindingAssert.IsSingleBinding(item, nameof(item.Text), dataSource);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithVisibleBindingShouldBindVisibleProperty(Type type)
	{
		using ToolStripItem item = TestControlFactory.Create<ToolStripItem>(type);
		var dataSource = new { Visible = true };

		item.WithVisibleBinding(dataSource, nameof(dataSource.Visible));

		BindingAssert.IsSingleBinding(item, nameof(item.Visible), dataSource);
	}

	private static IEnumerable<object[]> TestData()
		=> TestControlFactory.TestData<ToolStripItem>();
}
#endif
