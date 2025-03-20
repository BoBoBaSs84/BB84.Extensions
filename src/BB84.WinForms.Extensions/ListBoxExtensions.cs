namespace BB84.WinForms.Extensions;

/// <summary>
/// The extension methods for the <see cref="ListBox"/> control.
/// </summary>
public static class ListBoxExtensions
{
	/// <summary>
	/// Binds the <see cref="ListControl.DataSource"/> property to the specified data source.
	/// </summary>
	/// <param name="listBox">The <see cref="ListBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <returns>The same <see cref="ListBox"/> control instance, so that multiple calls can be chained.</returns>
	public static ListBox WithDataSource(this ListBox listBox, object dataSource)
	{
		listBox.DataSource = dataSource;
		return listBox;
	}

	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property to the specified data source.
	/// </summary>
	/// <param name="listBox">The <see cref="ListBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="ListBox"/> control instance, so that multiple calls can be chained.</returns>
	public static ListBox WithEnabledBinding(this ListBox listBox, object dataSource, string dataMember)
	{
		listBox.DataBindings.Add(nameof(listBox.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return listBox;
	}

	/// <summary>
	/// Binds the <see cref="ListBox.SelectedItem"/> property to the specified data source.
	/// </summary>
	/// <param name="listBox">The <see cref="ListBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="ListBox"/> control instance, so that multiple calls can be chained.</returns>
	public static ListBox WithSelectedItemBinding(this ListBox listBox, object dataSource, string dataMember)
	{
		listBox.DataBindings.Add(nameof(listBox.SelectedItem), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return listBox;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property to the specified data source.
	/// </summary>
	/// <param name="listBox">The <see cref="ListBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="ListBox"/> control instance, so that multiple calls can be chained.</returns>
	public static ListBox WithVisibleBinding(this ListBox listBox, object dataSource, string dataMember)
	{
		listBox.DataBindings.Add(nameof(listBox.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return listBox;
	}
}
