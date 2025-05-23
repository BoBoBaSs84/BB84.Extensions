// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for binding properties of a <see cref="NumericUpDown"/> control to a data source,
/// enabling streamlined data binding for common properties such as <see cref="Control.Enabled"/>,
/// <see cref="TreeView.SelectedNode"/> and <see cref="Control.Visible"/>.
/// </summary>
/// <remarks>
/// These extension methods simplify the process of binding <see cref="TreeView"/> properties to a data
/// source by encapsulating the creation of <see cref="Binding"/> objects.
/// Each method returns the same <see cref="TreeView"/> instance, allowing for method chaining.
/// </remarks>
public static class TreeViewExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property of the specified <see cref="TreeView"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Enabled"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="treeView">The <see cref="TreeView"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="TreeView"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static TreeView WithEnabledBinding(this TreeView treeView, object dataSource, string dataMember)
	{
		treeView.DataBindings.Add(nameof(treeView.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return treeView;
	}

	/// <summary>
	/// Binds the <see cref="TreeView.SelectedNode"/> property of the specified <see cref="TreeView"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="TreeView.SelectedNode"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="treeView">The <see cref="TreeView"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="TreeView"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static TreeView WithSelectedNodeBinding(this TreeView treeView, object dataSource, string dataMember)
	{
		treeView.DataBindings.Add(nameof(treeView.SelectedNode), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return treeView;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property of the specified <see cref="TreeView"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Visible"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="treeView">The <see cref="TreeView"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="TreeView"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static TreeView WithVisibleBinding(this TreeView treeView, object dataSource, string dataMember)
	{
		treeView.DataBindings.Add(nameof(treeView.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return treeView;
	}
}
