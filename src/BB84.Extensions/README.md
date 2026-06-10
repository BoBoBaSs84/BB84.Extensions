[![net20](https://img.shields.io/badge/netstandard2.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net21](https://img.shields.io/badge/netstandard2.1-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net472](https://img.shields.io/badge/net472-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net481](https://img.shields.io/badge/net481-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net80](https://img.shields.io/badge/net8.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![net100](https://img.shields.io/badge/net10.0-5C2D91?logo=.NET&labelColor=gray)](https://github.com/BoBoBaSs84/BB84.Extensions)
[![NuGet](https://img.shields.io/nuget/v/BB84.Extensions.svg?logo=nuget&logoColor=white)](https://www.nuget.org/packages/BB84.Extensions)

# BB84.Extensions

The core extension methods library providing utilities for common .NET types.

## 🧰 Usage

### Array extensions

`ArrayExtensions` provides random-selection and shuffling helpers for `T[]`.

```csharp
int[] numbers = [1, 2, 3, 4, 5];

int picked   = numbers.TakeRandom();                        // random element (throws if empty)
int? safe    = numbers.TakeRandomOrDefault();               // random element or default
bool success = numbers.TryTakeRandom(out int result);       // try-pattern
int[] shuffled = numbers.Randomize();                       // new shuffled array
```

### Boolean extensions

`BooleanExtensions` adds readable predicates for `bool` and `bool?`.

```csharp
bool value = true;
bool? nullable = null;

value.IsTrue();             // true
value.IsFalse();            // false
value.IsDefault();          // false  (default is false)
nullable.IsNull();          // true
nullable.IsNotNull();       // false
```

### Byte array extensions

`ByteExtensions` covers compression, encoding, hashing, and null/default checks for `byte[]`.

```csharp
byte[] data = Encoding.UTF8.GetBytes("Hello, World!");

// Compression (Deflate)
byte[] compressed   = data.Compress();
byte[] decompressed = compressed.Decompress();

// Encoding
string base64  = data.ToBase64();
byte[] decoded = "SGVsbG8sIFdvcmxkIQ==".FromBase64();
string hex     = data.GetHexString();         // "48656C6C6F2C20576F726C6421"
string text    = data.GetString();            // "Hello, World!"

// Hashing
byte[] md5Hash    = data.GetMD5();
string md5String  = data.GetMD5String();
byte[] sha256Hash = data.GetSHA256();
string sha256     = data.GetSHA256String();
byte[] sha512Hash = data.GetSHA512();
string sha512     = data.GetSHA512String();

// Null / default checks
data.IsNull();          // false
data.IsNotNull();       // true
((byte)0).IsDefault();  // true
```

### Color extensions

`ColorExtensions` converts `System.Drawing.Color` to and from byte arrays and hexadecimal strings.

```csharp
Color red = Color.Red;

// To representations
string rgbHex  = red.ToRGBHexString();    // "#FF0000"
string argbHex = red.ToARGBHexString();   // "#FFFF0000"
byte[] rgb     = red.ToRgbByteArray();    // [255, 0, 0]
byte[] argb    = red.ToArgbByteArray();   // [255, 255, 0, 0]

// From representations
Color fromRgb  = "#FF0000".FromRGBHexString();
Color fromArgb = "#FFFF0000".FromARGBHexString();
Color fromRgbBytes  = new byte[] { 255, 0, 0 }.FromRgbByteArray();
Color fromArgbBytes = new byte[] { 255, 255, 0, 0 }.FromArgbByteArray();
```

### Comparable extensions

`ComparableExtensions` provides fluent range and comparison checks for any `IComparable<T>`.

```csharp
int value = 5;

value.IsGreaterThan(3);           // true
value.IsGreaterOrEqualThan(5);    // true
value.IsLessThan(10);             // true
value.IsLessOrEqualThan(5);       // true

// IsBetween — inclusive by default, pass false for exclusive bounds
value.IsBetween(1, 10);           // true  (inclusive)
value.IsBetween(1, 10, false);    // true  (exclusive)
10.IsBetween(1, 10);              // true  (inclusive boundary)
10.IsBetween(1, 10, false);       // false (exclusive boundary)
```

### DateOnly extensions

`DateOnlyExtensions` provides calendar helpers for `DateOnly`.

```csharp
DateOnly today = new(2023, 9, 15);

DateOnly startMonth = today.StartOfMonth(); // 2023-09-01
DateOnly endMonth   = today.EndOfMonth();   // 2023-09-30
DateOnly startWeek  = today.StartOfWeek();  // 2023-09-11 (Monday)
DateOnly endWeek    = today.EndOfWeek();    // 2023-09-17 (Sunday)
DateOnly startYear  = today.StartOfYear();  // 2023-01-01
DateOnly endYear    = today.EndOfYear();    // 2023-12-31
int week            = today.WeekOfYear();   // 37
```

### DateTime extensions

`DateTimeExtensions` provides the same calendar helpers for `DateTime`, plus fiscal-year and range helpers.

```csharp
DateTime today = new(2023, 9, 15);

DateTime startWeek       = today.StartOfWeek();
DateTime endMonth        = today.EndOfMonth();
DateTime startFiscalYear = today.StartOfFiscalYear();
DateTime endFiscalYear   = today.EndOfFiscalYear();
int week                 = today.WeekOfYear();

// Until — enumerate dates up to (exclusive) a target date
IEnumerable<DateTime> days = today.Until(new DateTime(2023, 9, 18));
// → 2023-09-15, 2023-09-16, 2023-09-17
```

### Dictionary extensions

`DictionaryExtensions` provides safe retrieval and upsert helpers for `IDictionary<TKey, TValue>`.

```csharp
IDictionary<string, int> scores = new Dictionary<string, int> { ["alice"] = 10 };

// Return value or a fallback
int score = scores.GetOrDefault("bob", 0);                      // 0

// Return existing or add via factory
int val = scores.GetOrAdd("bob", k => k.Length);                // adds "bob" → 3

// Add new or update existing
scores.AddOrUpdate("alice", 1, (_, v) => v + 5);               // alice → 15

// Null / empty checks
bool empty     = scores.IsNullOrEmpty();                        // false
bool hasItems  = scores.IsNotNullOrEmpty();                     // true
```

### Enumerable extensions

`EnumerableExtensions` extends `IEnumerable<T>` with iteration, partitioning, and random-selection helpers.

```csharp
IEnumerable<string> strings = ["a", "ab", "b", "bb"];

// ForEach — unconditional
strings.ForEach(x => Console.WriteLine(x));

// ForEach — with predicate filter
int hits = 0;
strings.ForEach(x => x.Contains("a"), x => hits++);    // hits == 2

// ForEach — with break condition
strings.ForEach(x => x.Contains("a"), x => x == "ab", x => hits++);

// Chunk — split into fixed-size arrays
IEnumerable<int> values = [1, 2, 3, 4, 5];
foreach (int[] chunk in values.Chunk(2))
    Console.WriteLine(string.Join(", ", chunk));
// Output: 1, 2 / 3, 4 / 5

// Random selection
string picked = strings.TakeRandom();
string? safe  = strings.TakeRandomOrDefault();
bool ok       = strings.TryTakeRandom(out string? result);

// Null / empty checks
strings.IsEmpty();          // false
strings.IsNullOrEmpty();    // false
strings.IsNotNullOrEmpty(); // true
```

### HTTP client extensions

`HttpClientExtensions` provides a fluent API for configuring `HttpClient` instances.

```csharp
HttpClient client = new HttpClient()
    .WithBaseAddress("https://api.example.com")
    .WithBearerToken("my-token")
    .WithMediaType("application/json")
    .WithTimeout(TimeSpan.FromSeconds(30));

// Basic authentication
client.WithBasicAuthentication("user", "pass");
```

### HTTP request message extensions

`HttpRequestMessageExtensions` applies per-request headers on `HttpRequestMessage`.

```csharp
HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/data")
    .WithBearerToken("my-token")
    .WithMediaType("application/json");
```

### Integer extensions

`IntegerExtensions` provides range arrays, loop helpers, and numeric predicates for `int` and `int?`.

```csharp
int value = 5;

// Counting arrays
int[] upTo10   = value.ArrayUp(10);    // [5, 6, 7, 8, 9, 10]
int[] downTo0  = value.ArrayDown(0);   // [0, 1, 2, 3, 4, 5]

// Loop
value.For(i => Console.Write(i));      // 0 1 2 3 4

// Predicates (also available on short, long, decimal, double, float)
value.IsDefault();      // false  (0 is default)
value.IsPositive();     // true
value.IsNegative();     // false
value.IsNonNegative();  // true
value.IsNull();         // false (int? overload)
```

### List extensions

`ListExtensions` provides null-safe add helpers and random-selection for `IList<T>`.

```csharp
IList<string> list = ["a", "b"];

list.AddIfNotNull("c");                              // adds "c"
list.AddIfNotNull(null!);                            // no-op
list.AddRangeIfNotNull(new[] { "d", "e" });          // adds both

string picked    = list.TakeRandom();
string? safe     = list.TakeRandomOrDefault();
bool ok          = list.TryTakeRandom(out string? result);
IList<string> shuffled = list.Randomize();
```

### Object extensions

`ObjectExtensions` adds null checks and culture-invariant type conversions to `object?`.

```csharp
object? value = "42";

value.IsNull();             // false
value.IsNotNull();          // true

value.ToBooleanInvariant();    // false  ("42" → false)
value.ToInt32Invariant();      // 42
value.ToDecimalInvariant();    // 42m
value.ToDoubleInvariant();     // 42.0
value.ToDateTimeInvariant();   // DateTime (if parseable)
value.ToStringInvariant();     // "42"
```

### Serialization extensions

`JsonExtensions` and `XmlExtension` provide `ToJson`/`FromJson` and `ToXml`/`FromXml` helpers on any reference type and on `string`.

```csharp
// JSON
MyDto dto   = new() { Name = "test" };
string json = dto.ToJson();                   // camelCase, nulls omitted
MyDto back  = json.FromJson<MyDto>();

// XML
string xml     = dto.ToXml();
MyDto fromXml  = xml.FromXml<MyDto>();
```

### Span and Memory helpers

`SpanExtensions` provides allocation-free helpers for `ReadOnlySpan<T>` and `ReadOnlyMemory<byte>` on `netstandard2.1` and all modern .NET targets.

```csharp
// IsEmpty
ReadOnlySpan<int> empty = ReadOnlySpan<int>.Empty;
bool isEmpty = empty.IsEmpty();                 // true

// TakeRandom — no heap allocation
ReadOnlySpan<int> nums = new int[] { 1, 2, 3 };
int picked = nums.TakeRandom();

// GetHexString — uppercase hex string
ReadOnlySpan<byte> bytes = new byte[] { 0xFF, 0x0A };
string hex = bytes.GetHexString();              // "FF0A"

// ToByteArray — copy ReadOnlyMemory<byte> to array
ReadOnlyMemory<byte> mem = new byte[] { 1, 2, 3, 4 };
byte[] arr = mem.ToByteArray();
```

### Stream extensions

`StreamExtensions` reads an entire `Stream` into a byte array, synchronously or asynchronously.

```csharp
// Synchronous
byte[] bytes = stream.ToByteArray();

// Asynchronous — non-blocking, supports cancellation
byte[] bytes = await stream.ToByteArrayAsync(cancellationToken);
```

### String extensions

`StringExtensions` covers compression, encryption, hashing, encoding, formatting, and validation.

```csharp
string value = "Hello, World!";

// Compression
string compressed   = value.Compress();
string decompressed = compressed.Decompress();

// AES encryption (key is hashed internally)
string encrypted  = value.Encrypt("my-secret-key");
string decrypted  = encrypted.Decrypt("my-secret-key");

// Hashing (returns uppercase hex string)
string md5Utf8      = value.GetMd5Utf8();
string sha256Utf8   = value.GetSha256Utf8();
string sha256Ascii  = value.GetSha256Ascii();
string sha256Uni    = value.GetSha256Unicode();
string sha512Utf8   = value.GetSha512Utf8();
string sha512Ascii  = value.GetSha512Ascii();
string sha512Uni    = value.GetSha512Unicode();

// Encoding
byte[] bytes    = value.GetBytes();                   // UTF-8
string b64      = value.ToBase64(Encoding.UTF8);
string decoded  = b64.FromBase64(Encoding.UTF8);

// Formatting
string result   = "{0} {1}".FormatInvariant("Hello", "World");

// Null / empty checks
value.IsNull();                  // false
value.IsNullOrEmpty();           // false
value.IsNullOrWhiteSpace();      // false
value.IsNotNullOrWhiteSpace();   // true

// Clean-up
string clean = "  hello  world  ".RemoveWhitespace();   // "helloworld"
string flat  = "line1\nline2".RemoveLinebreak();         // "line1line2"

// Comparison
"abc".EqualsCaseSensitive("ABC");   // false
"abc".EqualsIgnoreCase("ABC");      // true

// Join
string joined = new[] { "a", "b", "c" }.Join(", ");    // "a, b, c"
```

### Task extensions

`TaskExtensions` provides synchronous bridging, safe fire-and-forget, and exception handling for `Task` and `Task<T>`.

```csharp
// AsSync — block and return the result
int result = SomeAsync().AsSync();

// ToSafeSync — block with optional error callback and timeout
int value = SomeAsync().ToSafeSync(
    onCompletion: () => Console.WriteLine("done"),
    onException:  ex => Console.WriteLine(ex.Message),
    timeout:      TimeSpan.FromSeconds(5));

// SafeFireAndForget — observable fire-and-forget without async void
SomeAsync().SafeFireAndForget(
    onCompletion: () => Console.WriteLine("completed"),
    onException:  ex => Log(ex));
```

### TimeOnly extensions

`TimeOnlyExtensions.IsBetween` tests whether a `TimeOnly` falls within a range, correctly handling midnight-crossing intervals.

```csharp
TimeOnly t = new(23, 30);

bool night = t.IsBetween(new TimeOnly(22, 0), new TimeOnly(2, 0));  // true  (crosses midnight)
bool day   = t.IsBetween(new TimeOnly(8, 0),  new TimeOnly(18, 0)); // false
```

## 📖 Documentation

The complete API documentation can be found [here](https://bobobass84.github.io/BB84.Extensions/api/index.html).
