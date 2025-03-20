namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class TrackBarExtensionsTests
{
	[TestMethod]
	public void WithEnabledBindingTest()
	{
		TrackBar trackBar = new();

		trackBar.WithEnabledBinding(new object(), nameof(trackBar.Enabled));

		Assert.AreEqual(1, trackBar.DataBindings.Count);
		Assert.AreEqual(nameof(trackBar.Enabled), trackBar.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithMinimumBindingTest()
	{
		TrackBar trackBar = new();

		trackBar.WithMinimumBinding(new object(), nameof(trackBar.Minimum));

		Assert.AreEqual(1, trackBar.DataBindings.Count);
		Assert.AreEqual(nameof(trackBar.Minimum), trackBar.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithMaximumBindingTest()
	{
		TrackBar trackBar = new();

		trackBar.WithMaximumBinding(new object(), nameof(trackBar.Maximum));

		Assert.AreEqual(1, trackBar.DataBindings.Count);
		Assert.AreEqual(nameof(trackBar.Maximum), trackBar.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithValueBindingTest()
	{
		TrackBar trackBar = new();

		trackBar.WithValueBinding(new object(), nameof(trackBar.Value));

		Assert.AreEqual(1, trackBar.DataBindings.Count);
		Assert.AreEqual(nameof(trackBar.Value), trackBar.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		TrackBar trackBar = new();

		trackBar.WithVisibleBinding(new object(), nameof(trackBar.Visible));

		Assert.AreEqual(1, trackBar.DataBindings.Count);
		Assert.AreEqual(nameof(trackBar.Visible), trackBar.DataBindings[0].PropertyName);
	}
}
