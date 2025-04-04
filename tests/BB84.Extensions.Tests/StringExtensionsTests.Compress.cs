// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public partial class StringExtensionsTests
{
	[TestMethod]
	public void Compress()
	{
		string decompressed = DecompressedContent;

		string compressed = decompressed.Compress();

		Assert.AreNotEqual(decompressed, compressed);
		Assert.AreEqual(CompressedContent, compressed);
	}
}
