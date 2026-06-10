// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
#if NET6_0_OR_GREATER
namespace BB84.Extensions.Tests;

[TestClass]
public sealed partial class TimeOnlyExtensionsTests
{
	public static IEnumerable<object[]> GetIsBetweenTestData()
	{
		// Normal range (no midnight crossing)
		yield return new object[] { new TimeOnly(10, 0), new TimeOnly(9, 0), new TimeOnly(11, 0), true };
		yield return new object[] { new TimeOnly(9, 0), new TimeOnly(9, 0), new TimeOnly(11, 0), true };
		yield return new object[] { new TimeOnly(11, 0), new TimeOnly(9, 0), new TimeOnly(11, 0), false };
		yield return new object[] { new TimeOnly(8, 59), new TimeOnly(9, 0), new TimeOnly(11, 0), false };
		yield return new object[] { new TimeOnly(11, 1), new TimeOnly(9, 0), new TimeOnly(11, 0), false };

		// Midnight-crossing range
		yield return new object[] { new TimeOnly(23, 0), new TimeOnly(22, 0), new TimeOnly(2, 0), true };
		yield return new object[] { new TimeOnly(0, 0), new TimeOnly(22, 0), new TimeOnly(2, 0), true };
		yield return new object[] { new TimeOnly(2, 0), new TimeOnly(22, 0), new TimeOnly(2, 0), false };
		yield return new object[] { new TimeOnly(3, 0), new TimeOnly(22, 0), new TimeOnly(2, 0), false };
		yield return new object[] { new TimeOnly(21, 59), new TimeOnly(22, 0), new TimeOnly(2, 0), false };
	}
}
#endif
