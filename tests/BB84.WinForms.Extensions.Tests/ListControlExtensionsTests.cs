// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.WinForms.Extensions.Tests.Common;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ListControlExtensionsTests
{
	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithDataSourceBindingShouldBindDataSource(Type type)
	{
		using ListControl listControl = TestControlFactory.Create<ListControl>(type);
		var dataSource = new List<string> { "Item1", "Item2", "Item3" };

		listControl.WithDataSourceBinding(dataSource);

		Assert.AreEquivalent(dataSource, listControl.DataSource);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithSelectedValueBindingShouldBindSelectedValue(Type type)
	{
		using ListControl listControl = TestControlFactory.Create<ListControl>(type);
		var dataSource = new { SelectedValue = "Item1" };

		listControl.WithSelectedValueBinding(dataSource, nameof(dataSource.SelectedValue));

		BindingAssert.IsSingleBinding(listControl, nameof(listControl.SelectedValue), dataSource);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithDisplayMemberShouldSetDisplayMember(Type type)
	{
		using ListControl listControl = TestControlFactory.Create<ListControl>(type);
		const string displayMember = "Name";
		
		listControl.WithDisplayMember(displayMember);
		
		Assert.AreEqual(displayMember, listControl.DisplayMember);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithValueMemberShouldSetValueMember(Type type)
	{
		using ListControl listControl = TestControlFactory.Create<ListControl>(type);
		const string valueMember = "Id";
		
		listControl.WithValueMember(valueMember);
		
		Assert.AreEqual(valueMember, listControl.ValueMember);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithEnumDataSourceShouldBindEnumDataSource(Type type)
	{
		using ListControl listControl = TestControlFactory.Create<ListControl>(type);
		listControl.WithEnumeratorBinding(TestEnum.First);
		
		Assert.IsNotNull(listControl.DataSource);
		Assert.AreEqual("Value", listControl.DisplayMember);
		Assert.AreEqual("Key", listControl.ValueMember);
	}

	private static IEnumerable<object[]> TestData()
		=> TestControlFactory.TestData<ListControl>();

	[TestMethod]
	public void WithEnumeratorBindingShouldCollapseNamesThatAliasTheSameValue()
	{
		using ComboBox comboBox = new();

		comboBox.WithEnumeratorBinding(AliasedEnum.First);

		List<KeyValuePair<AliasedEnum, string>>? items = comboBox.DataSource as List<KeyValuePair<AliasedEnum, string>>;
		Assert.IsNotNull(items);
		Assert.HasCount(2, items);
	}

	private enum TestEnum
	{
		First,
		Second,
		Third
	}

	[Flags]
	private enum AliasedEnum
	{
		None = 0,
		First = 1,
#pragma warning disable CA1069 // Enums values should not be duplicated
		AlsoFirst = 1
#pragma warning restore CA1069 // Enums values should not be duplicated
	}
}
