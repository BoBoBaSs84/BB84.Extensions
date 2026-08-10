// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.WinForms.Extensions.Tests.Common;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class TrackBarExtensionsTests
{
	[TestMethod]
	public void WithValueBindingTest()
	{
		var dataSource = new { Value = 50 };
		using TrackBar trackBar = new();

		trackBar.WithValueBinding(dataSource, nameof(trackBar.Value));

		BindingAssert.IsSingleBinding(trackBar, nameof(trackBar.Value), dataSource);
	}
}
