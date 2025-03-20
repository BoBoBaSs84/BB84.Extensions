namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ComboBoxExtensionsTests
{
	[TestMethod]
	public void WithDataSourceTest()
	{
		ComboBox comboBox = new();

		comboBox.WithDataSource(new List<int>());

		Assert.IsNotNull(comboBox.DataSource);
		Assert.IsInstanceOfType<List<int>>(comboBox.DataSource);
	}

	[TestMethod]
	public void WithEnabledBindingTest()
	{
		ComboBox comboBox = new();

		comboBox.WithEnabledBinding(new object(), nameof(comboBox.Enabled));

		Assert.AreEqual(1, comboBox.DataBindings.Count);
		Assert.AreEqual(nameof(comboBox.Enabled), comboBox.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithSelectedItemBindingTest()
	{
		ComboBox comboBox = new();

		comboBox.WithSelectedItemBinding(new object(), nameof(comboBox.SelectedItem));

		Assert.AreEqual(1, comboBox.DataBindings.Count);
		Assert.AreEqual(nameof(comboBox.SelectedItem), comboBox.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		ComboBox comboBox = new();

		comboBox.WithVisibleBinding(new object(), nameof(comboBox.Visible));

		Assert.AreEqual(1, comboBox.DataBindings.Count);
		Assert.AreEqual(nameof(comboBox.Visible), comboBox.DataBindings[0].PropertyName);
	}
}
