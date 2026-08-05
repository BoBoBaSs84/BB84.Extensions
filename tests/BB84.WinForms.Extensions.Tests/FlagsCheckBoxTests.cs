// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.WinForms.Extensions.Controls;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class FlagsCheckBoxTests
{
	[TestMethod]
	public void ReassigningTheEnumTypeShouldRebuildTheCheckBoxes()
	{
		using FlagsCheckBox control = new() { EnumType = typeof(TestEnumerator) };

		// Rebuilding disposes the existing children, which detaches them from the very
		// collection being walked. This threw InvalidOperationException before.
		control.EnumType = typeof(OtherEnumerator);

		Assert.AreEqual(typeof(OtherEnumerator), control.EnumType);
	}

	[TestMethod]
	public void AssigningTheFirstSelectedValueShouldRaiseTheChangedEventOnce()
	{
		using FlagsCheckBox control = new();
		int raised = 0;
		control.SelectedValueChanged += (sender, args) => raised++;

		control.SelectedValue = TestEnumerator.FirstFlag;

		Assert.AreEqual(1, raised);
		Assert.AreEqual(TestEnumerator.FirstFlag, control.SelectedValue);
	}

	[TestMethod]
	public void TheFlowDirectionGetterShouldReportWhatTheSetterAccepted()
	{
		using FlagsCheckBox control = new();

		Assert.AreEqual(FlowDirection.LeftToRight, control.FlowDirection);

		control.FlowDirection = FlowDirection.TopDown;

		Assert.AreEqual(FlowDirection.TopDown, control.FlowDirection);
	}

	[TestMethod]
	public void AssigningANonEnumTypeShouldThrow()
	{
		using FlagsCheckBox control = new();

		Assert.Throws<ArgumentException>(() => control.EnumType = typeof(int));
	}

	[TestMethod]
	public void AssigningAnEnumWithoutFlagsAttributeShouldThrow()
	{
		using FlagsCheckBox control = new();

		Assert.Throws<ArgumentException>(() => control.EnumType = typeof(NotFlaggedEnumerator));
	}

	[TestMethod]
	public void AssigningAnEnumWithoutAZeroValueShouldThrow()
	{
		using FlagsCheckBox control = new();

		Assert.Throws<ArgumentException>(() => control.EnumType = typeof(NoZeroEnumerator));
	}

	[TestMethod]
	public void AssigningAValueOfADifferentEnumShouldThrow()
	{
		using FlagsCheckBox control = new() { EnumType = typeof(TestEnumerator) };

		Assert.Throws<ArgumentException>(() => control.SelectedValue = OtherEnumerator.Alpha);
	}

	[TestMethod]
	public void SettingTheSelectedValueToNullShouldFallBackToTheZeroValue()
	{
		using FlagsCheckBox control = new() { SelectedValue = TestEnumerator.FirstFlag };

		control.SelectedValue = null;

		Assert.AreEqual(TestEnumerator.None, control.SelectedValue);
	}

	[Flags]
	private enum TestEnumerator
	{
		None = 0,
		FirstFlag = 1,
		SecondFlag = 2
	}

	[Flags]
	private enum OtherEnumerator
	{
		None = 0,
		Alpha = 1,
		Beta = 2
	}

	private enum NotFlaggedEnumerator
	{
		None = 0,
		First = 1
	}

	[Flags]
	private enum NoZeroEnumerator
	{
		First = 1,
		Second = 2
	}
}
