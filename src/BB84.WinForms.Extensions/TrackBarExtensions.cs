namespace BB84.WinForms.Extensions;

/// <summary>
/// The extension methods for the <see cref="TrackBar"/> control.
/// </summary>
public static class TrackBarExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property to the specified data source.
	/// </summary>
	/// <param name="trackBar">The <see cref="TrackBar"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="TrackBar"/> control instance, so that multiple calls can be chained.</returns>
	public static TrackBar WithEnabledBinding(this TrackBar trackBar, object dataSource, string dataMember)
	{
		trackBar.DataBindings.Add(nameof(trackBar.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return trackBar;
	}

	/// <summary>
	/// Bind the <see cref="TrackBar.Minimum"/> property to the specified data source.
	/// </summary>
	/// <param name="trackBar">The <see cref="TrackBar"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="TrackBar"/> control instance, so that multiple calls can be chained.</returns>
	public static TrackBar WithMinimumBinding(this TrackBar trackBar, object dataSource, string dataMember)
	{
		trackBar.DataBindings.Add(nameof(trackBar.Minimum), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return trackBar;
	}

	/// <summary>
	/// Bind the <see cref="TrackBar.Maximum"/> property to the specified data source.
	/// </summary>
	/// <param name="trackBar">The <see cref="TrackBar"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="TrackBar"/> control instance, so that multiple calls can be chained.</returns>
	public static TrackBar WithMaximumBinding(this TrackBar trackBar, object dataSource, string dataMember)
	{
		trackBar.DataBindings.Add(nameof(trackBar.Maximum), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return trackBar;
	}

	/// <summary>
	/// Bind the <see cref="TrackBar.Value"/> property to the specified data source.
	/// </summary>
	/// <param name="trackBar">The <see cref="TrackBar"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="TrackBar"/> control instance, so that multiple calls can be chained.</returns>
	public static TrackBar WithValueBinding(this TrackBar trackBar, object dataSource, string dataMember)
	{
		trackBar.DataBindings.Add(nameof(trackBar.Value), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return trackBar;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property to the specified data source.
	/// </summary>
	/// <param name="trackBar">The <see cref="TrackBar"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="TrackBar"/> control instance, so that multiple calls can be chained.</returns>
	public static TrackBar WithVisibleBinding(this TrackBar trackBar, object dataSource, string dataMember)
	{
		trackBar.DataBindings.Add(nameof(trackBar.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return trackBar;
	}
}
