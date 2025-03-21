namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ButtonExtensionsTests
{
	[TestMethod]
	public void WithEnabledBindingTest()
	{
		Button button = new();

		button.WithEnabledBinding(new object(), nameof(button.Enabled));

		Assert.AreEqual(1, button.DataBindings.Count);
		Assert.AreEqual(nameof(button.Enabled), button.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		Button button = new();

		button.WithVisibleBinding(new object(), nameof(button.Visible));

		Assert.AreEqual(1, button.DataBindings.Count);
		Assert.AreEqual(nameof(button.Visible), button.DataBindings[0].PropertyName);
	}
}
