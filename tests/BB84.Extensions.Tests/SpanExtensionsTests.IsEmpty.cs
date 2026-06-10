// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
#if NET5_0_OR_GREATER
namespace BB84.Extensions.Tests;

public sealed partial class SpanExtensionsTests
{
	[TestMethod]
	public void IsEmptyWithEmptySpanShouldReturnTrue()
	{
		ReadOnlySpan<int> span = ReadOnlySpan<int>.Empty;

		bool result = SpanExtensions.IsEmpty(span);

		Assert.IsTrue(result);
	}

	[TestMethod]
	public void IsEmptyWithNonEmptySpanShouldReturnFalse()
	{
		ReadOnlySpan<int> span = new int[] { 1, 2, 3 };

		bool result = SpanExtensions.IsEmpty(span);

		Assert.IsFalse(result);
	}
}
#endif
