namespace BB84.WinForms.Extensions;

/// <summary>
/// The extension methods for the <see cref="ListView"/> control.
/// </summary>
public static class ListViewExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property to the specified data source.
	/// </summary>
	/// <param name="listView">The <see cref="ListView"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="ListView"/> control instance, so that multiple calls can be chained.</returns>
	public static ListView WithEnabledBinding(this ListView listView, object dataSource, string dataMember)
	{
		listView.DataBindings.Add(nameof(listView.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return listView;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property to the specified data source.
	/// </summary>
	/// <param name="listView">The <see cref="ListView"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="ListView"/> control instance, so that multiple calls can be chained.</returns>
	public static ListView WithVisibleBinding(this ListView listView, object dataSource, string dataMember)
	{
		listView.DataBindings.Add(nameof(listView.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return listView;
	}
}
