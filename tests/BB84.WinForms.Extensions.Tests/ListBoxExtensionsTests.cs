namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ListBoxExtensionsTests
{
	[TestMethod]
	public void WithDataSourceTest()
	{
		ListBox listBox = new();

		listBox.WithDataSource(new List<int>());

		Assert.IsNotNull(listBox.DataSource);
		Assert.IsInstanceOfType<List<int>>(listBox.DataSource);
	}

	[TestMethod]
	public void WithEnabledBindingTest()
	{
		ListBox listBox = new();

		listBox.WithEnabledBinding(new object(), nameof(listBox.Enabled));

		Assert.AreEqual(1, listBox.DataBindings.Count);
		Assert.AreEqual(nameof(listBox.Enabled), listBox.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithSelectedItemBindingTest()
	{
		ListBox listBox = new();

		listBox.WithSelectedItemBinding(new object(), nameof(listBox.SelectedItem));

		Assert.AreEqual(1, listBox.DataBindings.Count);
		Assert.AreEqual(nameof(listBox.SelectedItem), listBox.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		ListBox listBox = new();

		listBox.WithVisibleBinding(new object(), nameof(listBox.Visible));

		Assert.AreEqual(1, listBox.DataBindings.Count);
		Assert.AreEqual(nameof(listBox.Visible), listBox.DataBindings[0].PropertyName);
	}
}
