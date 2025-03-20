namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class CheckBoxExtensionsTests
{
	[TestMethod]
	public void WithCheckedBindingTest()
	{
		CheckBox checkBox = new();

		checkBox.WithCheckedBinding(new object(), nameof(checkBox.Checked));

		Assert.AreEqual(1, checkBox.DataBindings.Count);
		Assert.AreEqual(nameof(checkBox.Checked), checkBox.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithEnabledBindingTest()
	{
		CheckBox checkBox = new();

		checkBox.WithEnabledBinding(new object(), nameof(checkBox.Enabled));

		Assert.AreEqual(1, checkBox.DataBindings.Count);
		Assert.AreEqual(nameof(checkBox.Enabled), checkBox.DataBindings[0].PropertyName);
	}

	[TestMethod()]
	public void WithTextBindingTest()
	{
		CheckBox checkBox = new();

		checkBox.WithTextBinding(new object(), nameof(checkBox.Text));

		Assert.AreEqual(1, checkBox.DataBindings.Count);
		Assert.AreEqual(nameof(checkBox.Text), checkBox.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		CheckBox checkBox = new();

		checkBox.WithVisibleBinding(new object(), nameof(checkBox.Visible));

		Assert.AreEqual(1, checkBox.DataBindings.Count);
		Assert.AreEqual(nameof(checkBox.Visible), checkBox.DataBindings[0].PropertyName);
	}
}
