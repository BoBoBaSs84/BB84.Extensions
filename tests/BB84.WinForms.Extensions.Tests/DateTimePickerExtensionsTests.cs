// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.WinForms.Extensions.Tests.Common;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class DateTimePickerExtensionsTests
{
	[TestMethod]
	public void WithCheckedBindingShouldBindChecked()
	{
		var dataSource = new { Checked = false };
		using DateTimePicker dateTimePicker = new();

		dateTimePicker.WithCheckedBinding(dataSource, nameof(dataSource.Checked));

		BindingAssert.IsSingleBinding(dateTimePicker, nameof(dateTimePicker.Checked), dataSource);
	}

	[TestMethod]
	public void WithValueBindingShouldBindValue()
	{
		var dataSource = new { Value = DateTime.MinValue };
		using DateTimePicker dateTimePicker = new();

		dateTimePicker.WithValueBinding(dataSource, nameof(dataSource.Value));

		BindingAssert.IsSingleBinding(dateTimePicker, nameof(dateTimePicker.Value), dataSource);
	}
}
