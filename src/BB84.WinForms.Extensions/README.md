[![net462](https://img.shields.io/badge/net462-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Notifications)
[![net481](https://img.shields.io/badge/net481-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Notifications)
[![net80](https://img.shields.io/badge/net8.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Notifications)
[![net90](https://img.shields.io/badge/net9.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Notifications)

# BB84.WinForms.Extensions

A collection of some WinForms extensions I needed in many projects. It consists of some useful control and dialog extension methods.

## Usage

Depending on the application, there are several ways to skin a cat.

### Bindings

On the 'TextBox', for example, the text, whether the 'TextBox' is active or even whether the 'TextBox' is visible or not can be configured using the extension methods.
The same applies to the NumericUpDown control. At a 'ComboBox' control, for example, the data source and the selected item can be bound to a property.

```csharp
/// <summary>
/// The character form class.
/// </summary>
public partial class CharacterForm : Form
{
	private readonly CharacterViewModel _viewModel;

	/// <summary>
	/// Initializes a new instance of the <see cref="CharacterForm"/> class.
	/// </summary>
	/// <param name="viewModel">The character view model instance to use.</param>
	public CharacterForm(CharacterViewModel viewModel)
	{
		InitializeComponent();

		_viewModel = viewModel;

		FirstNameTextBox.WithTextBinding(_viewModel.Model, nameof(_viewModel.Model.FirstName));
		LastNameTextBox.WithTextBinding(_viewModel.Model, nameof(_viewModel.Model.LastName));
		LevelNumericUpDown.WithValueBinding(_viewModel.Model, nameof(_viewModel.Model.Level));
		
		ExperienceNumericUpDown.WithValueBinding(_viewModel.Model, nameof(_viewModel.Model.Experience))
			.WithEnabledBinding(_viewModel, nameof(_viewModel.CanChangeExperience));
		
		CritterComboBox.WithDataSource(_viewModel.CritterTypes)
			.WithSelectedItemBinding(viewModel.Model, nameof(viewModel.Model.CritterType));
	}
}
```

This applies to a lot of standard controls.
