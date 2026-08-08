// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Collections.Concurrent;

using BB84.Extensions.Helper;

namespace BB84.Extensions.Tests.Helper;

[TestClass]
public sealed class RandomHelperTests
{
	[TestMethod]
	[Description("Should never return a value outside of the requested range, even under concurrent access.")]
	public void RandomShouldStayWithinRangeUnderConcurrentAccess()
	{
		const int lowerBound = 1;
		const int upperBound = 100;
		ConcurrentBag<int> outOfRange = [];

		// A single shared Random instance corrupts its internal state when raced, after
		// which Next returns zero indefinitely, which is below the requested lower bound.
		_ = Parallel.For(0, 100_000, _ =>
		{
			int value = RandomHelper.Random.Next(lowerBound, upperBound);
			if (value < lowerBound || value >= upperBound)
				outOfRange.Add(value);
		});

		Assert.IsEmpty(outOfRange);
	}
}
