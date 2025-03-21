namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class TreeViewExtensionsTests
{
	[TestMethod]
	public void WithEnabledBindingTest()
	{
		TreeView treeView = new();

		treeView.WithEnabledBinding(new object(), nameof(treeView.Enabled));

		Assert.AreEqual(1, treeView.DataBindings.Count);
		Assert.AreEqual(nameof(treeView.Enabled), treeView.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithSelectedNodeBindingTest()
	{
		TreeView treeView = new();

		treeView.WithSelectedNodeBinding(new object(), nameof(treeView.SelectedNode));

		Assert.AreEqual(1, treeView.DataBindings.Count);
		Assert.AreEqual(nameof(treeView.SelectedNode), treeView.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		TreeView treeView = new();

		treeView.WithVisibleBinding(new object(), nameof(treeView.Visible));

		Assert.AreEqual(1, treeView.DataBindings.Count);
		Assert.AreEqual(nameof(treeView.Visible), treeView.DataBindings[0].PropertyName);
	}
}
