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
	[DynamicData(nameof(FromRGBHexStringTestData))]
	public void FromRGBHexStringTest(Color expected, string value)
		=> Assert.AreEqual(expected.ToArgb(), value.FromRGBHexString().ToArgb());

	[TestMethod]
	[DataRow("")]
	[DataRow("#")]
	[DataRow("112233")]
	[DataRow("#11223")]
	[Description("Should return an empty color instead of throwing for malformed input.")]
	public void FromRGBHexStringShouldReturnEmptyForMalformedInput(string value)
		=> Assert.AreEqual(Color.Empty, value.FromRGBHexString());
}
