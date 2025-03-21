namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class DataGridViewExtensionsTests
{
	[TestMethod]
	public void WithDataSourceTest()
	{
		DataGridView dataGridView = new();

		dataGridView.WithDataSource(new List<int>());

		Assert.IsNotNull(dataGridView.DataSource);
		Assert.IsInstanceOfType<List<int>>(dataGridView.DataSource);
	}

	[TestMethod]
	public void WithEnabledBindingTest()
	{
		DataGridView dataGridView = new();

		dataGridView.WithEnabledBinding(new object(), nameof(dataGridView.Enabled));

		Assert.AreEqual(1, dataGridView.DataBindings.Count);
		Assert.AreEqual(nameof(dataGridView.Enabled), dataGridView.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		DataGridView dataGridView = new();

		dataGridView.WithVisibleBinding(new object(), nameof(dataGridView.Visible));

		Assert.AreEqual(1, dataGridView.DataBindings.Count);
		Assert.AreEqual(nameof(dataGridView.Visible), dataGridView.DataBindings[0].PropertyName);
	}
}
