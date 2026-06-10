// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
#if NET8_0_OR_GREATER
namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="ToolStripItem"/> class to simplify data binding.
/// </summary>
/// <remarks>
/// This class includes methods to bind common properties of a <see cref="ToolStripItem"/>, such as
/// <see cref="ToolStripItem.Enabled"/>, <see cref="ToolStripItem.Text"/> and
/// <see cref="ToolStripItem.Visible"/>, to a specified data source. These methods return the same
/// <see cref="ToolStripItem"/> instance, allowing for method chaining.
/// </remarks>
public static class ToolStripItemExtensions
{
	/// <summary>
	/// Binds the <see cref="ToolStripItem.Enabled"/> property of the specified <see cref="ToolStripItem"/> to a
	/// property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="ToolStripItem.Enabled"/>
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="item">The <see cref="ToolStripItem"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ToolStripItem"/> with the binding applied, allowing for method chaining.
	/// </returns>
	public static ToolStripItem WithEnabledBinding(this ToolStripItem item, object dataSource, string dataMember)
	{
		item.DataBindings.Add(nameof(item.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return item;
	}

	/// <summary>
	/// Binds the <see cref="ToolStripItem.Text"/> property of the specified <see cref="ToolStripItem"/> to a
	/// property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="ToolStripItem.Text"/>
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="item">The <see cref="ToolStripItem"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ToolStripItem"/> with the binding applied, allowing for method chaining.
	/// </returns>
	public static ToolStripItem WithTextBinding(this ToolStripItem item, object dataSource, string dataMember)
	{
		item.DataBindings.Add(nameof(item.Text), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return item;
	}

	/// <summary>
	/// Binds the <see cref="ToolStripItem.Visible"/> property of the specified <see cref="ToolStripItem"/> to a
	/// property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="ToolStripItem.Visible"/>
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="item">The <see cref="ToolStripItem"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ToolStripItem"/> with the binding applied, allowing for method chaining.
	/// </returns>
	public static ToolStripItem WithVisibleBinding(this ToolStripItem item, object dataSource, string dataMember)
	{
		item.DataBindings.Add(nameof(item.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return item;
	}
}
#endif
