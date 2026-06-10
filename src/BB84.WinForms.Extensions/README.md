[![net472](https://img.shields.io/badge/net472-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Notifications)
[![net481](https://img.shields.io/badge/net481-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Notifications)
[![net80](https://img.shields.io/badge/net8.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Notifications)
[![net100](https://img.shields.io/badge/net10.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Notifications)

# BB84.WinForms.Extensions

Specialized extension methods for Windows Forms controls, focusing on simplified data binding.
All binding methods follow the same fluent `With*Binding(dataSource, dataMember)` convention and return the
control instance so calls can be chained.

## 🧰 Usage

### Control extensions

`ControlExtensions` targets the base `Control` class and is therefore available on every WinForms control.

```csharp
textBox1
    .WithTextBinding(vm, nameof(vm.Name))
    .WithEnabledBinding(vm, nameof(vm.IsEditable))
    .WithVisibleBinding(vm, nameof(vm.IsVisible))
    .WithTagBinding(vm, nameof(vm.Tag));
```

### ButtonBase extensions

`ButtonBaseExtensions` adds `ICommand` binding and data-source–based command binding for `Button`,
`CheckBox`, `RadioButton`, and any other `ButtonBase`-derived control.

```csharp
// Bind an ICommand directly — wires Click and CanExecuteChanged automatically
saveButton.WithCommandBinding(viewModel.SaveCommand);

// Bind a command property from a data source (.NET 5+ targets)
saveButton.WithCommandBinding(viewModel, nameof(viewModel.SaveCommand));

// Bind a command parameter from a data source (.NET 5+ targets)
saveButton.WithCommandParameterBinding(viewModel, nameof(viewModel.CommandParameter));
```

### CheckBox extensions

```csharp
checkBox1
    .WithCheckedBinding(vm, nameof(vm.IsSelected))
    .WithCheckStateBinding(vm, nameof(vm.CheckState))
    .WithCheckAlignBinding(vm, nameof(vm.Alignment));
```

### ComboBox extensions

```csharp
comboBox1
    .WithDataSourceBinding(categories)                          // set items
    .WithDisplayMember(nameof(Category.Name))
    .WithValueMember(nameof(Category.Id))
    .WithSelectedItemBinding(vm, nameof(vm.SelectedCategory))
    .WithSelectedIndexBinding(vm, nameof(vm.SelectedIndex));
```

### DataGrid / DataGridView extensions

```csharp
dataGrid1.WithDataSourceBinding(dataTable);
dataGridView1.WithDataSourceBinding(bindingList);
```

### DateTimePicker extensions

```csharp
dateTimePicker1
    .WithValueBinding(vm, nameof(vm.SelectedDate))
    .WithCheckedBinding(vm, nameof(vm.HasDate));
```

### FlagsCheckBox control

`FlagsCheckBox` is a composite user control that renders one `CheckBox` per non-zero flag value of a
`[Flags]` enum and keeps a `SelectedValue` property in sync.

```csharp
// Fluent configuration
flagsCheckBox1
    .WithDisplayName()                                  // use DisplayAttribute.Name for labels
    .WithFlowDirection(FlowDirection.TopDown)
    .WithSelectedValueBinding(vm, nameof(vm.Permissions));

// Or use description attribute labels
flagsCheckBox1.WithDescriptionName();

// Custom label resolver
flagsCheckBox1.WithDisplayNameResolver(e => e.ToString().ToUpper());
```

### FlagsRadioButton control

`FlagsRadioButton` is the single-selection counterpart of `FlagsCheckBox` — one radio button per
non-zero flag, bound to a single enum value.

```csharp
flagsRadioButton1
    .WithDisplayName()
    .WithFlowDirection(FlowDirection.LeftToRight)
    .WithSelectedValueBinding(vm, nameof(vm.AccessLevel));
```

### ListBox extensions

```csharp
listBox1
    .WithDataSourceBinding(items)
    .WithSelectedItemBinding(vm, nameof(vm.SelectedItem))
    .WithSelectedIndexBinding(vm, nameof(vm.SelectedIndex));
```

### ListControl extensions

`ListControlExtensions` targets the base `ListControl` class (`ComboBox`, `ListBox`, and any derived type).

```csharp
comboBox1
    .WithDataSourceBinding(items)
    .WithDisplayMember(nameof(Item.Label))
    .WithValueMember(nameof(Item.Id))
    .WithSelectedValueBinding(vm, nameof(vm.SelectedId));

// Populate from an enum type
comboBox1.WithEnumeratorBinding(MyEnum.Default);
```

### MonthCalendar extensions

```csharp
monthCalendar1.WithSelectionRangeBinding(vm, nameof(vm.DateRange));
```

### NumericUpDown extensions

```csharp
numericUpDown1
    .WithValueBinding(vm, nameof(vm.Count))
    .WithMinimumBinding(vm, nameof(vm.MinCount))
    .WithMaximumBinding(vm, nameof(vm.MaxCount))
    .WithIncrementBinding(vm, nameof(vm.Step))
    .WithDecimalPlacesBinding(vm, nameof(vm.Precision));
```

### PictureBox extensions

```csharp
pictureBox1.WithImageBinding(vm, nameof(vm.Photo));
```

### ProgressBar extensions

```csharp
progressBar1.WithValueBinding(vm, nameof(vm.Progress));
```

### RadioButton extensions

```csharp
radioButton1.WithCheckedBinding(vm, nameof(vm.IsOptionA));
```

### ScrollBar extensions

```csharp
hScrollBar1.WithValueBinding(vm, nameof(vm.ScrollPosition));
vScrollBar1.WithValueBinding(vm, nameof(vm.ScrollPosition));
```

### ToolStripItem extensions

Available on .NET 8 and later. Targets `ToolStripButton`, `ToolStripMenuItem`, and any other
`ToolStripItem`-derived class.

```csharp
toolStripButton1
    .WithEnabledBinding(vm, nameof(vm.CanSave))
    .WithTextBinding(vm, nameof(vm.SaveLabel))
    .WithVisibleBinding(vm, nameof(vm.ShowSave));
```

### TrackBar extensions

```csharp
trackBar1.WithValueBinding(vm, nameof(vm.Volume));
```

## 📖 Documentation

The complete API documentation can be found [here](https://bobobass84.github.io/BB84.Extensions/api/index.html).
