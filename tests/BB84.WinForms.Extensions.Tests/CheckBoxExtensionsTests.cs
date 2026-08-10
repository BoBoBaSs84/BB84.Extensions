// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.WinForms.Extensions.Tests.Common;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class CheckBoxExtensionsTests
{
	[TestMethod]
	public void WithCheckedBindingShouldBindChecked()
	{
		var dataSource = new { Checked = false };
		using CheckBox checkBox = new();

		checkBox.WithCheckedBinding(dataSource, nameof(checkBox.Checked));

		BindingAssert.IsSingleBinding(checkBox, nameof(checkBox.Checked), dataSource);
	}
#if NET5_0_OR_GREATER

	[TestMethod]
	public void WithCheckStateBindingShouldBindCheckState()
	{
		var dataSource = new { CheckState = CheckState.Unchecked };
		using CheckBox checkBox = new();

		checkBox.WithCheckStateBinding(dataSource, nameof(checkBox.CheckState));

		BindingAssert.IsSingleBinding(checkBox, nameof(checkBox.CheckState), dataSource);
	}

	[TestMethod]
	public void WithCheckAlignBindingShouldBindCheckAlign()
	{
		var dataSource = new { CheckAlign = ContentAlignment.MiddleLeft };
		using CheckBox checkBox = new();

		checkBox.WithCheckAlignBinding(dataSource, nameof(checkBox.CheckAlign));

		BindingAssert.IsSingleBinding(checkBox, nameof(checkBox.CheckAlign), dataSource);
	}
#endif
}
