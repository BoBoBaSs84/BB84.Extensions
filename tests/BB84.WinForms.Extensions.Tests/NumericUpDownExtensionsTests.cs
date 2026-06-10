// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class NumericUpDownExtensionsTests
{
	[TestMethod]
	public void WithValueBindingTest()
	{
		var dataSource = new { Value = 1 };
		NumericUpDown numericUpDown = new();

		numericUpDown.WithValueBinding(dataSource, nameof(numericUpDown.Value));

		Assert.HasCount(1, numericUpDown.DataBindings);
		Assert.AreEqual(nameof(numericUpDown.Value), numericUpDown.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, numericUpDown.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, numericUpDown.DataBindings[0].DataSourceUpdateMode);
	}

	[TestMethod]
	public void WithMinimumBindingTest()
	{
		var dataSource = new { Minimum = 0m };
		NumericUpDown numericUpDown = new();

		numericUpDown.WithMinimumBinding(dataSource, nameof(numericUpDown.Minimum));

		Assert.HasCount(1, numericUpDown.DataBindings);
		Assert.AreEqual(nameof(numericUpDown.Minimum), numericUpDown.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, numericUpDown.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, numericUpDown.DataBindings[0].DataSourceUpdateMode);
	}

	[TestMethod]
	public void WithMaximumBindingTest()
	{
		var dataSource = new { Maximum = 100m };
		NumericUpDown numericUpDown = new();

		numericUpDown.WithMaximumBinding(dataSource, nameof(numericUpDown.Maximum));

		Assert.HasCount(1, numericUpDown.DataBindings);
		Assert.AreEqual(nameof(numericUpDown.Maximum), numericUpDown.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, numericUpDown.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, numericUpDown.DataBindings[0].DataSourceUpdateMode);
	}

	[TestMethod]
	public void WithIncrementBindingTest()
	{
		var dataSource = new { Increment = 1m };
		NumericUpDown numericUpDown = new();

		numericUpDown.WithIncrementBinding(dataSource, nameof(numericUpDown.Increment));

		Assert.HasCount(1, numericUpDown.DataBindings);
		Assert.AreEqual(nameof(numericUpDown.Increment), numericUpDown.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, numericUpDown.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, numericUpDown.DataBindings[0].DataSourceUpdateMode);
	}

	[TestMethod]
	public void WithDecimalPlacesBindingTest()
	{
		var dataSource = new { DecimalPlaces = 2 };
		NumericUpDown numericUpDown = new();

		numericUpDown.WithDecimalPlacesBinding(dataSource, nameof(numericUpDown.DecimalPlaces));

		Assert.HasCount(1, numericUpDown.DataBindings);
		Assert.AreEqual(nameof(numericUpDown.DecimalPlaces), numericUpDown.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, numericUpDown.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, numericUpDown.DataBindings[0].DataSourceUpdateMode);
	}
}
