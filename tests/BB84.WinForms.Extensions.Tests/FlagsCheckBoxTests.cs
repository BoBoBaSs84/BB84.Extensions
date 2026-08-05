// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.WinForms.Extensions.Controls;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class FlagsCheckBoxTests : FlagsControlTestsBase<FlagsCheckBox>
{
	[TestMethod]
	public void CheckingTheBoxesShouldAccumulateTheFlags()
	{
		using FlagsCheckBox control = new() { EnumType = typeof(FlagsTestEnumerator) };
		IList<ButtonBase> boxes = GetFlagButtons(control);

		((CheckBox)boxes[0]).Checked = true;

		Assert.AreEqual(FlagsTestEnumerator.FirstFlag, control.SelectedValue);

		((CheckBox)boxes[1]).Checked = true;

		Assert.AreEqual(FlagsTestEnumerator.FirstFlag | FlagsTestEnumerator.SecondFlag, control.SelectedValue);
	}

	[TestMethod]
	public void UncheckingTheBoxesShouldClearTheFlagsDownToTheZeroValue()
	{
		using FlagsCheckBox control = new() { SelectedValue = FlagsTestEnumerator.FirstFlag | FlagsTestEnumerator.SecondFlag };
		IList<ButtonBase> boxes = GetFlagButtons(control);

		((CheckBox)boxes[0]).Checked = false;

		Assert.AreEqual(FlagsTestEnumerator.SecondFlag, control.SelectedValue);

		((CheckBox)boxes[1]).Checked = false;

		Assert.AreEqual(FlagsTestEnumerator.None, control.SelectedValue);
	}

	[TestMethod]
	public void TheBoxesShouldReflectTheSelectedValue()
	{
		using FlagsCheckBox control = new() { SelectedValue = FlagsTestEnumerator.SecondFlag };
		IList<ButtonBase> boxes = GetFlagButtons(control);

		Assert.IsFalse(((CheckBox)boxes[0]).Checked);
		Assert.IsTrue(((CheckBox)boxes[1]).Checked);
	}
}
