// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Drawing;

namespace BB84.Extensions.Tests;

public sealed partial class ColorExtensionsTests
{
	[TestMethod]
	[DynamicData(nameof(GetRgbByteData))]
	public void FromRgbByteArrayTest(Color expected, byte[] value)
		=> Assert.AreEqual(expected.ToArgb(), value.FromRgbByteArray().ToArgb());

	[TestMethod]
	public void FromRgbByteArrayExceptionTest()
	=> Assert.ThrowsExactly<ArgumentException>(() => Array.Empty<byte>().FromRgbByteArray());
}
