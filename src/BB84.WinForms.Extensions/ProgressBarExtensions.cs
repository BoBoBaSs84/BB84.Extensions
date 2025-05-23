// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for binding properties of a <see cref="ProgressBar"/> control to a data source,
/// enabling streamlined data binding for common properties such as <see cref="ProgressBar.Minimum"/>,
/// <see cref="ProgressBar.Maximum"/>, <see cref="ProgressBar.Value"/>, and others.
/// </summary>
/// <remarks>
/// These extension methods simplify the process of binding <see cref="ProgressBar"/> properties to a data
/// source by encapsulating the creation of <see cref="Binding"/> objects.
/// Each method returns the same <see cref="ProgressBar"/> instance, allowing for method chaining.
/// </remarks>
public static class ProgressBarExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property of the specified <see cref="ProgressBar"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Enabled"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="progressBar">The <see cref="ProgressBar"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="TrackBar"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ProgressBar WithEnabledBinding(this ProgressBar progressBar, object dataSource, string dataMember)
	{
		progressBar.DataBindings.Add(nameof(progressBar.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return progressBar;
	}

	/// <summary>
	/// Binds the <see cref="ProgressBar.Maximum"/> property of the specified <see cref="ProgressBar"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="ProgressBar.Maximum"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="progressBar">The <see cref="ProgressBar"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ProgressBar"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ProgressBar WithMaximumBinding(this ProgressBar progressBar, object dataSource, string dataMember)
	{
		progressBar.DataBindings.Add(nameof(progressBar.Maximum), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return progressBar;
	}

	/// <summary>
	/// Binds the <see cref="ProgressBar.Minimum"/> property of the specified <see cref="ProgressBar"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="ProgressBar.Minimum"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="progressBar">The <see cref="ProgressBar"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ProgressBar"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ProgressBar WithMinimumBinding(this ProgressBar progressBar, object dataSource, string dataMember)
	{
		progressBar.DataBindings.Add(nameof(progressBar.Minimum), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return progressBar;
	}

	/// <summary>
	/// Binds the <see cref="ProgressBar.Value"/> property of the specified <see cref="ProgressBar"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="ProgressBar.Value"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="progressBar">The <see cref="ProgressBar"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ProgressBar"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ProgressBar WithValueBinding(this ProgressBar progressBar, object dataSource, string dataMember)
	{
		progressBar.DataBindings.Add(nameof(progressBar.Value), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return progressBar;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property of the specified <see cref="ProgressBar"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="Control.Visible"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="progressBar">The <see cref="ProgressBar"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ProgressBar"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ProgressBar WithVisibleBinding(this ProgressBar progressBar, object dataSource, string dataMember)
	{
		progressBar.DataBindings.Add(nameof(progressBar.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return progressBar;
	}
}
