// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.WinForms.Extensions.Tests.Common;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class RadioButtonExtensionsTests
{
	[TestMethod]
	public void WithCheckedBindingTest()
	{
		var dataSource = new { Checked = false };
		using RadioButton radioButton = new();

		radioButton.WithCheckedBinding(dataSource, nameof(radioButton.Checked));

		BindingAssert.IsSingleBinding(radioButton, nameof(radioButton.Checked), dataSource);
	}
}
