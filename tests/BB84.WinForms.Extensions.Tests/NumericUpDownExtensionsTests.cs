// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.WinForms.Extensions.Tests.Common;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class NumericUpDownExtensionsTests
{
	[TestMethod]
	public void WithValueBindingTest()
	{
		var dataSource = new { Value = 1 };
		using NumericUpDown numericUpDown = new();

		numericUpDown.WithValueBinding(dataSource, nameof(numericUpDown.Value));

		BindingAssert.IsSingleBinding(numericUpDown, nameof(numericUpDown.Value), dataSource);
	}

	[TestMethod]
	public void WithMinimumBindingTest()
	{
		var dataSource = new { Minimum = 0m };
		using NumericUpDown numericUpDown = new();

		numericUpDown.WithMinimumBinding(dataSource, nameof(numericUpDown.Minimum));

		BindingAssert.IsSingleBinding(numericUpDown, nameof(numericUpDown.Minimum), dataSource);
	}

	[TestMethod]
	public void WithMaximumBindingTest()
	{
		var dataSource = new { Maximum = 100m };
		using NumericUpDown numericUpDown = new();

		numericUpDown.WithMaximumBinding(dataSource, nameof(numericUpDown.Maximum));

		BindingAssert.IsSingleBinding(numericUpDown, nameof(numericUpDown.Maximum), dataSource);
	}

	[TestMethod]
	public void WithIncrementBindingTest()
	{
		var dataSource = new { Increment = 1m };
		using NumericUpDown numericUpDown = new();

		numericUpDown.WithIncrementBinding(dataSource, nameof(numericUpDown.Increment));

		BindingAssert.IsSingleBinding(numericUpDown, nameof(numericUpDown.Increment), dataSource);
	}

	[TestMethod]
	public void WithDecimalPlacesBindingTest()
	{
		var dataSource = new { DecimalPlaces = 2 };
		using NumericUpDown numericUpDown = new();

		numericUpDown.WithDecimalPlacesBinding(dataSource, nameof(numericUpDown.DecimalPlaces));

		BindingAssert.IsSingleBinding(numericUpDown, nameof(numericUpDown.DecimalPlaces), dataSource);
	}
}
