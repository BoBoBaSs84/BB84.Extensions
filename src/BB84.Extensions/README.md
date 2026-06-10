[![net20](https://img.shields.io/badge/netstandard2.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net21](https://img.shields.io/badge/netstandard2.1-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net472](https://img.shields.io/badge/net472-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net481](https://img.shields.io/badge/net481-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net80](https://img.shields.io/badge/net8.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net100](https://img.shields.io/badge/net10.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![NuGet](https://img.shields.io/nuget/v/BB84.Extensions.svg?logo=nuget&logoColor=white)](https://www.nuget.org/packages/BB84.Extensions)

# BB84.Extensions

The core extension methods library providing utilities for common .NET types.

## Usage

Depending on the application, there are several ways to skin a cat.

### Start of week

The `StartOfWeek` method returns the first day of the week using the specified date and the definition of the first day of the week.

```csharp
DateTime today = new(2023, 9, 5);
DateTime startOfWeek = today.StartOfWeek();
```

### Range check

The `IsBetween` method determines whether a comparable value falls within a given range. The bounds are inclusive by default; pass `inclusive: false` for an exclusive range. Throws `ArgumentOutOfRangeException` if `min` is greater than `max`.

```csharp
int value = 5;
bool inRange = value.IsBetween(1, 10);          // true  (inclusive)
bool inRangeEx = value.IsBetween(1, 10, false); // true  (exclusive)
bool onBound = 10.IsBetween(1, 10);             // true  (inclusive boundary)
bool onBoundEx = 10.IsBetween(1, 10, false);    // false (exclusive boundary)
```

### Random choice

The `TakeRandom` method returns a randomly chosen item from a given array.

```csharp
int[] ints = [1, 2, 3];
int i = ints.TakeRandom();
```

### Dictionary helpers

`DictionaryExtensions` provides safe retrieval and manipulation helpers for `IDictionary<TKey, TValue>`.

```csharp
IDictionary<string, int> scores = new Dictionary<string, int> { ["alice"] = 10 };

// Return value or a fallback
int score = scores.GetOrDefault("bob", 0);           // 0

// Return existing or add via factory
int val = scores.GetOrAdd("bob", k => k.Length);     // adds "bob" → 3

// Add new or update existing
scores.AddOrUpdate("alice", 1, (_, v) => v + 5);     // alice → 15

// Null / empty checks
bool empty = scores.IsNullOrEmpty();                  // false
bool hasEntries = scores.IsNotNullOrEmpty();          // true
```

### For each

The `ForEach` method iterates over an enumerable and executes an action on each element.

```csharp
int hits = default;
IEnumerable<string> strings = ["a", "ab", "b", "bb"];
strings.ForEach(x => x.Contains("a"), x => hits++);
```

### Chunk

The `Chunk` method splits a sequence into arrays of at most `size` elements. The final chunk contains the remaining elements when the sequence length is not evenly divisible by `size`.

```csharp
IEnumerable<int> values = [1, 2, 3, 4, 5];
foreach (int[] chunk in values.Chunk(2))
    Console.WriteLine(string.Join(", ", chunk));
// Output:
// 1, 2
// 3, 4
// 5
```

### Start of DateOnly month

The `StartOfMonth` method returns the first day of the month for a given `DateOnly` value. The companion method `EndOfMonth` returns the last day.

```csharp
DateOnly today = new(2023, 9, 15);
DateOnly start = today.StartOfMonth(); // 2023-09-01
DateOnly end   = today.EndOfMonth();   // 2023-09-30
```

Equivalent helpers `StartOfWeek`, `EndOfWeek`, `StartOfYear`, `EndOfYear`, and `WeekOfYear` are also available.

### TimeOnly range check

The `IsBetween` method returns whether a `TimeOnly` value falls within a given range (start inclusive, end exclusive), correctly handling midnight-crossing ranges.

```csharp
TimeOnly value = new(23, 30);
bool night = value.IsBetween(new TimeOnly(22, 0), new TimeOnly(2, 0)); // true
```

### Span and Memory helpers

`SpanExtensions` provides allocation-free helpers for `ReadOnlySpan<T>` and `ReadOnlyMemory<byte>` on `netstandard2.1` and all modern .NET targets.

```csharp
// IsEmpty — readable alias for Length == 0
ReadOnlySpan<int> empty = ReadOnlySpan<int>.Empty;
bool isEmpty = empty.IsEmpty();         // true

// TakeRandom — random element without heap allocation
ReadOnlySpan<int> nums = new int[] { 1, 2, 3 };
int picked = nums.TakeRandom();

// GetHexString — uppercase hex, mirrors ByteExtensions.GetHexString
ReadOnlySpan<byte> bytes = new byte[] { 0xFF, 0x0A };
string hex = bytes.GetHexString();      // "FF0A"

// ToByteArray — convenience conversion from ReadOnlyMemory<byte>
ReadOnlyMemory<byte> mem = new byte[] { 1, 2, 3, 4 };
byte[] arr = mem.ToByteArray();
```

### Color to RGB hexadecimal representation

The `ToRGBHexString` method turns any `System.Drawing.Color` into its RGB hexadecimal string representation, with the prefix '#'.

```csharp
Color color = Color.Green;
string hexString = color.ToRGBHexString();
```

## Documentation

The complete API documentation can be found [here](https://bobobass84.github.io/BB84.Extensions/api/index.html).
