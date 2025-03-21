[![net20](https://img.shields.io/badge/netstandard2.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net21](https://img.shields.io/badge/netstandard2.1-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net462](https://img.shields.io/badge/net462-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net481](https://img.shields.io/badge/net481-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net80](https://img.shields.io/badge/net8.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net90](https://img.shields.io/badge/net9.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![NuGet](https://img.shields.io/nuget/v/BB84.Extensions.svg?logo=nuget&logoColor=white)](https://www.nuget.org/packages/BB84.Extensions)

# BB84.Extensions

This library provides a set of extension methods for the .NET framework. For example, it includes methods to convert a `Color` to its RGB hexadecimal representation, to get the first day of the week, to iterate over an enumerable and execute an action on each element, take a random item from an array and much more.

## Usage

Depending on the application, there are several ways to skin a cat.

### Start of week

The `StartOfWeek` method returns the first day of the week using the specified date and the definition of the first day of the week.

```csharp
DateTime today = new(2023, 9, 5);
DateTime startOfWeek = today.StartOfWeek();
```

### Random choice

The `TakeRandom` method returns a randomly chosen item from a given array.

```csharp
int[] ints = [1, 2, 3];
int i = ints.TakeRandom();
```

### For each

The `ForEach` method iterates over an enumerable and executes an action on each element.

```csharp
int hits = default;
IEnumerable<string> strings = ["a", "ab", "b", "bb"];
strings.ForEach(x => x.Contains("a"), x => hits++);
```

### Color to RGB hexadecimal representation

The `ToRGBHexString` method turns any `System.Drawing.Color` into its RGB hexadecimal string representation, with the prefix '#'.

```csharp
Color color = Color.Green;
string hexString = color.ToRGBHexString();
```

## Documentation

The complete API documentation can be found [here](https://bobobass84.github.io/BB84.Extensions/api/index.html).
