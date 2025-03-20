namespace BB84.WinForms.Extensions;

/// <summary>
/// The extension methods for the <see cref="TreeView"/> control.
/// </summary>
public static class TreeViewExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property to the specified data source.
	/// </summary>
	/// <param name="treeView">The <see cref="TreeView"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="TreeView"/> control instance, so that multiple calls can be chained.</returns>
	public static TreeView WithEnabledBinding(this TreeView treeView, object dataSource, string dataMember)
	{
		treeView.DataBindings.Add(nameof(treeView.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return treeView;
	}

	/// <summary>
	/// Binds the <see cref="TreeView.SelectedNode"/> property to the specified data source.
	/// </summary>
	/// <param name="treeView">The <see cref="TreeView"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="TreeView"/> control instance, so that multiple calls can be chained.</returns>
	public static TreeView WithSelectedNodeBinding(this TreeView treeView, object dataSource, string dataMember)
	{
		treeView.DataBindings.Add(nameof(treeView.SelectedNode), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return treeView;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property to the specified data source.
	/// </summary>
	/// <param name="treeView">The <see cref="TreeView"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="TreeView"/> control instance, so that multiple calls can be chained.</returns>
	public static TreeView WithVisibleBinding(this TreeView treeView, object dataSource, string dataMember)
	{
		treeView.DataBindings.Add(nameof(treeView.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return treeView;
	}
}
