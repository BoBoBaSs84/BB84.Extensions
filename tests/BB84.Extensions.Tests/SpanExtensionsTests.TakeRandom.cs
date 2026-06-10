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
	public void TakeRandomShouldReturnElementFromSpan()
	{
		int[] source = [1, 2, 3, 4, 5];
		ReadOnlySpan<int> span = source;

		int result = SpanExtensions.TakeRandom(span);

		Assert.Contains(result, source);
	}
}
#endif
