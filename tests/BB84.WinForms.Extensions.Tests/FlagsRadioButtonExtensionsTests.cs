// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.WinForms.Extensions.Controls;
using BB84.WinForms.Extensions.Helpers;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class FlagsRadioButtonExtensionsTests
{
	[TestMethod]
	public void WithDescriptionNameTest()
	{
		using FlagsRadioButton radioButton = new();

		radioButton.WithDescriptionName();

		Assert.AreEqual(FlagsDisplayResolvers.FromDescriptionAttribute, radioButton.DisplayNameResolver);
	}

	[TestMethod]
	public void WithDisplayNameTest()
	{
		using FlagsRadioButton radioButton = new();

		radioButton.WithDisplayName();

		Assert.AreEqual(FlagsDisplayResolvers.FromDisplayAttribute, radioButton.DisplayNameResolver);
	}

	[TestMethod]
	public void WithDisplayNameResolverTest()
	{
		static string Resolver(Enum e) => $"Flag: {e}";
		using FlagsRadioButton radioButton = new();

		radioButton.WithDisplayNameResolver(Resolver);

		Assert.AreEqual(Resolver, radioButton.DisplayNameResolver);
	}

	[TestMethod]
	public void WithDisplayNameResolverNullResolverThrowsArgumentNullException()
	{
		using FlagsRadioButton radioButton = new();

		Assert.Throws<ArgumentNullException>(() => radioButton.WithDisplayNameResolver(null!));
	}

	[TestMethod]
	public void WithFlowDirectionTest()
	{
		using FlagsRadioButton radioButton = new();

		radioButton.WithFlowDirection(FlowDirection.RightToLeft);

		Assert.AreEqual(FlowDirection.RightToLeft, radioButton.FlowDirection);
	}

	[TestMethod]
	public void WithSelectedValueBindingTest()
	{
		var datasource = new { SelectedFlag = TestEnumerator.FirstFlag };

		using FlagsRadioButton radioButton = new FlagsRadioButton() { SelectedValue = TestEnumerator.FirstFlag }
			.WithSelectedValueBinding(datasource, nameof(datasource.SelectedFlag));

		Assert.HasCount(1, radioButton.DataBindings);
		Assert.AreEqual(nameof(radioButton.SelectedValue), radioButton.DataBindings[0].PropertyName);
		Assert.AreEqual(datasource, radioButton.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, radioButton.DataBindings[0].DataSourceUpdateMode);
	}

	[Flags]
	private enum TestEnumerator
	{
		None = 0,
		[System.ComponentModel.Description("First Flag")]
		FirstFlag = 1,
		[System.ComponentModel.Description("Second Flag")]
		SecondFlag = 2,
		[System.ComponentModel.Description("Third Flag")]
		ThirdFlag = 4
	}
}
