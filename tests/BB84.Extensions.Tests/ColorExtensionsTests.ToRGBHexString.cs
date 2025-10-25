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
	[DynamicData(nameof(GetRgbHexData))]
	public void ToRGBHexStringTest(Color value, string expected)
		=> Assert.AreEqual(expected, value.ToRGBHexString());
}
