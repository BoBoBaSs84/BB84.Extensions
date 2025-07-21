// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Reflection;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ControlExtensionsTests
{
	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithEnabledBinding_ShouldBindEnabledProperty(Control control)
	{
		var dataSource = new { Enabled = true };

		control.WithEnabledBinding(dataSource, nameof(dataSource.Enabled));

		Assert.AreEqual(1, control.DataBindings.Count);
		Assert.AreEqual(nameof(control.Enabled), control.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, control.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, control.DataBindings[0].DataSourceUpdateMode);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithTagBinding_ShouldBindEnabledProperty(Control control)
	{
		var dataSource = new { Tag = new object() };

		control.WithTagBinding(dataSource, nameof(dataSource.Tag));

		Assert.AreEqual(1, control.DataBindings.Count);
		Assert.AreEqual(nameof(control.Tag), control.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, control.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, control.DataBindings[0].DataSourceUpdateMode);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithTextBinding_ShouldBindTextProperty(Control control)
	{
		var dataSource = new { Text = "Test" };

		control.WithTextBinding(dataSource, nameof(dataSource.Text));

		Assert.AreEqual(1, control.DataBindings.Count);
		Assert.AreEqual(nameof(control.Text), control.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, control.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, control.DataBindings[0].DataSourceUpdateMode);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithVisibleBinding_ShouldBindVisibleProperty(Control control)
	{
		var dataSource = new { Visible = true };

		control.WithVisibleBinding(dataSource, nameof(dataSource.Visible));

		Assert.AreEqual(1, control.DataBindings.Count);
		Assert.AreEqual(nameof(control.Visible), control.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, control.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, control.DataBindings[0].DataSourceUpdateMode);
	}

	private static List<Control> GetControls()
	{
		Assembly assembly = typeof(Control).Assembly;

		IEnumerable<Type> types = assembly.GetTypes()
			.Where(t => typeof(Control).IsAssignableFrom(t) && !t.IsAbstract);

		List<Control> controls = [];

		foreach (Type type in types)
		{
			try
			{
				if (Activator.CreateInstance(type) is Control control)
					controls.Add(control);
			}
			catch (Exception ex)
			{
				// Handle exceptions for types that cannot be instantiated
				Console.WriteLine($"Could not create instance of {type.Name}: {ex.Message}");
			}
		}

		return controls;
	}

	private static IEnumerable<object[]> TestData()
	{
		foreach (Control control in GetControls())
			yield return new object[] { control };
	}
}
