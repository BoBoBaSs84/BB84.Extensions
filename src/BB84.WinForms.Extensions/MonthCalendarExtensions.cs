namespace BB84.WinForms.Extensions;

/// <summary>
/// The extension methods for the <see cref="MonthCalendar"/> control.
/// </summary>
public static class MonthCalendarExtensions
{
	/// <summary>
	/// Binds the <see cref="Control.Enabled"/> property to the specified data source.
	/// </summary>
	/// <param name="monthCalendar">The <see cref="MonthCalendar"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="MonthCalendar"/> control instance, so that multiple calls can be chained.</returns>
	public static MonthCalendar WithEnabledBinding(this MonthCalendar monthCalendar, object dataSource, string dataMember)
	{
		monthCalendar.DataBindings.Add(nameof(monthCalendar.Enabled), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return monthCalendar;
	}

	/// <summary>
	/// Bind the <see cref="MonthCalendar.SelectionStart"/> property to the specified data source.
	/// </summary>
	/// <param name="monthCalendar">The <see cref="MonthCalendar"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="MonthCalendar"/> control instance, so that multiple calls can be chained.</returns>
	public static MonthCalendar WithSelectionStartBinding(this MonthCalendar monthCalendar, object dataSource, string dataMember)
	{
		monthCalendar.DataBindings.Add(nameof(monthCalendar.SelectionStart), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return monthCalendar;
	}

	/// <summary>
	/// Bind the <see cref="MonthCalendar.SelectionEnd"/> property to the specified data source.
	/// </summary>
	/// <param name="monthCalendar">The <see cref="MonthCalendar"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="MonthCalendar"/> control instance, so that multiple calls can be chained.</returns>
	public static MonthCalendar WithSelectionEndBinding(this MonthCalendar monthCalendar, object dataSource, string dataMember)
	{
		monthCalendar.DataBindings.Add(nameof(monthCalendar.SelectionEnd), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return monthCalendar;
	}

	/// <summary>
	/// Bind the <see cref="Control.Visible"/> property to the specified data source.
	/// </summary>
	/// <param name="monthCalendar">The <see cref="MonthCalendar"/> control to bind.</param>
	/// <param name="dataSource">The data source to bind to.</param>
	/// <param name="dataMember">The property of the data source to bind to.</param>
	/// <returns>The same <see cref="MonthCalendar"/> control instance, so that multiple calls can be chained.</returns>
	public static MonthCalendar WithVisibleBinding(this MonthCalendar monthCalendar, object dataSource, string dataMember)
	{
		monthCalendar.DataBindings.Add(nameof(monthCalendar.Visible), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return monthCalendar;
	}
}
