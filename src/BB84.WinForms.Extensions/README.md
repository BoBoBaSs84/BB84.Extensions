[![net462](https://img.shields.io/badge/net462-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Notifications)
[![net481](https://img.shields.io/badge/net481-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Notifications)
[![net80](https://img.shields.io/badge/net8.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Notifications)
[![net90](https://img.shields.io/badge/net9.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Notifications)

# BB84.WinForms.Extensions

Specialized extension methods for Windows Forms controls, focusing on simplified data binding.

## Usage

Depending on the application, there are several ways to skin a cat.

#### Basic Data Binding

```csharp
using BB84.WinForms.Extensions;

public partial class MyForm : Form
{
    private MyViewModel viewModel = new();

    public MyForm()
    {
        InitializeComponent();
        SetupDataBindings();
    }

    private void SetupDataBindings()
    {
        // Chain multiple bindings
        textBox1
            .BindText(viewModel, nameof(MyViewModel.Name))
            .BindEnabled(viewModel, nameof(MyViewModel.IsEditable))
            .BindVisible(viewModel, nameof(MyViewModel.IsVisible));

        // Bind checkbox
        checkBox1.BindChecked(viewModel, nameof(MyViewModel.IsSelected));

        // Bind combo box
        comboBox1
            .SetDataSource(categories)
            .BindSelectedItem(viewModel, nameof(MyViewModel.SelectedCategory));

        // Bind numeric up/down
        numericUpDown1
            .BindValue(viewModel, nameof(MyViewModel.Count))
            .BindMinimum(viewModel, nameof(MyViewModel.MinCount))
            .BindMaximum(viewModel, nameof(MyViewModel.MaxCount));
    }
}
```

#### Command Binding for Buttons

```csharp
using BB84.WinForms.Extensions;
using System.Windows.Input;

public class MyViewModel : INotifyPropertyChanged
{
    public ICommand SaveCommand { get; private set; }

    public MyViewModel()
    {
        SaveCommand = new RelayCommand(Save, CanSave);
    }

    private void Save() => /* Save logic */;
    private bool CanSave() => /* Validation logic */;
}

// In the form
saveButton.BindCommand(viewModel.SaveCommand);
```

## Documentation

The complete API documentation can be found [here](https://bobobass84.github.io/BB84.Extensions/api/index.html).