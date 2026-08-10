// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.WinForms.Extensions.Tests.Common;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ScrollBarExtensionsTests
{
	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithValueBindingShouldBindValue(Type type)
	{
		using ScrollBar scrollBar = TestControlFactory.Create<ScrollBar>(type);
		var dataSource = new { Value = 50 };

		scrollBar.WithValueBinding(dataSource, nameof(dataSource.Value));

		BindingAssert.IsSingleBinding(scrollBar, nameof(scrollBar.Value), dataSource);
	}

	private static IEnumerable<object[]> TestData()
		=> TestControlFactory.TestData<ScrollBar>();
}
