// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.ComponentModel;
using System.Globalization;

using BB84.WinForms.Extensions.Common;

namespace BB84.WinForms.Extensions.Controls;

/// <summary>
/// Represents the shared implementation behind the user controls that display one toggle button
/// per non-zero flag of an enum type marked with the <see cref="FlagsAttribute"/>.
/// </summary>
/// <remarks>
/// The base owns the enum validation, the selection state, the bit arithmetic and the flow layout
/// panel, so <see cref="FlagsCheckBox"/> and <see cref="FlagsRadioButton"/> only contribute the
/// button type and the rule that turns a user interaction into a new set of bits. The class is
/// deliberately not generic, because the Windows Forms designer cannot render a control whose base
/// class is generic.
/// <para>
/// The buttons are created on demand, which means no abstract member is invoked while the base
/// constructor runs. Derived classes must therefore not depend on their own constructor state
/// inside the overridden members, because a value assigned to <see cref="SelectedValue"/> or
/// <see cref="EnumType"/> is the only thing that triggers them.
/// </para>
/// <para>
/// The designer renders an inherited control by instantiating its base class, which it cannot do
/// for an abstract type. <see cref="AbstractControlDescriptionProvider{TAbstract, TConcrete}"/>
/// therefore hands it a <see cref="FlagsCheckBox"/> instead, which affects the designer only.
/// </para>
/// </remarks>
[DefaultBindingProperty(nameof(SelectedValue))]
[TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<FlagsControlBase, FlagsCheckBox>))]
public abstract partial class FlagsControlBase : UserControl
{
	private Type? _enumType;
	private Enum? _selectedValue;
	private Enum? _zeroValue;
	private bool _zeroValueDefined;
	private bool _isUpdatingSelection;
	private bool _suppressSelectedValueChanged;

	/// <summary>
	/// Initializes a new instance of the <see cref="FlagsControlBase"/> control.
	/// </summary>
	protected FlagsControlBase()
	{
		InitializeComponent();
		ApplyFlowDirection();
	}

	/// <summary>
	/// Gets or sets the layout direction used by the internal flow layout panel.
	/// </summary>
	[Category("Layout")]
	[Description("Determines the layout direction used to arrange the flag buttons.")]
	[DefaultValue(FlowDirection.LeftToRight)]
	public FlowDirection FlowDirection
	{
		get;
		set
		{
			if (field == value)
				return;

			field = value;
			ApplyFlowDirection();
		}
	} = FlowDirection.LeftToRight;

	/// <summary>
	/// Gets or sets the delegate used to produce display names for each flag value.
	/// </summary>
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Func<Enum, string>? DisplayNameResolver
	{
		get;
		set
		{
			if (field == value)
				return;

			field = value;
			UpdateDisplayNames();
		}
	}

	/// <summary>
	/// Gets or sets the enum type that defines the flags to be displayed as toggle buttons.
	/// </summary>
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Type? EnumType
	{
		get => _enumType;
		set => SetEnumType(value);
	}

	/// <summary>
	/// Gets or sets the currently selected value, which is a combination of the enum flags
	/// represented by the toggle buttons.
	/// </summary>
	[Browsable(false)]
	[Bindable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Enum? SelectedValue
	{
		get => _selectedValue;
		set
		{
			if (value is null)
			{
				SetSelectedValueToZero();
				return;
			}

			if (_enumType is null)
			{
				// Initializing the type raises the event for the zero value. Suppress it so a
				// caller assigning the very first value observes one change, not two.
				_suppressSelectedValueChanged = true;
				try
				{
					EnumType = value.GetType();
				}
				finally
				{
					_suppressSelectedValueChanged = false;
				}

				// Initializing the type also seeds the selection with the zero value. That is an
				// internal artifact, so it must not make the assignment below look like a no-op
				// when the caller is assigning the zero value itself.
				_selectedValue = null;
			}

			if (value.GetType() != _enumType)
				throw new ArgumentException($"Selected value must be of type {_enumType}.", nameof(value));

			long numericValue = Convert.ToInt64(value, CultureInfo.InvariantCulture);
			if (numericValue == 0 && !_zeroValueDefined)
				throw new ArgumentException("Selected value cannot be zero because the enum does not define a zero-valued flag.", nameof(value));

			Enum newValue = numericValue == 0 && _zeroValue is not null ? _zeroValue : value;

			if (Equals(_selectedValue, newValue))
				return;

			_selectedValue = newValue;
			UpdateButtonsFromValue();
			OnSelectedValueChanged(EventArgs.Empty);
		}
	}

	/// <summary>
	/// Occurs when the selected value changes.
	/// </summary>
	public event EventHandler? SelectedValueChanged;

	/// <summary>
	/// Is called when the selected value changes, either through user interaction or programmatically.
	/// </summary>
	/// <param name="e">The event data.</param>
	protected virtual void OnSelectedValueChanged(EventArgs e)
		=> SelectedValueChanged?.Invoke(this, e);

	/// <summary>
	/// Creates the toggle button used to represent a single flag value.
	/// </summary>
	/// <remarks>
	/// The caption, the tag and the margin are applied by the base afterwards, so an implementation
	/// only has to provide the concrete type and the settings that are specific to it.
	/// </remarks>
	/// <returns>The newly created toggle button.</returns>
	protected abstract ButtonBase CreateButton();

	/// <summary>
	/// Subscribes the event that signals a user interaction with the specified toggle button.
	/// </summary>
	/// <remarks>
	/// Implementations are expected to attach <see cref="OnButtonToggled"/> to the event that
	/// matches the interaction model of the button.
	/// </remarks>
	/// <param name="button">The toggle button to subscribe to.</param>
	protected abstract void AttachToggleHandler(ButtonBase button);

	/// <summary>
	/// Gets a value indicating whether the specified toggle button is currently checked.
	/// </summary>
	/// <param name="button">The toggle button to inspect.</param>
	/// <returns>
	/// <see langword="true"/> if the button is checked; otherwise, <see langword="false"/>.
	/// </returns>
	protected abstract bool GetChecked(ButtonBase button);

	/// <summary>
	/// Sets the checked state of the specified toggle button.
	/// </summary>
	/// <param name="button">The toggle button to modify.</param>
	/// <param name="value">The checked state to apply.</param>
	protected abstract void SetChecked(ButtonBase button, bool value);

	/// <summary>
	/// Calculates the selected bits that result from a user interaction with the specified toggle button.
	/// </summary>
	/// <param name="currentBits">The bits of the currently selected value.</param>
	/// <param name="flagBits">The bits of the flag the toggle button represents.</param>
	/// <param name="button">The toggle button the user interacted with.</param>
	/// <returns>The bits of the value that becomes the new selection.</returns>
	protected abstract long ComputeNewBits(long currentBits, long flagBits, ButtonBase button);

	/// <summary>
	/// Is called when the user interacts with one of the toggle buttons and applies the selection
	/// that <see cref="ComputeNewBits(long, long, ButtonBase)"/> returns.
	/// </summary>
	/// <param name="sender">The toggle button that raised the event.</param>
	/// <param name="e">The event data.</param>
	protected void OnButtonToggled(object? sender, EventArgs e)
	{
		if (_isUpdatingSelection)
			return;

		if (_enumType is null || sender is not ButtonBase button || button.Tag is not Enum flagValue)
			return;

		long flagBits = Convert.ToInt64(flagValue, CultureInfo.InvariantCulture);

		if (flagBits == 0)
			return;

		long currentBits = _selectedValue is not null
			? Convert.ToInt64(_selectedValue, CultureInfo.InvariantCulture)
			: 0;

		long newBits = ComputeNewBits(currentBits, flagBits, button);

		if (newBits == 0)
		{
			// _enumType is non null here, so SetEnumType has already guaranteed a zero value.
			SelectedValue = _zeroValue;
			return;
		}

		var newValue = (Enum)Enum.ToObject(_enumType, newBits);
		SelectedValue = newValue;
	}

	private void RaiseSelectedValueChanged()
	{
		if (_suppressSelectedValueChanged)
			return;

		OnSelectedValueChanged(EventArgs.Empty);
	}

	private void SetEnumType(Type? value)
	{
		if (value == _enumType)
			return;

		_zeroValueDefined = false;
		_zeroValue = null;

		if (value is not null)
		{
			if (!value.IsEnum)
				throw new ArgumentException("EnumType must be an enum type.", nameof(value));

			if (!Attribute.IsDefined(value, typeof(FlagsAttribute)))
				throw new ArgumentException("EnumType must be decorated with FlagsAttribute.", nameof(value));

			foreach (Enum enumValue in Enum.GetValues(value))
			{
				if (Convert.ToInt64(enumValue, CultureInfo.InvariantCulture) == 0)
				{
					_zeroValueDefined = true;
					_zeroValue = enumValue;
					break;
				}
			}

			if (!_zeroValueDefined)
				throw new ArgumentException("EnumType must define a zero-valued flag to represent no selection.", nameof(value));
		}

		_enumType = value;
		BuildButtons();

		if (_enumType is null)
		{
			if (_selectedValue is not null)
			{
				_selectedValue = null;
				UpdateButtonsFromValue();
				RaiseSelectedValueChanged();
			}
			return;
		}

		if (_selectedValue is null || _selectedValue.GetType() != _enumType)
		{
			_selectedValue = _zeroValue;
			UpdateButtonsFromValue();
			RaiseSelectedValueChanged();
		}
	}

	private void BuildButtons()
	{
		if (flowLayoutPanel is null)
			return;

		flowLayoutPanel.SuspendLayout();
		try
		{
			// Disposing a control detaches it from its parent, which mutates this very
			// collection. Walk it backwards by index so the enumerator is never invalidated.
			for (int index = flowLayoutPanel.Controls.Count - 1; index >= 0; index--)
				flowLayoutPanel.Controls[index].Dispose();

			flowLayoutPanel.Controls.Clear();

			if (_enumType is null)
				return;

			foreach (Enum flagValue in Enum.GetValues(_enumType))
			{
				if (Convert.ToInt64(flagValue, CultureInfo.InvariantCulture) == 0)
					continue;

				ButtonBase button = CreateButton();
				button.AutoSize = true;
				button.Text = ResolveDisplayName(flagValue);
				button.Tag = flagValue;
				button.Margin = new Padding(3);

				AttachToggleHandler(button);
				flowLayoutPanel.Controls.Add(button);
			}
		}
		finally
		{
			flowLayoutPanel.ResumeLayout();
		}

		UpdateButtonsFromValue();
		UpdateDisplayNames();
	}

	private void UpdateButtonsFromValue()
	{
		if (flowLayoutPanel is null)
			return;

		_isUpdatingSelection = true;
		try
		{
			foreach (Control control in flowLayoutPanel.Controls)
			{
				if (control is ButtonBase button && button.Tag is Enum value)
				{
					SetChecked(button, IsFlagSet(_selectedValue, value));
				}
			}
		}
		finally
		{
			_isUpdatingSelection = false;
		}
	}

	private void SetSelectedValueToZero()
	{
		if (!_zeroValueDefined || _zeroValue is null)
		{
			if (_selectedValue is not null)
			{
				_selectedValue = null;
				UpdateButtonsFromValue();
				RaiseSelectedValueChanged();
			}
			return;
		}

		if (Equals(_selectedValue, _zeroValue))
			return;

		_selectedValue = _zeroValue;
		UpdateButtonsFromValue();
		RaiseSelectedValueChanged();
	}

	private static bool IsFlagSet(Enum? currentValue, Enum flagValue)
	{
		if (currentValue is null)
			return false;

		long currentBits = Convert.ToInt64(currentValue, CultureInfo.InvariantCulture);
		long flagBits = Convert.ToInt64(flagValue, CultureInfo.InvariantCulture);
		return flagBits != 0 && (currentBits & flagBits) == flagBits;
	}

	private string ResolveDisplayName(Enum value)
		=> DisplayNameResolver?.Invoke(value) ?? value.ToString();

	private void UpdateDisplayNames()
	{
		if (flowLayoutPanel is null)
			return;

		foreach (Control control in flowLayoutPanel.Controls)
		{
			if (control is ButtonBase button && button.Tag is Enum value)
				button.Text = ResolveDisplayName(value);
		}
	}

	private void ApplyFlowDirection()
	{
		if (flowLayoutPanel is null || flowLayoutPanel.FlowDirection == FlowDirection)
			return;

		flowLayoutPanel.FlowDirection = FlowDirection;
	}
}
