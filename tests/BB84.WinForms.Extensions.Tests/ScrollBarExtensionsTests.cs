// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
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

		Assert.HasCount(1, scrollBar.DataBindings);
		Assert.AreEqual(nameof(scrollBar.Value), scrollBar.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, scrollBar.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, scrollBar.DataBindings[0].DataSourceUpdateMode);
	}

	private static IEnumerable<object[]> TestData()
		=> TestControlFactory.TestData<ScrollBar>();
}
