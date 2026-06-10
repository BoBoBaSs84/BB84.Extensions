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
	public void GetHexStringShouldReturnUppercaseHex()
	{
		ReadOnlySpan<byte> span = [0xFF, 0xFF];

		string result = SpanExtensions.GetHexString(span);

		Assert.AreEqual("FFFF", result);
	}

	[TestMethod]
	public void GetHexStringWithEmptySpanShouldReturnEmptyString()
	{
		ReadOnlySpan<byte> span = [];

		string result = SpanExtensions.GetHexString(span);

		Assert.AreEqual(string.Empty, result);
	}
}
#endif
