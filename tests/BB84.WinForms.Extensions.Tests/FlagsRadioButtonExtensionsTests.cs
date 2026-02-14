using BB84.WinForms.Extensions.Controls;
using BB84.WinForms.Extensions.Helpers;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class FlagsRadioButtonExtensionsTests
{
	[TestMethod]
	public void WithDescriptionNameTest()
	{
		FlagsRadioButton radioButton = new();

		radioButton.WithDescriptionName();

		Assert.AreEqual(FlagsDisplayResolvers.FromDescriptionAttribute, radioButton.DisplayNameResolver);
	}

	[TestMethod]
	public void WithDisplayNameTest()
	{
		FlagsRadioButton radioButton = new();

		radioButton.WithDisplayName();

		Assert.AreEqual(FlagsDisplayResolvers.FromDisplayAttribute, radioButton.DisplayNameResolver);
	}

	[TestMethod]
	public void WithDisplayNameResolverTest()
	{
		static string Resolver(Enum e) => $"Flag: {e}";
		FlagsRadioButton radioButton = new();

		radioButton.WithDisplayNameResolver(Resolver);

		Assert.AreEqual(Resolver, radioButton.DisplayNameResolver);
	}

	[TestMethod]
	public void WithDisplayNameResolverNullResolverThrowsArgumentNullException()
	{
		FlagsRadioButton radioButton = new();

		Assert.Throws<ArgumentNullException>(() => radioButton.WithDisplayNameResolver(null!));
	}

	[TestMethod]
	public void WithFlowDirectionTest()
	{
		FlagsRadioButton radioButton = new();

		radioButton.WithFlowDirection(FlowDirection.RightToLeft);

		Assert.AreEqual(FlowDirection.RightToLeft, radioButton.FlowDirection);
	}

	[TestMethod]
	public void WithSelectedValueBindingTest()
	{
		var datasource = new { SelectedFlag = TestEnumerator.FirstFlag };

		FlagsRadioButton radioButton = new FlagsRadioButton() { SelectedValue = TestEnumerator.FirstFlag }
			.WithSelectedValueBinding(datasource, nameof(datasource.SelectedFlag));

		Assert.IsNotNull(radioButton);
		Assert.AreEqual(TestEnumerator.FirstFlag, radioButton.SelectedValue);
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
