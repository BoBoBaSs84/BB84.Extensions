namespace BB84.WinForms.Extensions;

/// <summary>
/// The extension methods for the <see cref="CheckBox"/> control.
/// </summary>
public static class CheckBoxExtensions
{
	/// <summary>
	/// Binds the <see cref="CheckBox.Checked"/> property to the specified data source.
	/// </summary>
	/// <param name="checkBox">The <see cref="CheckBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="CheckBox"/> control instance, so that multiple calls can be chained.</returns>
	public static CheckBox WithCheckedBinding(this CheckBox checkBox, object dataSource, string dataMember)
	{
		checkBox.DataBindings.Add(nameof(checkBox.Checked), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return checkBox;
	}

	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property to the specified data source.
	/// </summary>
	/// <param name="checkBox">The <see cref="CheckBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="CheckBox"/> control instance, so that multiple calls can be chained.</returns>
	public static CheckBox WithEnabledBinding(this CheckBox checkBox, object dataSource, string dataMember)
	{
		checkBox.DataBindings.Add(nameof(checkBox.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return checkBox;
	}

	/// <summary>
	/// Binds the <see cref="Control.Text"/> property to the specified data source.
	/// </summary>
	/// <param name="checkBox">The <see cref="CheckBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="CheckBox"/> control instance, so that multiple calls can be chained.</returns>
	public static CheckBox WithTextBinding(this CheckBox checkBox, object dataSource, string dataMember)
	{
		checkBox.DataBindings.Add(nameof(checkBox.Text), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return checkBox;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property to the specified data source.
	/// </summary>
	/// <param name="checkBox">The <see cref="CheckBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="CheckBox"/> control instance, so that multiple calls can be chained.</returns>
	public static CheckBox WithVisibleBinding(this CheckBox checkBox, object dataSource, string dataMember)
	{
		checkBox.DataBindings.Add(nameof(checkBox.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return checkBox;
	}
}
