namespace BB84.WinForms.Extensions;

/// <summary>
/// The extension methods for the <see cref="NumericUpDown"/> control.
/// </summary>
public static class NumericUpDownExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property to the specified data source.
	/// </summary>
	/// <param name="numericUpDown">The <see cref="NumericUpDown"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="NumericUpDown"/> control instance, so that multiple calls can be chained.</returns>
	public static NumericUpDown WithEnabledBinding(this NumericUpDown numericUpDown, object dataSource, string dataMember)
	{
		numericUpDown.DataBindings.Add(nameof(numericUpDown.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return numericUpDown;
	}

	/// <summary>
	/// Binds the <see cref="NumericUpDown.Value"/> property to the specified data source.
	/// </summary>
	/// <param name="numericUpDown">The <see cref="NumericUpDown"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="NumericUpDown"/> control instance, so that multiple calls can be chained.</returns>
	public static NumericUpDown WithValueBinding(this NumericUpDown numericUpDown, object dataSource, string dataMember)
	{
		numericUpDown.DataBindings.Add(nameof(numericUpDown.Value), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return numericUpDown;
	}

	/// <summary>
	/// Binds the <see cref="Control.Visible"/> property to the specified data source.
	/// </summary>
	/// <param name="numericUpDown">The <see cref="NumericUpDown"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="NumericUpDown"/> control instance, so that multiple calls can be chained.</returns>
	public static NumericUpDown WithVisibleBinding(this NumericUpDown numericUpDown, object dataSource, string dataMember)
	{
		numericUpDown.DataBindings.Add(nameof(numericUpDown.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return numericUpDown;
	}
}
