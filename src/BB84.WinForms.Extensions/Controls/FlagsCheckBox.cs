using System.ComponentModel;
using System.Globalization;

namespace BB84.WinForms.Extensions.Controls;

/// <summary>
/// Represents a user control that displays a set of check boxes for selecting multiple values
/// of an enum type marked with the <see cref="FlagsAttribute"/>.
/// </summary>
/// <remarks>
/// Use to bind to an enum type with the <see cref="FlagsAttribute"/>, allowing users to select
/// one or more flags. The control requires the enum to define a zero-valued flag to represent no
/// selection.
/// </remarks>
[DefaultBindingProperty(nameof(SelectedValue))]
public partial class FlagsCheckBox : UserControl
{
	private Type? _enumType;
	private Enum? _selectedValue;
	private Enum? _zeroValue;
	private bool _zeroValueDefined;
	private bool _isUpdatingSelection;
	private FlowDirection _flowDirection = FlowDirection.LeftToRight;
	private Func<Enum, string>? _displayNameResolver;

	/// <summary>
	/// Initializes a new instance of the <see cref="FlagsCheckBox"/> control.
	/// </summary>
	public FlagsCheckBox()
	{
		InitializeComponent();
		ApplyFlowDirection();
	}

	/// <summary>
	/// Gets or sets the layout direction used by the internal flow layout panel.
	/// </summary>
	[Category("Layout")]
	[Description("Determines the layout direction used to arrange the check boxes.")]
	[DefaultValue(FlowDirection.LeftToRight)]
	public FlowDirection FlowDirection
	{
		get => flowLayoutPanel?.FlowDirection ?? _flowDirection;
		set
		{
			if (_flowDirection == value)
				return;

			_flowDirection = value;
			ApplyFlowDirection();
		}
	}

	/// <summary>
	/// Gets or sets the delegate used to produce display names for each flag value.
	/// </summary>
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Func<Enum, string>? DisplayNameResolver
	{
		get => _displayNameResolver;
		set
		{
			if (_displayNameResolver == value)
				return;

			_displayNameResolver = value;
			UpdateDisplayNames();
		}
	}

	/// <summary>
	/// Gets or sets the enum type that defines the flags to be displayed as check boxes.
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
	/// represented by the check boxes.
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
				EnumType = value.GetType();

			if (value.GetType() != _enumType)
				throw new ArgumentException($"Selected value must be of type {_enumType}.", nameof(value));

			long numericValue = Convert.ToInt64(value, CultureInfo.InvariantCulture);
			if (numericValue == 0 && !_zeroValueDefined)
				throw new ArgumentException("Selected value cannot be zero because the enum does not define a zero-valued flag.", nameof(value));

			Enum newValue = numericValue == 0 && _zeroValue is not null ? _zeroValue : value;

			if (Equals(_selectedValue, newValue))
				return;

			_selectedValue = newValue;
			UpdateCheckBoxesFromValue();
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
		BuildCheckBoxes();

		if (_enumType is null)
		{
			if (_selectedValue is not null)
			{
				_selectedValue = null;
				UpdateCheckBoxesFromValue();
				OnSelectedValueChanged(EventArgs.Empty);
			}
			return;
		}

		if (_selectedValue is null || _selectedValue.GetType() != _enumType)
		{
			_selectedValue = _zeroValue;
			UpdateCheckBoxesFromValue();
			OnSelectedValueChanged(EventArgs.Empty);
		}
	}

	private void BuildCheckBoxes()
	{
		if (flowLayoutPanel is null)
			return;

		flowLayoutPanel.SuspendLayout();
		try
		{
			foreach (Control control in flowLayoutPanel.Controls)
				control.Dispose();

			flowLayoutPanel.Controls.Clear();

			if (_enumType is null)
				return;

			foreach (Enum flagValue in Enum.GetValues(_enumType))
			{
				if (Convert.ToInt64(flagValue, CultureInfo.InvariantCulture) == 0)
					continue;

				var checkBox = new CheckBox
				{
					AutoSize = true,
					Text = ResolveDisplayName(flagValue),
					Tag = flagValue,
					Margin = new Padding(3),
				};

				checkBox.CheckedChanged += HandleCheckBoxCheckedChanged;
				flowLayoutPanel.Controls.Add(checkBox);
			}
		}
		finally
		{
			flowLayoutPanel.ResumeLayout();
		}

		UpdateCheckBoxesFromValue();
		UpdateDisplayNames();
	}

	private void HandleCheckBoxCheckedChanged(object? sender, EventArgs e)
	{
		if (_isUpdatingSelection)
			return;

		if (_enumType is null || sender is not CheckBox checkBox || checkBox.Tag is not Enum flagValue)
			return;

		long flagBits = Convert.ToInt64(flagValue, CultureInfo.InvariantCulture);

		if (flagBits == 0)
			return;

		long currentBits = _selectedValue is not null
			? Convert.ToInt64(_selectedValue, CultureInfo.InvariantCulture)
			: 0;

		long newBits = checkBox.Checked
				? currentBits | flagBits
				: currentBits & ~flagBits;

		if (newBits == 0)
		{
			if (_zeroValue is not null)
			{
				SelectedValue = _zeroValue;
			}
			else
			{
				UpdateCheckBoxesFromValue();
			}
			return;
		}

		var newValue = (Enum)Enum.ToObject(_enumType, newBits);
		SelectedValue = newValue;
	}

	private void UpdateCheckBoxesFromValue()
	{
		if (flowLayoutPanel is null)
			return;

		_isUpdatingSelection = true;
		try
		{
			foreach (Control control in flowLayoutPanel.Controls)
			{
				if (control is CheckBox checkBox && checkBox.Tag is Enum value)
				{
					checkBox.Checked = IsFlagSet(_selectedValue, value);
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
				UpdateCheckBoxesFromValue();
				OnSelectedValueChanged(EventArgs.Empty);
			}
			return;
		}

		if (Equals(_selectedValue, _zeroValue))
			return;

		_selectedValue = _zeroValue;
		UpdateCheckBoxesFromValue();
		OnSelectedValueChanged(EventArgs.Empty);
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
		=> _displayNameResolver?.Invoke(value) ?? value.ToString();

	private void UpdateDisplayNames()
	{
		if (flowLayoutPanel is null)
			return;

		foreach (Control control in flowLayoutPanel.Controls)
		{
			if (control is CheckBox checkBox && checkBox.Tag is Enum value)
				checkBox.Text = ResolveDisplayName(value);
		}
	}

	private void ApplyFlowDirection()
	{
		if (flowLayoutPanel is null || flowLayoutPanel.FlowDirection == _flowDirection)
			return;

		flowLayoutPanel.FlowDirection = _flowDirection;
	}
}
