// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.ComponentModel;

namespace BB84.WinForms.Extensions.Controls;

/// <summary>
/// Represents a user control that displays a set of check boxes for selecting multiple values
/// of an enum type marked with the <see cref="FlagsAttribute"/>.
/// </summary>
/// <remarks>
/// Use to bind to an enum type with the <see cref="FlagsAttribute"/>, allowing users to select
/// one or more flags. The control requires the enum to define a zero-valued flag to represent no
/// selection. Each check box carries its own flag, so the selection accumulates the flags of all
/// checked boxes.
/// </remarks>
public class FlagsCheckBox : FlagsControlBase
{
	/// <inheritdoc/>
	protected override ButtonBase CreateButton()
		=> new CheckBox();

	/// <inheritdoc/>
	protected override void AttachToggleHandler(ButtonBase button)
		=> ((CheckBox)button).CheckedChanged += OnButtonToggled;

	/// <inheritdoc/>
	protected override bool GetChecked(ButtonBase button)
		=> ((CheckBox)button).Checked;

	/// <inheritdoc/>
	protected override void SetChecked(ButtonBase button, bool value)
		=> ((CheckBox)button).Checked = value;

	/// <inheritdoc/>
	/// <remarks>
	/// The check box has already toggled itself when the event arrives, so the new bits follow
	/// the checked state of the button instead of inverting the current selection.
	/// </remarks>
	protected override long ComputeNewBits(long currentBits, long flagBits, bool isChecked)
		=> isChecked ? currentBits | flagBits : currentBits & ~flagBits;
}
