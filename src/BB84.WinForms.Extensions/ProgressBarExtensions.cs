namespace BB84.WinForms.Extensions;

/// <summary>
/// The extension methods for the <see cref="ProgressBar"/> control.
/// </summary>
public static class ProgressBarExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property to the specified data source.
	/// </summary>
	/// <param name="progressBar">The <see cref="ProgressBar"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="ProgressBar"/> control instance, so that multiple calls can be chained.</returns>
	public static ProgressBar WithEnabledBinding(this ProgressBar progressBar, object dataSource, string dataMember)
	{
		progressBar.DataBindings.Add(nameof(progressBar.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return progressBar;
	}

	/// <summary>
	/// Binds the <see cref="ProgressBar.Maximum"/> property to the specified data source.
	/// </summary>
	/// <param name="progressBar">The <see cref="ProgressBar"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="ProgressBar"/> control instance, so that multiple calls can be chained.</returns>
	public static ProgressBar WithMaximumBinding(this ProgressBar progressBar, object dataSource, string dataMember)
	{
		progressBar.DataBindings.Add(nameof(progressBar.Maximum), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return progressBar;
	}

	/// <summary>
	/// Binds the <see cref="ProgressBar.Minimum"/> property to the specified data source.
	/// </summary>
	/// <param name="progressBar">The <see cref="ProgressBar"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="ProgressBar"/> control instance, so that multiple calls can be chained.</returns>
	public static ProgressBar WithMinimumBinding(this ProgressBar progressBar, object dataSource, string dataMember)
	{
		progressBar.DataBindings.Add(nameof(progressBar.Minimum), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return progressBar;
	}

	/// <summary>
	/// Binds the <see cref="ProgressBar.Value"/> property to the specified data source.
	/// </summary>
	/// <param name="progressBar">The <see cref="ProgressBar"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="ProgressBar"/> control instance, so that multiple calls can be chained.</returns>
	public static ProgressBar WithValueBinding(this ProgressBar progressBar, object dataSource, string dataMember)
	{
		progressBar.DataBindings.Add(nameof(progressBar.Value), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return progressBar;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property to the specified data source.
	/// </summary>
	/// <param name="progressBar">The <see cref="ProgressBar"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="ProgressBar"/> control instance, so that multiple calls can be chained.</returns>
	public static ProgressBar WithVisibleBinding(this ProgressBar progressBar, object dataSource, string dataMember)
	{
		progressBar.DataBindings.Add(nameof(progressBar.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return progressBar;
	}
}
