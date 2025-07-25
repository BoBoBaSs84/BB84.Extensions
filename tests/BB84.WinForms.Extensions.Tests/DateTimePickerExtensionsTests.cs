﻿// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class DateTimePickerExtensionsTests
{
	[TestMethod]
	public void WithCheckedBinding_ShouldBindChecked()
	{
		var dataSource = new { Checked = false };
		DateTimePicker dateTimePicker = new();

		dateTimePicker.WithCheckedBinding(dataSource, nameof(dateTimePicker.Value));

		Assert.AreEqual(1, dateTimePicker.DataBindings.Count);
		Assert.AreEqual(nameof(dateTimePicker.Checked), dateTimePicker.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, dateTimePicker.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, dateTimePicker.DataBindings[0].DataSourceUpdateMode);
	}

	[TestMethod]
	public void WithValueBinding_ShouldBindValue()
	{
		var dataSource = new { Value = DateTime.MinValue };
		DateTimePicker dateTimePicker = new();

		dateTimePicker.WithValueBinding(dataSource, nameof(dateTimePicker.Value));

		Assert.AreEqual(1, dateTimePicker.DataBindings.Count);
		Assert.AreEqual(nameof(dateTimePicker.Value), dateTimePicker.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, dateTimePicker.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, dateTimePicker.DataBindings[0].DataSourceUpdateMode);
	}
}
