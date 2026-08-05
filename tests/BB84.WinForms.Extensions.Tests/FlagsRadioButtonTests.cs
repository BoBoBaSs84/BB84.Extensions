// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.WinForms.Extensions.Controls;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class FlagsRadioButtonTests : FlagsControlTestsBase<FlagsRadioButton>
{
	[TestMethod]
	public void ClickingTheButtonsShouldAccumulateTheFlags()
	{
		using FlagsRadioButton control = new() { EnumType = typeof(FlagsTestEnumerator) };
		IList<ButtonBase> buttons = GetFlagButtons(control);

		((RadioButton)buttons[0]).PerformClick();

		Assert.AreEqual(FlagsTestEnumerator.FirstFlag, control.SelectedValue);

		((RadioButton)buttons[1]).PerformClick();

		Assert.AreEqual(FlagsTestEnumerator.FirstFlag | FlagsTestEnumerator.SecondFlag, control.SelectedValue);
	}

	[TestMethod]
	public void ClickingASelectedButtonShouldToggleItsFlagOff()
	{
		using FlagsRadioButton control = new() { SelectedValue = FlagsTestEnumerator.FirstFlag | FlagsTestEnumerator.SecondFlag };
		IList<ButtonBase> buttons = GetFlagButtons(control);

		((RadioButton)buttons[0]).PerformClick();

		Assert.AreEqual(FlagsTestEnumerator.SecondFlag, control.SelectedValue);

		((RadioButton)buttons[1]).PerformClick();

		Assert.AreEqual(FlagsTestEnumerator.None, control.SelectedValue);
	}

	[TestMethod]
	public void TheButtonsShouldReflectTheSelectedValue()
	{
		using FlagsRadioButton control = new() { SelectedValue = FlagsTestEnumerator.SecondFlag };
		IList<ButtonBase> buttons = GetFlagButtons(control);

		Assert.IsFalse(((RadioButton)buttons[0]).Checked);
		Assert.IsTrue(((RadioButton)buttons[1]).Checked);
	}
}
