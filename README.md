[![CI](https://github.com/BoBoBaSs84/BB84.Extensions/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/BoBoBaSs84/BB84.Extensions/actions/workflows/ci.yml)
[![CD](https://github.com/BoBoBaSs84/BB84.Extensions/actions/workflows/cd.yml/badge.svg?branch=main)](https://github.com/BoBoBaSs84/BB84.Extensions/actions/workflows/cd.yml)
[![C#](https://img.shields.io/badge/C%23-13.0-239120)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![Issues](https://img.shields.io/github/issues/BoBoBaSs84/BB84.Extensions)](https://github.com/BoBoBaSs84/BB84.Extensions/issues)
[![Commit](https://img.shields.io/github/last-commit/BoBoBaSs84/BB84.Extensions)](https://github.com/BoBoBaSs84/BB84.Extensions/commit/main)
[![License](https://img.shields.io/github/license/BoBoBaSs84/BB84.Extensions)](https://github.com/BoBoBaSs84/BB84.Extensions/blob/main/LICENSE)
[![NuGet](https://img.shields.io/nuget/v/BB84.Extensions.svg?logo=nuget&logoColor=white)](https://www.nuget.org/packages/BB84.Extensions)

[![net20](https://img.shields.io/badge/netstandard2.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net462](https://img.shields.io/badge/net462-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net60](https://img.shields.io/badge/net6.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net80](https://img.shields.io/badge/net8.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)

# BB84.Extensions

A collection of some random C# extensions I needed in many projects.

## Usage

Depending on the application, there are several ways to skin a cat.

### Example extensions

#### Start of week

The `StartOfWeek` method returns the first day of the week using the specified date and the definition of the first day of the week.

```csharp
DateTime today = new(2023, 9, 5);
DateTime startOfWeek = today.StartOfWeek();
```

#### Random choice

The `TakeRandom` method returns a randomly chosen item from a given array.

```csharp
int[] ints = [1, 2, 3];
int i = ints.TakeRandom();
```

#### For each

The `ForEach` method iterates over an enumerable and executes an action on each element.

```csharp
int hits = default;
IEnumerable<string> strings = ["a", "ab", "b", "bb"];
strings.ForEach(x => x.Contains("a"), x => hits++);
```

#### Color to RGB hexadecimal representation

The `ToRGBHexString` method turns any `System.Drawing.Color` into its RGB hexadecimal string representation, with the prefix '#'.

```csharp
Color color = Color.Green;
string hexString = color.ToRGBHexString();
```

## Documentation

The complete API documentation can be found [here](https://bobobass84.github.io/BB84.Extensions/api/index.html).
