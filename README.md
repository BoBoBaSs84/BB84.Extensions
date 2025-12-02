# BB84.Extensions

[![CI](https://github.com/BoBoBaSs84/BB84.Extensions/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/BoBoBaSs84/BB84.Extensions/actions/workflows/ci.yml)
[![CD](https://github.com/BoBoBaSs84/BB84.Extensions/actions/workflows/cd.yml/badge.svg?branch=main)](https://github.com/BoBoBaSs84/BB84.Extensions/actions/workflows/cd.yml)
[![CodeQL](https://github.com/BoBoBaSs84/BB84.Extensions/actions/workflows/github-code-scanning/codeql/badge.svg?branch=main)](https://github.com/BoBoBaSs84/BB84.Extensions/actions/workflows/github-code-scanning/codeql)
[![Dependabot](https://github.com/BoBoBaSs84/BB84.Extensions/actions/workflows/dependabot/dependabot-updates/badge.svg?branch=main)](https://github.com/BoBoBaSs84/BB84.Extensions/actions/workflows/dependabot/dependabot-updates)

[![C#](https://img.shields.io/badge/C%23-13.0-239120)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![Issues](https://img.shields.io/github/issues/BoBoBaSs84/BB84.Extensions)](https://github.com/BoBoBaSs84/BB84.Extensions/issues)
[![Commit](https://img.shields.io/github/last-commit/BoBoBaSs84/BB84.Extensions)](https://github.com/BoBoBaSs84/BB84.Extensions/commit/main)
[![License](https://img.shields.io/github/license/BoBoBaSs84/BB84.Extensions)](https://github.com/BoBoBaSs84/BB84.Extensions/blob/main/LICENSE)
[![RepoSize](https://img.shields.io/github/repo-size/BoBoBaSs84/BB84.Extensions)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![Release](https://img.shields.io/github/v/release/BoBoBaSs84/BB84.Extensions)](https://github.com/BoBoBaSs84/BB84.Extensions/releases/latest)

## 🔎 Project Overview

**BB84.Extensions** is a comprehensive collection of extension methods for the .NET framework and Windows Forms applications. The project consists of two main libraries that provide utility methods to simplify common programming tasks and enhance developer productivity.

### Key Features

- **Cross-Platform Compatibility**: Supports multiple .NET target frameworks
- **Comprehensive Coverage**: Extension methods for arrays, strings, dates, colors, HTTP clients, and more
- **Windows Forms Support**: Specialized extensions for WinForms data binding and control manipulation
- **Well-Tested**: Extensive unit test coverage
- **NuGet Packages**: Available as published NuGet packages
- **Strong Naming**: Assemblies are signed for security

### Version Information

- **Current Version**: 4.0.x (versioned using date-based scheme)
- **Author**: Robert Peter Meyer
- **Copyright**: © 2023 Robert Peter Meyer
- **License**: MIT License

## 🏗️ Architecture

### Project Structure

```
BB84.Extensions/
├── src/
│   ├── BB84.Extensions/              # Core extension methods library
│   └── BB84.WinForms.Extensions/     # Windows Forms specific extensions
├── tests/
│   ├── BB84.Extensions.Tests/        # Unit tests for core library
│   └── BB84.WinForms.Extensions.Tests/ # Unit tests for WinForms library
├── docs/                             # Documentation files
└── TestResults/                      # Test execution results
```

### Target Frameworks

The project supports multiple .NET target frameworks to ensure broad compatibility:

#### BB84.Extensions (Core Library)

- .NET Standard 2.0
- .NET Standard 2.1
- .NET Framework 4.7.2
- .NET Framework 4.8.1
- .NET 8.0
- .NET 10.0

#### BB84.WinForms.Extensions

- .NET Framework 4.7.2
- .NET Framework 4.8.1
- .NET 8.0 (Windows)
- .NET 10.0 (Windows)

### Build Configuration

The project uses modern .NET SDK-style project files with:

- **C# Language Version**: Latest
- **Nullable Reference Types**: Enabled
- **Implicit Usings**: Enabled
- **Assembly Signing**: Enabled with public key
- **Documentation Generation**: XML documentation files generated
- **Package Validation**: Enabled for NuGet packages

## 📦 Libraries

### 1. BB84.Extensions

[![net20](https://img.shields.io/badge/netstandard2.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net21](https://img.shields.io/badge/netstandard2.1-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net462](https://img.shields.io/badge/net462-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net481](https://img.shields.io/badge/net481-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net80](https://img.shields.io/badge/net8.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net90](https://img.shields.io/badge/net9.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![NuGet](https://img.shields.io/nuget/v/BB84.Extensions.svg?logo=nuget&logoColor=white)](https://www.nuget.org/packages/BB84.Extensions)

The core extension methods library providing utilities for common .NET types.

#### Extension Categories

**Array Extensions**

- `TakeRandom()` - Returns a randomly selected element from an array

**Boolean Extensions**

- `IsTrue()` - Checks if a boolean value is true
- `IsFalse()` - Checks if a boolean value is false
- `IsNull()` - Checks if a nullable boolean is null

**Byte Extensions**

- `Compress()` - Compresses byte arrays using GZip
- `Decompress()` - Decompresses GZip compressed byte arrays
- `ToBase64()` - Converts byte array to Base64 string
- `FromBase64()` - Converts Base64 string to byte array
- `GetMD5()` - Calculates MD5 hash of byte array
- `GetHexString()` - Converts byte array to hexadecimal string
- `GetString()` - Converts byte array to string using specified encoding

**Color Extensions**

- `ToRGBHexString()` - Converts Color to RGB hex representation
- `ToARGBHexString()` - Converts Color to ARGB hex representation
- `FromRGBHexString()` - Creates Color from RGB hex string
- `FromARGBHexString()` - Creates Color from ARGB hex string
- `ToRgbByteArray()` - Converts Color to RGB byte array
- `ToArgbByteArray()` - Converts Color to ARGB byte array

**Comparable Extensions**

- `IsGreaterThan()` - Checks if value is greater than comparison value
- `IsLessThan()` - Checks if value is less than comparison value
- `IsGreaterOrEqualThan()` - Checks if value is greater than or equal to comparison value
- `IsLessOrEqualThan()` - Checks if value is less than or equal to comparison value

**DateTime Extensions**

- `StartOfWeek()` - Gets the first day of the week
- `EndOfWeek()` - Gets the last day of the week
- `StartOfMonth()` - Gets the first day of the month
- `EndOfMonth()` - Gets the last day of the month
- `StartOfYear()` - Gets the first day of the year
- `EndOfYear()` - Gets the last day of the year
- `StartOfFiscalYear()` - Gets the start of fiscal year
- `EndOfFiscalYear()` - Gets the end of fiscal year
- `WeekOfYear()` - Gets the week number of the year

**Enumerable Extensions**

- `ForEach()` - Executes an action for each element in the enumerable
- `TakeRandom()` - Returns a randomly selected element from enumerable

**HttpClient Extensions**

- `WithBaseAddress()` - Sets the base address for HTTP client
- Additional HTTP configuration methods

**HttpRequestMessage Extensions**

- Bearer token authentication helpers
- Media type configuration methods

**Integer Extensions**

- `ArrayUp()` - Creates an array of integers from current value up to maximum
- `ArrayDown()` - Creates an array of integers from current value down to minimum

**Object Extensions**

- `IsNull()` - Checks if object is null
- `ToBooleanInvariant()` - Converts object to boolean using invariant culture
- `ToDateTimeInvariant()` - Converts object to DateTime using invariant culture

**Stream Extensions**

- `ToByteArray()` - Converts stream to byte array

**String Extensions**

- Various string manipulation and validation methods
- Regular expression helpers

**Task Extensions**

- `ToSafeSync()` - Safely executes async tasks synchronously with error handling

### 2. BB84.WinForms.Extensions

[![net462](https://img.shields.io/badge/net462-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net481](https://img.shields.io/badge/net481-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net80](https://img.shields.io/badge/net8.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net90](https://img.shields.io/badge/net9.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![NuGet](https://img.shields.io/nuget/v/BB84.WinForms.Extensions.svg?logo=nuget&logoColor=white)](https://www.nuget.org/packages/BB84.WinForms.Extensions)

Specialized extension methods for Windows Forms controls, focusing on simplified data binding.

#### Supported Controls

**Button Extensions**

- Command binding support
- Property binding for Enabled, Text, Visible

**CheckBox Extensions**

- Checked property binding

**ComboBox Extensions**

- DataSource binding
- SelectedItem binding

**DataGridView Extensions**

- DataSource binding

**DateTimePicker Extensions**

- Value property binding

**Label Extensions**

- Text property binding

**ListBox Extensions**

- DataSource binding
- SelectedItem binding

**NumericUpDown Extensions**

- Value property binding

**PictureBox Extensions**

- Image property binding

**PropertyGrid Extensions**

- SelectedObject binding

**ProgressBar Extensions**

- Value property binding

**RadioButton Extensions**

- Checked property binding

**TextBox Extensions**

- Text property binding

**TrackBar Extensions**

- Value property binding

## 💾 Installation

### NuGet Package Manager

#### Core Library

```powershell
Install-Package BB84.Extensions
```

#### WinForms Extensions

```powershell
Install-Package BB84.WinForms.Extensions
```

### Package Manager Console

#### Core Library

```powershell
dotnet add package BB84.Extensions
```

#### WinForms Extensions

```powershell
dotnet add package BB84.WinForms.Extensions
```

### PackageReference (in .csproj)

```xml
<PackageReference Include="BB84.Extensions" Version="2.14.*" />
<PackageReference Include="BB84.WinForms.Extensions" Version="2.14.*" />
```

## 🧰 Usage Examples

### Core Extensions Examples

#### DateTime Extensions

```csharp
using BB84.Extensions;

DateTime today = new(2023, 9, 5);
DateTime startOfWeek = today.StartOfWeek();
DateTime endOfMonth = today.EndOfMonth();
int weekNumber = today.WeekOfYear();
```

#### Array/Enumerable Extensions

```csharp
using BB84.Extensions;

// Random selection
int[] numbers = [1, 2, 3, 4, 5];
int randomNumber = numbers.TakeRandom();

// ForEach with condition
IEnumerable<string> strings = ["apple", "banana", "cherry"];
int count = 0;
strings.ForEach(x => x.Contains("a"), x => count++);
```

#### Color Extensions

```csharp
using BB84.Extensions;
using System.Drawing;

Color color = Color.Red;
string hexRgb = color.ToRGBHexString();     // "#FF0000"
string hexArgb = color.ToARGBHexString();   // "#FFFF0000"
byte[] rgbBytes = color.ToRgbByteArray();   // [255, 0, 0]
```

#### HTTP Client Extensions

```csharp
using BB84.Extensions;

var client = new HttpClient()
    .WithBaseAddress("https://api.example.com")
    .WithTimeout(TimeSpan.FromSeconds(30));

var request = new HttpRequestMessage(HttpMethod.Get, "/users")
    .WithBearerToken("your-token-here")
    .WithJsonMediaType();
```

#### Byte Array Extensions

```csharp
using BB84.Extensions;

byte[] data = Encoding.UTF8.GetBytes("Hello World");
byte[] compressed = data.Compress();
byte[] decompressed = compressed.Decompress();
string base64 = data.ToBase64();
string hex = data.GetHexString();
string md5Hash = data.GetMD5();
```

### WinForms Extensions Examples

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

## 📔 Development Guidelines

### Code Style and Standards

The project follows strict coding standards enforced through `.editorconfig`:

- **Naming Conventions**: PascalCase for public members, camelCase for private fields
- **Language Features**: Modern C# features encouraged (nullable reference types, pattern matching)
- **Documentation**: XML documentation required for all public APIs
- **Error Handling**: Comprehensive exception handling with appropriate exception types

### File Organization

- **Partial Classes**: Extension methods are organized using partial classes
- **Single Responsibility**: Each file contains a specific set of related extension methods
- **Namespace Organization**: Clear namespace hierarchy (`BB84.Extensions`, `BB84.WinForms.Extensions`)

### Dependencies

#### Core Library Dependencies

- **PolySharp**: For backward compatibility polyfills
- **System.Text.Json**: For JSON serialization (when targeting older frameworks)
- **System.Net.Http**: For HTTP extensions (when targeting older frameworks)

#### WinForms Library Dependencies

- **System.Windows.Forms**: Windows Forms framework
- **System.Windows.Input**: For command pattern support

## 💎 Testing

### Test Coverage

The project maintains comprehensive test coverage with dedicated test projects:

- **BB84.Extensions.Tests**: Unit tests for core extension methods
- **BB84.WinForms.Extensions.Tests**: Unit tests for WinForms extensions

### Test Framework

- **MSTest**: Primary testing framework
- **Data-Driven Tests**: Extensive use of `[DataTestMethod]` for parameterized tests
- **Exception Testing**: Proper validation of exception scenarios

### Example Test Structure

```csharp
[TestClass]
public sealed partial class BooleanExtensionsTests
{
    [DataTestMethod]
    [DataRow(true, false)]
    [DataRow(false, true)]
    public void IsFalseTest(bool value, bool expected)
        => Assert.AreEqual(expected, value.IsFalse());

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ArrayUpExceptionTest()
    {
        int value = 15;
        int maxValue = 0;
        _ = value.ArrayUp(maxValue);
    }
}
```

### Running Tests

Tests can be executed using:

```powershell
# Run all tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"

# Run specific test project
dotnet test tests/BB84.Extensions.Tests/BB84.Extensions.Tests.csproj
```

## 🚧 Building and Deployment

### Build Configuration

The project uses MSBuild with the following key configurations:

```xml
<PropertyGroup Label="Technical">
    <LangVersion>latest</LangVersion>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <GenerateDocumentationFile>True</GenerateDocumentationFile>
    <SignAssembly>True</SignAssembly>
    <AssemblyOriginatorKeyFile>..\..\PublicKey.snk</AssemblyOriginatorKeyFile>
</PropertyGroup>
```

### Versioning Strategy

The project uses a date-based versioning scheme:

- **Major**: 2 (current major version)
- **Minor**: 14 (feature version)
- **Patch**: MMDD (month and day)
- **Revision**: Minutes since midnight

### Continuous Integration

The project includes GitHub Actions workflows for:

- **CI (Continuous Integration)**: Build and test validation
- **CD (Continuous Delivery)**: Package publishing to NuGet
- **CodeQL**: Security analysis
- **Dependabot**: Dependency updates

### NuGet Package Publishing

Packages are automatically published to NuGet.org through the CD pipeline when:

- Changes are pushed to the main branch
- All tests pass
- Package validation succeeds

## 🤝 Contributing

### Getting Started

1. **Fork the repository** on GitHub
2. **Clone your fork** locally
3. **Create a feature branch** from main
4. **Make your changes** following the coding standards
5. **Add tests** for new functionality
6. **Ensure all tests pass**
7. **Submit a pull request**

### Contribution Guidelines

- Follow the existing code style and patterns
- Add XML documentation for all public APIs
- Include unit tests for new functionality
- Update documentation if needed
- Ensure compatibility across all target frameworks

### Code of Conduct

This project follows the [Contributor Covenant Code of Conduct](CODE_OF_CONDUCT.md). Please read and follow these guidelines when contributing.

### Pull Request Process

1. Ensure your code builds without warnings
2. All tests must pass
3. Include appropriate test coverage
4. Update documentation as needed
5. Describe your changes in the PR description

## 📖 Documentation

### API Documentation

Complete API documentation is automatically generated and hosted at:
**[https://bobobass84.github.io/BB84.Extensions/](https://bobobass84.github.io/BB84.Extensions/)**

### Documentation Generation

Documentation is generated using DocFX from XML comments in the source code.

### Local Documentation

To build documentation locally:

```powershell
# Install DocFX
dotnet tool install -g docfx

# Build documentation
docfx docs/docfx.json --serve
```

## ⚖️ License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for the full license text.

## 📚 Support and Resources

- **GitHub Repository**: [https://github.com/BoBoBaSs84/BB84.Extensions](https://github.com/BoBoBaSs84/BB84.Extensions)
- **NuGet Packages**:
  - [BB84.Extensions](https://www.nuget.org/packages/BB84.Extensions)
  - [BB84.WinForms.Extensions](https://www.nuget.org/packages/BB84.WinForms.Extensions)
- **Issues and Bug Reports**: [GitHub Issues](https://github.com/BoBoBaSs84/BB84.Extensions/issues)
- **API Documentation**: [Online Documentation](https://bobobass84.github.io/BB84.Extensions/)
