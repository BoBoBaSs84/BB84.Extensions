// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.ComponentModel;

namespace BB84.WinForms.Extensions.Controls;

/// <summary>
/// Represents a user control that displays a set of radio buttons for selecting multiple values
/// of an enum type marked with the <see cref="FlagsAttribute"/>.
/// </summary>
/// <remarks>
/// Use to bind to an enum type with the <see cref="FlagsAttribute"/>, allowing users to select
/// one or more flags. The control requires the enum to define a zero-valued flag to represent no
/// selection. The radio buttons do not check themselves, so a click toggles the flag it carries.
/// </remarks>
public class FlagsRadioButton : FlagsControlBase
{
	/// <inheritdoc/>
	protected override ButtonBase CreateButton()
		=> new RadioButton { AutoCheck = false };

	/// <inheritdoc/>
	protected override void AttachToggleHandler(ButtonBase button)
		=> ((RadioButton)button).Click += OnButtonToggled;

	/// <inheritdoc/>
	protected override bool GetChecked(ButtonBase button)
		=> ((RadioButton)button).Checked;

	/// <inheritdoc/>
	protected override void SetChecked(ButtonBase button, bool value)
		=> ((RadioButton)button).Checked = value;

	/// <inheritdoc/>
	/// <remarks>
	/// <see cref="RadioButton.AutoCheck"/> is disabled, so the button still shows the previous
	/// state when the click arrives. The current selection therefore decides the direction of the
	/// toggle and <paramref name="isChecked"/> is not consulted.
	/// </remarks>
	protected override long ComputeNewBits(long currentBits, long flagBits, bool isChecked)
		=> (currentBits & flagBits) == flagBits ? currentBits & ~flagBits : currentBits | flagBits;
}
