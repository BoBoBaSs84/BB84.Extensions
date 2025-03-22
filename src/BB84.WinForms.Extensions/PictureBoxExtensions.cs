namespace BB84.WinForms.Extensions;

/// <summary>
/// The extension methods for the <see cref="PictureBox"/> control.
/// </summary>
public static class PictureBoxExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property to the specified data source.
	/// </summary>
	/// <param name="pictureBox">The <see cref="PictureBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="PictureBox"/> control instance, so that multiple calls can be chained.</returns>
	public static PictureBox WithEnabledBinding(this PictureBox pictureBox, object dataSource, string dataMember)
	{
		pictureBox.DataBindings.Add(nameof(pictureBox.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return pictureBox;
	}

	/// <summary>
	/// Binds the <see cref="PictureBox.ErrorImage"/> property to the specified data source.
	/// </summary>
	/// <param name="pictureBox">The <see cref="PictureBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="PictureBox"/> control instance, so that multiple calls can be chained.</returns>
	public static PictureBox WithErrorImageBinding(this PictureBox pictureBox, object dataSource, string dataMember)
	{
		pictureBox.DataBindings.Add(nameof(pictureBox.ErrorImage), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return pictureBox;
	}

	/// <summary>
	/// Binds the <see cref="PictureBox.Image"/> property to the specified data source.
	/// </summary>
	/// <param name="pictureBox">The <see cref="PictureBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="PictureBox"/> control instance, so that multiple calls can be chained.</returns>
	public static PictureBox WithImageBinding(this PictureBox pictureBox, object dataSource, string dataMember)
	{
		pictureBox.DataBindings.Add(nameof(pictureBox.Image), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return pictureBox;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property to the specified data source.
	/// </summary>
	/// <param name="pictureBox">The <see cref="PictureBox"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="PictureBox"/> control instance, so that multiple calls can be chained.</returns>
	public static PictureBox WithVisibleBinding(this PictureBox pictureBox, object dataSource, string dataMember)
	{
		pictureBox.DataBindings.Add(nameof(pictureBox.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return pictureBox;
	}
}
