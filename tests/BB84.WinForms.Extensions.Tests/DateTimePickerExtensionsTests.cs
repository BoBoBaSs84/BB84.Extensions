namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class DateTimePickerExtensionsTests
{
	[TestMethod]
	public void WithEnabledBindingTest()
	{
		DateTimePicker dateTimePicker = new();

		dateTimePicker.WithEnabledBinding(new object(), nameof(dateTimePicker.Enabled));

		Assert.AreEqual(1, dateTimePicker.DataBindings.Count);
		Assert.AreEqual(nameof(dateTimePicker.Enabled), dateTimePicker.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithValueBindingTest()
	{
		DateTimePicker dateTimePicker = new();

		dateTimePicker.WithValueBinding(new object(), nameof(dateTimePicker.Value));

		Assert.AreEqual(1, dateTimePicker.DataBindings.Count);
		Assert.AreEqual(nameof(dateTimePicker.Value), dateTimePicker.DataBindings[0].PropertyName);
	}

	[TestMethod()]
	public void WithVisibleBindingTest()
	{
		DateTimePicker dateTimePicker = new();

		dateTimePicker.WithVisibleBinding(new object(), nameof(dateTimePicker.Visible));

		Assert.AreEqual(1, dateTimePicker.DataBindings.Count);
		Assert.AreEqual(nameof(dateTimePicker.Visible), dateTimePicker.DataBindings[0].PropertyName);
	}
}
