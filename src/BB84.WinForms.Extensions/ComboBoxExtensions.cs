namespace BB84.WinForms.Extensions;

/// <summary>
/// The extension methods for the <see cref="ComboBox"/> control.
/// </summary>
public static class ComboBoxExtensions
{
	/// <summary>
	/// Binds the <see cref="ListControl.DataSource"/> property to the specified data source.
	/// </summary>
	/// <param name="comboBox">The <see cref="ComboBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <returns>The same <see cref="ComboBox"/> control instance, so that multiple calls can be chained.</returns>
	public static ComboBox WithDataSource(this ComboBox comboBox, object dataSource)
	{
		comboBox.DataSource = dataSource;
		return comboBox;
	}

	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property to the specified data source.
	/// </summary>
	/// <param name="comboBox">The <see cref="ComboBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="ComboBox"/> control instance, so that multiple calls can be chained.</returns>
	public static ComboBox WithEnabledBinding(this ComboBox comboBox, object dataSource, string dataMember)
	{
		comboBox.DataBindings.Add(nameof(comboBox.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return comboBox;
	}

	/// <summary>
	/// Binds the <see cref="ComboBox.SelectedItem"/> property to the specified data source.
	/// </summary>
	/// <param name="comboBox">The <see cref="ComboBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="ComboBox"/> control instance, so that multiple calls can be chained.</returns>
	public static ComboBox WithSelectedItemBinding(this ComboBox comboBox, object dataSource, string dataMember)
	{
		comboBox.DataBindings.Add(nameof(comboBox.SelectedItem), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return comboBox;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property to the specified data source.
	/// </summary>
	/// <param name="comboBox">The <see cref="ComboBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="ComboBox"/> control instance, so that multiple calls can be chained.</returns>
	public static ComboBox WithVisibleBinding(this ComboBox comboBox, object dataSource, string dataMember)
	{
		comboBox.DataBindings.Add(nameof(comboBox.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return comboBox;
	}
}
