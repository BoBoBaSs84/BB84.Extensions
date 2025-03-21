namespace BB84.WinForms.Extensions;

/// <summary>
/// The extension methods for the <see cref="RichTextBox"/> control.
/// </summary>
public static class RichTextBoxExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property to the specified data source.
	/// </summary>
	/// <param name="richTextBox">The <see cref="RichTextBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="TextBox"/> control instance, so that multiple calls can be chained.</returns>
	public static RichTextBox WithEnabledBinding(this RichTextBox richTextBox, object dataSource, string dataMember)
	{
		richTextBox.DataBindings.Add(nameof(richTextBox.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return richTextBox;
	}

	/// <summary>
	/// Binds the <see cref="RichTextBox.Text"/> property to the specified data source.
	/// </summary>
	/// <param name="richTextBox">The <see cref="RichTextBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="RichTextBox"/> control instance, so that multiple calls can be chained.</returns>
	public static RichTextBox WithTextBinding(this RichTextBox richTextBox, object dataSource, string dataMember)
	{
		richTextBox.DataBindings.Add(nameof(richTextBox.Text), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return richTextBox;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property to the specified data source.
	/// </summary>
	/// <param name="richTextBox">The <see cref="RichTextBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="RichTextBox"/> control instance, so that multiple calls can be chained.</returns>
	public static RichTextBox WithVisibleBinding(this RichTextBox richTextBox, object dataSource, string dataMember)
	{
		richTextBox.DataBindings.Add(nameof(richTextBox.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return richTextBox;
	}
}
