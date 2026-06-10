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

## 🔎 Overview

**BB84.Extensions** is a collection of extension methods for .NET and Windows Forms. It ships as two
independent NuGet packages so you only take the dependency you need.

| Package                                                            | Targets                                                   | NuGet                                                                                                                                                       |
| ------------------------------------------------------------------ | --------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [BB84.Extensions](src/BB84.Extensions/README.md)                   | netstandard2.0 / 2.1 · net472 · net481 · net8.0 · net10.0 | [![NuGet](https://img.shields.io/nuget/v/BB84.Extensions.svg?logo=nuget&logoColor=white)](https://www.nuget.org/packages/BB84.Extensions)                   |
| [BB84.WinForms.Extensions](src/BB84.WinForms.Extensions/README.md) | net472 · net481 · net8.0-windows · net10.0-windows        | [![NuGet](https://img.shields.io/nuget/v/BB84.WinForms.Extensions.svg?logo=nuget&logoColor=white)](https://www.nuget.org/packages/BB84.WinForms.Extensions) |

## 📦 Libraries

### [BB84.Extensions](src/BB84.Extensions/README.md)

The core library. Extension methods for common .NET types, including:

- **Arrays / Enumerables / Lists** — `TakeRandom`, `Randomize`, `Chunk`, `ForEach`, `AddIfNotNull`
- **Boolean** — `IsTrue`, `IsFalse`, `IsDefault`, `IsNull`
- **Byte arrays** — compression, Base64, hex encoding, MD5 / SHA-256 / SHA-512 hashing
- **Colors** — conversions between `System.Drawing.Color`, RGB/ARGB hex strings, and byte arrays
- **Comparable** — `IsGreaterThan`, `IsLessThan`, `IsBetween`
- **Dates** — `StartOfWeek`, `EndOfMonth`, `WeekOfYear`, fiscal-year helpers (`DateOnly` and `DateTime`)
- **Dictionaries** — `GetOrDefault`, `GetOrAdd`, `AddOrUpdate`, `IsNullOrEmpty`
- **HTTP** — fluent `HttpClient` and `HttpRequestMessage` configuration
- **Integers / Numerics** — `ArrayUp`, `ArrayDown`, `For`, `IsPositive`, `IsNegative`
- **Objects** — `IsNull`, `IsNotNull`, culture-invariant `Convert` wrappers
- **Serialization** — `ToJson` / `FromJson`, `ToXml` / `FromXml`
- **Spans / Memory** — allocation-free `TakeRandom`, `GetHexString`, `ToByteArray`
- **Streams** — `ToByteArray`, `ToByteArrayAsync`
- **Strings** — compression, AES encryption, hashing, formatting, null checks, join
- **Tasks** — `AsSync`, `ToSafeSync`, `SafeFireAndForget`
- **TimeOnly** — midnight-crossing `IsBetween`

### [BB84.WinForms.Extensions](src/BB84.WinForms.Extensions/README.md)

Windows Forms specific. Data-binding helpers for controls, following a fluent
`With*Binding(dataSource, dataMember)` convention:

- **Base controls** — `Control.WithEnabledBinding`, `WithTextBinding`, `WithVisibleBinding`, `WithTagBinding`
- **ButtonBase** — `WithCommandBinding` (supports `ICommand` and data-source patterns), `WithCommandParameterBinding`
- **CheckBox / RadioButton** — `WithCheckedBinding`, `WithCheckStateBinding`
- **ComboBox / ListBox / ListControl** — `WithDataSourceBinding`, `WithSelectedItemBinding`, `WithEnumeratorBinding`
- **DataGrid / DataGridView** — `WithDataSourceBinding`
- **DateTimePicker** — `WithValueBinding`, `WithCheckedBinding`
- **FlagsCheckBox / FlagsRadioButton** — custom controls for binding `[Flags]` enums; supports `WithDisplayName`, `WithDescriptionName`, `WithDisplayNameResolver`, `WithSelectedValueBinding`
- **MonthCalendar** — `WithSelectionRangeBinding`
- **NumericUpDown** — `WithValueBinding`, `WithMinimumBinding`, `WithMaximumBinding`, `WithIncrementBinding`, `WithDecimalPlacesBinding`
- **PictureBox** — `WithImageBinding`
- **ProgressBar / ScrollBar / TrackBar** — `WithValueBinding`
- **ToolStripItem** _(net8.0+)_ — `WithEnabledBinding`, `WithTextBinding`, `WithVisibleBinding`

## 💾 Installation

```powershell
# Core library
dotnet add package BB84.Extensions

# WinForms extensions
dotnet add package BB84.WinForms.Extensions
```

Or via `PackageReference` in the project file:

```xml
<PackageReference Include="BB84.Extensions" />
<PackageReference Include="BB84.WinForms.Extensions" />
```

## 🚧 Build and test

```powershell
# Build the solution
dotnet build

# Run all tests
dotnet test

# Run tests with code coverage
dotnet test --collect:"XPlat Code Coverage"
```

## 🏗️ Project structure

```
BB84.Extensions/
├── src/
│   ├── BB84.Extensions/              # Core extension methods library
│   └── BB84.WinForms.Extensions/     # Windows Forms specific extensions
├── tests/
│   ├── BB84.Extensions.Tests/        # Unit tests for the core library
│   └── BB84.WinForms.Extensions.Tests/ # Unit tests for the WinForms library
└── docs/                             # DocFX documentation source
```

## 🤝 Contributing

1. Fork the repository and create a feature branch from `main`.
2. Follow the existing code style (see `.editorconfig`).
3. Add XML documentation for all public APIs.
4. Add unit tests for every new method.
5. Ensure all tests pass across all target frameworks.
6. Open a pull request describing your changes.

## 📖 Documentation

Full API documentation is hosted at **[https://bobobass84.github.io/BB84.Extensions/](https://bobobass84.github.io/BB84.Extensions/)**.

To build the documentation locally:

```powershell
dotnet tool install -g docfx
docfx docs/docfx.json --serve
```

## ⚖️ License

This project is licensed under the **MIT License** — see the [LICENSE](LICENSE) file for details.
