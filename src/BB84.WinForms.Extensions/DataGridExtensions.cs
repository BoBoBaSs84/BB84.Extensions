namespace BB84.WinForms.Extensions;

#if NETFRAMEWORK
/// <summary>
/// The extension methods for the <see cref="DataGrid"/> control.
/// </summary>
public static class DataGridExtensions
{
	/// <summary>
	/// Binds the <see cref="DataGrid.DataSource"/> property to the specified data source.
	/// </summary>
	/// <param name="dataGrid">The <see cref="DataGrid"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <returns>The same <see cref="DataGrid"/> control instance, so that multiple calls can be chained.</returns>
	public static DataGrid WithDataSource(this DataGrid dataGrid, object dataSource)
	{
		dataGrid.DataSource = dataSource;
		return dataGrid;
	}

	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property to the specified data source.
	/// </summary>
	/// <param name="dataGrid">The <see cref="DataGrid"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="DataGrid"/> control instance, so that multiple calls can be chained.</returns>
	public static DataGrid WithEnabledBinding(this DataGrid dataGrid, object dataSource, string dataMember)
	{
		dataGrid.DataBindings.Add(nameof(dataGrid.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return dataGrid;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property to the specified data source.
	/// </summary>
	/// <param name="dataGrid">The <see cref="DataGrid"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="DataGrid"/> control instance, so that multiple calls can be chained.</returns>
	public static DataGrid WithVisibleBinding(this DataGrid dataGrid, object dataSource, string dataMember)
	{
		dataGrid.DataBindings.Add(nameof(dataGrid.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return dataGrid;
	}
}
#endif
