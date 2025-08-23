// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Reflection;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ListControlExtensionsTests
{
	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithDataSourceBinding_ShouldBindDataSource(ListControl listControl)
	{
		var dataSource = new List<string> { "Item1", "Item2", "Item3" };

		listControl.WithDataSourceBinding(dataSource);

		Assert.AreEqual(dataSource, listControl.DataSource);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithSelectedValueBinding_ShouldBindSelectedValue(ListControl listControl)
	{
		var dataSource = new { SelectedValue = "Item1" };

		listControl.WithSelectedValueBinding(dataSource, nameof(dataSource.SelectedValue));

		Assert.AreEqual(1, listControl.DataBindings.Count);
		Assert.AreEqual(nameof(listControl.SelectedValue), listControl.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, listControl.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, listControl.DataBindings[0].DataSourceUpdateMode);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithDisplayMember_ShouldSetDisplayMember(ListControl listControl)
	{
		const string displayMember = "Name";
		
		listControl.WithDisplayMember(displayMember);
		
		Assert.AreEqual(displayMember, listControl.DisplayMember);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithValueMember_ShouldSetValueMember(ListControl listControl)
	{
		const string valueMember = "Id";
		
		listControl.WithValueMember(valueMember);
		
		Assert.AreEqual(valueMember, listControl.ValueMember);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithEnumDataSource_ShouldBindEnumDataSource(ListControl listControl)
	{
		listControl.WithEnumeratorBinding(TestEnum.First);
		
		Assert.IsNotNull(listControl.DataSource);
		Assert.AreEqual("Value", listControl.DisplayMember);
		Assert.AreEqual("Key", listControl.ValueMember);
	}

	private static List<ListControl> GetListControls()
	{
		Assembly assembly = typeof(ListControl).Assembly;

		IEnumerable<Type> types = assembly.GetTypes()
			.Where(t => typeof(ListControl).IsAssignableFrom(t) && !t.IsAbstract);

		List<ListControl> controls = [];

		foreach (Type type in types)
		{
			try
			{
				if (Activator.CreateInstance(type) is ListControl control)
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
		foreach (ListControl control in GetListControls())
			yield return new object[] { control };
	}

	private enum TestEnum
	{
		First,
		Second,
		Third
	}
}
