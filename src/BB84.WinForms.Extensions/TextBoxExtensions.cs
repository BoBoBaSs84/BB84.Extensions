namespace BB84.WinForms.Extensions;

/// <summary>
/// The extension methods for the <see cref="TextBox"/> control.
/// </summary>
public static class TextBoxExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property to the specified data source.
	/// </summary>
	/// <param name="textBox">The <see cref="TextBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="TextBox"/> control instance, so that multiple calls can be chained.</returns>
	public static TextBox WithEnabledBinding(this TextBox textBox, object dataSource, string dataMember)
	{
		textBox.DataBindings.Add(nameof(textBox.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return textBox;
	}

	/// <summary>
	/// Binds the <see cref="TextBox.Text"/> property to the specified data source.
	/// </summary>
	/// <param name="textBox">The <see cref="TextBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="TextBox"/> control instance, so that multiple calls can be chained.</returns>
	public static TextBox WithTextBinding(this TextBox textBox, object dataSource, string dataMember)
	{
		textBox.DataBindings.Add(nameof(textBox.Text), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return textBox;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property to the specified data source.
	/// </summary>
	/// <param name="textBox">The <see cref="TextBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="TextBox"/> control instance, so that multiple calls can be chained.</returns>
	public static TextBox WithVisibleBinding(this TextBox textBox, object dataSource, string dataMember)
	{
		textBox.DataBindings.Add(nameof(textBox.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return textBox;
	}
}
