using BB84.WinForms.Extensions.Controls;
using BB84.WinForms.Extensions.Helpers;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class FlagsCheckBoxExtensionsTests
{
	[TestMethod]
	public void WithDescriptionNameTest()
	{
		FlagsCheckBox checkBox = new();

		checkBox.WithDescriptionName();

		Assert.AreEqual(FlagsDisplayResolvers.FromDescriptionAttribute, checkBox.DisplayNameResolver);
	}

	[TestMethod]
	public void WithDisplayNameTest()
	{
		FlagsCheckBox checkBox = new();

		checkBox.WithDisplayName();

		Assert.AreEqual(FlagsDisplayResolvers.FromDisplayAttribute, checkBox.DisplayNameResolver);
	}

	[TestMethod]
	public void WithDisplayNameResolverTest()
	{
		static string Resolver(Enum e) => $"Flag: {e}";
		FlagsCheckBox checkBox = new();

		checkBox.WithDisplayNameResolver(Resolver);

		Assert.AreEqual(Resolver, checkBox.DisplayNameResolver);
	}

	[TestMethod]
	public void WithDisplayNameResolverNullResolverThrowsArgumentNullException()
	{
		FlagsCheckBox checkBox = new();

		Assert.Throws<ArgumentNullException>(() => checkBox.WithDisplayNameResolver(null!));
	}

	[TestMethod]
	public void WithFlowDirectionTest()
	{
		FlagsCheckBox checkBox = new();

		checkBox.WithFlowDirection(FlowDirection.RightToLeft);

		Assert.AreEqual(FlowDirection.RightToLeft, checkBox.FlowDirection);
	}

	[TestMethod]
	public void WithSelectedValueBindingTest()
	{
		var datasource = new { SelectedFlag = TestEnumerator.None };

		FlagsCheckBox checkBox = new FlagsCheckBox() { SelectedValue = TestEnumerator.FirstFlag }
			.WithSelectedValueBinding(datasource, nameof(datasource.SelectedFlag));

		Assert.IsNotNull(checkBox);
		Assert.AreEqual(TestEnumerator.FirstFlag, checkBox.SelectedValue);
	}

	[Flags]
	private enum TestEnumerator
	{
		None = 0,
		[System.ComponentModel.DataAnnotations.Display(Name = "First Flag")]
		FirstFlag = 1,
		[System.ComponentModel.DataAnnotations.Display(Name = "Second Flag")]
		SecondFlag = 2,
		[System.ComponentModel.DataAnnotations.Display(Name = "Third Flag")]
		ThirdFlag = 4
	}
}
