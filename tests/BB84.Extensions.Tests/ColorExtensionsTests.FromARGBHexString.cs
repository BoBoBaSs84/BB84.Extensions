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
	[DynamicData(nameof(GetArgbHexData))]
	public void FromARGBHexStringTest(Color expected, string value)
		=> Assert.AreEqual(expected.ToArgb(), value.FromARGBHexString().ToArgb());

	[TestMethod]
	[DataRow("")]
	[DataRow("#")]
	[DataRow("FF112233")]
	[DataRow("#FF1122")]
	[Description("Should return an empty color instead of throwing for malformed input.")]
	public void FromARGBHexStringShouldReturnEmptyForMalformedInput(string value)
		=> Assert.AreEqual(Color.Empty, value.FromARGBHexString());
}
