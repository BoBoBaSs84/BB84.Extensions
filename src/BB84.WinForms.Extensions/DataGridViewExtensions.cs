namespace BB84.WinForms.Extensions;

/// <summary>
/// The extension methods for the <see cref="DataGridView"/> control.
/// </summary>
public static class DataGridViewExtensions
{
	/// <summary>
	/// Binds the <see cref="DataGridView.DataSource"/> property to the specified data source.
	/// </summary>
	/// <param name="dataGridView">The <see cref="DataGridView"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <returns>The same <see cref="DataGridView"/> control instance, so that multiple calls can be chained.</returns>
	public static DataGridView WithDataSource(this DataGridView dataGridView, object dataSource)
	{
		dataGridView.DataSource = dataSource;
		return dataGridView;
	}

	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property to the specified data source.
	/// </summary>
	/// <param name="dataGridView">The <see cref="DataGridView"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="DataGridView"/> control instance, so that multiple calls can be chained.</returns>
	public static DataGridView WithEnabledBinding(this DataGridView dataGridView, object dataSource, string dataMember)
	{
		dataGridView.DataBindings.Add(nameof(dataGridView.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return dataGridView;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property to the specified data source.
	/// </summary>
	/// <param name="dataGridView">The <see cref="DataGridView"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="DataGridView"/> control instance, so that multiple calls can be chained.</returns>
	public static DataGridView WithVisibleBinding(this DataGridView dataGridView, object dataSource, string dataMember)
	{
		dataGridView.DataBindings.Add(nameof(dataGridView.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return dataGridView;
	}
}
