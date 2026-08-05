// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class BindableComponentExtensionsTests
{
	[TestMethod]
	public void WithBindingShouldApplyTheSameDefaultsAsThePropertySpecificMethods()
	{
		var dataSource = new { Title = "caption" };
		using Label label = new();

		label.WithBinding(nameof(label.Text), dataSource, nameof(dataSource.Title));

		Assert.HasCount(1, label.DataBindings);
		Assert.AreEqual(nameof(label.Text), label.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, label.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, label.DataBindings[0].DataSourceUpdateMode);
		Assert.IsTrue(label.DataBindings[0].FormattingEnabled);
	}

	[TestMethod]
	public void WithBindingShouldHonourANonDefaultUpdateMode()
	{
		var dataSource = new { Title = "caption" };
		using Label label = new();

		label.WithBinding(nameof(label.Text), dataSource, nameof(dataSource.Title), formattingEnabled: false, updateMode: DataSourceUpdateMode.Never);

		Assert.AreEqual(DataSourceUpdateMode.Never, label.DataBindings[0].DataSourceUpdateMode);
		Assert.IsFalse(label.DataBindings[0].FormattingEnabled);
	}

#if NET8_0_OR_GREATER
	[TestMethod]
	public void WithBindingShouldAlsoWorkForComponentsThatAreNotControls()
	{
		var dataSource = new { Caption = "caption" };
		using ToolStripButton button = new();

		button.WithBinding(nameof(button.Text), dataSource, nameof(dataSource.Caption));

		Assert.HasCount(1, button.DataBindings);
		Assert.AreEqual(nameof(button.Text), button.DataBindings[0].PropertyName);
	}
#endif

	[TestMethod]
	public void WithBindingShouldThrowWhenTheDataSourceIsNull()
	{
		using Label label = new();

		Assert.Throws<ArgumentNullException>(() => label.WithBinding(nameof(label.Text), null!, "Title"));
	}

	[TestMethod]
	public void WithTextBindingShouldThrowWhenTheDataSourceIsNull()
	{
		using Label label = new();

		Assert.Throws<ArgumentNullException>(() => label.WithTextBinding(null!, "Title"));
	}

	// Note: there is deliberately no test here asserting that a bound value actually propagates.
	// A WinForms binding only resolves its data member once the control has a live binding
	// manager, which needs a real message loop; assigning a BindingContext, parenting onto a
	// Form, forcing handle creation and calling Binding.ReadValue all leave it dormant. That is
	// why a wrong data member cannot be caught here, and why DateTimePickerExtensionsTests bound
	// a member its data source did not have while still passing. Catching that class of mistake
	// needs a UI test host, not another unit test.
}
