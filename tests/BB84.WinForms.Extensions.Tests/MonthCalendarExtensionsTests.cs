namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class MonthCalendarExtensionsTests
{
	[TestMethod]
	public void WithEnabledBindingTest()
	{
		MonthCalendar monthCalendar = new();

		monthCalendar.WithEnabledBinding(new object(), nameof(monthCalendar.Enabled));

		Assert.AreEqual(1, monthCalendar.DataBindings.Count);
		Assert.AreEqual(nameof(monthCalendar.Enabled), monthCalendar.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithSelectionStartBindingTest()
	{
		MonthCalendar monthCalendar = new();

		monthCalendar.WithSelectionStartBinding(new object(), nameof(monthCalendar.SelectionStart));

		Assert.AreEqual(1, monthCalendar.DataBindings.Count);
		Assert.AreEqual(nameof(monthCalendar.SelectionStart), monthCalendar.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithSelectionEndBindingTest()
	{
		MonthCalendar monthCalendar = new();

		monthCalendar.WithSelectionEndBinding(new object(), nameof(monthCalendar.SelectionEnd));

		Assert.AreEqual(1, monthCalendar.DataBindings.Count);
		Assert.AreEqual(nameof(monthCalendar.SelectionEnd), monthCalendar.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		MonthCalendar monthCalendar = new();

		monthCalendar.WithVisibleBinding(new object(), nameof(monthCalendar.Visible));

		Assert.AreEqual(1, monthCalendar.DataBindings.Count);
		Assert.AreEqual(nameof(monthCalendar.Visible), monthCalendar.DataBindings[0].PropertyName);
	}
}
