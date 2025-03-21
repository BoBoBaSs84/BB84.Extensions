# Usage

Depending on the application, there are several ways to skin a cat.

## Example extensions

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
