// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Reflection;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ScrollBarExtensionsTests
{
	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithValueBindingShouldBindValue(ScrollBar scrollBar)
	{
		var dataSource = new { Value = 50 };

		scrollBar.WithValueBinding(dataSource, nameof(dataSource.Value));

		Assert.AreEqual(1, scrollBar.DataBindings.Count);
		Assert.AreEqual(nameof(scrollBar.Value), scrollBar.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, scrollBar.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, scrollBar.DataBindings[0].DataSourceUpdateMode);
	}

	private static List<ScrollBar> GetControls()
	{
		Assembly assembly = typeof(ScrollBar).Assembly;

		IEnumerable<Type> types = assembly.GetTypes()
			.Where(t => typeof(ScrollBar).IsAssignableFrom(t) && !t.IsAbstract);

		List<ScrollBar> controls = [];

		foreach (Type type in types)
		{
			try
			{
				if (Activator.CreateInstance(type) is ScrollBar control)
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
