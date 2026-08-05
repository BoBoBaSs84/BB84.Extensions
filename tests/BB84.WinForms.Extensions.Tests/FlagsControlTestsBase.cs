// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.WinForms.Extensions.Controls;

namespace BB84.WinForms.Extensions.Tests;

/// <summary>
/// Covers the behavior that every flags control inherits from <see cref="FlagsControlBase"/>.
/// </summary>
/// <remarks>
/// The class is abstract and carries no test class attribute, so the cases run once per derived
/// control instead of being discovered on their own. Behavior that differs between the controls,
/// which is the reaction to a user interaction, is covered by the derived classes.
/// </remarks>
/// <typeparam name="TControl">The flags control under test.</typeparam>
public abstract class FlagsControlTestsBase<TControl> where TControl : FlagsControlBase, new()
{
	[TestMethod]
	public void ReassigningTheEnumTypeShouldRebuildTheButtons()
	{
		using TControl control = new() { EnumType = typeof(FlagsTestEnumerator) };

		// Rebuilding disposes the existing children, which detaches them from the very
		// collection being walked. This threw InvalidOperationException before.
		control.EnumType = typeof(OtherFlagsTestEnumerator);

		Assert.AreEqual(typeof(OtherFlagsTestEnumerator), control.EnumType);
	}

	[TestMethod]
	public void AssigningTheFirstSelectedValueShouldRaiseTheChangedEventOnce()
	{
		using TControl control = new();
		int raised = 0;
		control.SelectedValueChanged += (sender, args) => raised++;

		control.SelectedValue = FlagsTestEnumerator.FirstFlag;

		Assert.AreEqual(1, raised);
		Assert.AreEqual(FlagsTestEnumerator.FirstFlag, control.SelectedValue);
	}

	[TestMethod]
	public void TheFlowDirectionGetterShouldReportWhatTheSetterAccepted()
	{
		using TControl control = new();

		Assert.AreEqual(FlowDirection.LeftToRight, control.FlowDirection);

		control.FlowDirection = FlowDirection.TopDown;

		Assert.AreEqual(FlowDirection.TopDown, control.FlowDirection);
	}

	[TestMethod]
	public void AssigningANonEnumTypeShouldThrow()
	{
		using TControl control = new();

		Assert.Throws<ArgumentException>(() => control.EnumType = typeof(int));
	}

	[TestMethod]
	public void AssigningAnEnumWithoutFlagsAttributeShouldThrow()
	{
		using TControl control = new();

		Assert.Throws<ArgumentException>(() => control.EnumType = typeof(NotFlaggedTestEnumerator));
	}

	[TestMethod]
	public void AssigningAnEnumWithoutAZeroValueShouldThrow()
	{
		using TControl control = new();

		Assert.Throws<ArgumentException>(() => control.EnumType = typeof(NoZeroTestEnumerator));
	}

	[TestMethod]
	public void AssigningAValueOfADifferentEnumShouldThrow()
	{
		using TControl control = new() { EnumType = typeof(FlagsTestEnumerator) };

		Assert.Throws<ArgumentException>(() => control.SelectedValue = OtherFlagsTestEnumerator.Alpha);
	}

	[TestMethod]
	public void SettingTheSelectedValueToNullShouldFallBackToTheZeroValue()
	{
		using TControl control = new() { SelectedValue = FlagsTestEnumerator.FirstFlag };

		control.SelectedValue = null;

		Assert.AreEqual(FlagsTestEnumerator.None, control.SelectedValue);
	}

	/// <summary>
	/// Returns the toggle buttons the control generated for the non-zero flags, in flag order.
	/// </summary>
	/// <param name="control">The control whose buttons should be returned.</param>
	/// <returns>The generated toggle buttons.</returns>
	protected static IList<ButtonBase> GetFlagButtons(FlagsControlBase control)
		=> [.. control.Controls.OfType<FlowLayoutPanel>().Single().Controls.OfType<ButtonBase>()];
}

[Flags]
internal enum FlagsTestEnumerator
{
	None = 0,
	FirstFlag = 1,
	SecondFlag = 2
}

[Flags]
internal enum OtherFlagsTestEnumerator
{
	None = 0,
	Alpha = 1,
	Beta = 2
}

internal enum NotFlaggedTestEnumerator
{
	None = 0,
	First = 1
}

[Flags]
internal enum NoZeroTestEnumerator
{
	First = 1,
	Second = 2
}
