// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
#if NET8_0_OR_GREATER
using System.Reflection;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ToolStripItemExtensionsTests
{
	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithEnabledBindingShouldBindEnabledProperty(ToolStripItem item)
	{
		var dataSource = new { Enabled = true };

		item.WithEnabledBinding(dataSource, nameof(dataSource.Enabled));

		Assert.HasCount(1, item.DataBindings);
		Assert.AreEqual(nameof(item.Enabled), item.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, item.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, item.DataBindings[0].DataSourceUpdateMode);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithTextBindingShouldBindTextProperty(ToolStripItem item)
	{
		var dataSource = new { Text = "Test" };

		item.WithTextBinding(dataSource, nameof(dataSource.Text));

		Assert.HasCount(1, item.DataBindings);
		Assert.AreEqual(nameof(item.Text), item.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, item.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, item.DataBindings[0].DataSourceUpdateMode);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithVisibleBindingShouldBindVisibleProperty(ToolStripItem item)
	{
		var dataSource = new { Visible = true };

		item.WithVisibleBinding(dataSource, nameof(dataSource.Visible));

		Assert.HasCount(1, item.DataBindings);
		Assert.AreEqual(nameof(item.Visible), item.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, item.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, item.DataBindings[0].DataSourceUpdateMode);
	}

	private static List<ToolStripItem> GetToolStripItems()
	{
		Assembly assembly = typeof(ToolStripItem).Assembly;

		IEnumerable<Type> types = assembly.GetTypes()
			.Where(t => typeof(ToolStripItem).IsAssignableFrom(t) && !t.IsAbstract);

		List<ToolStripItem> items = [];

		foreach (Type type in types)
		{
			try
			{
				if (Activator.CreateInstance(type) is ToolStripItem item)
					items.Add(item);
			}
			catch (Exception ex)
			{
				// Handle exceptions for types that cannot be instantiated
				Console.WriteLine($"Could not create instance of {type.Name}: {ex.Message}");
			}
		}

		return items;
	}

	private static IEnumerable<object[]> TestData()
	{
		foreach (ToolStripItem item in GetToolStripItems())
			yield return new object[] { item };
	}
}
#endif
