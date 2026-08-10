// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
#if NET6_0_OR_GREATER
namespace BB84.Extensions.Tests;

public sealed partial class DateTimeExtensionTests
{
	[TestMethod]
	[Description("Should keep the date component and discard the time component.")]
	public void ToDateOnlyTest()
	{
		DateTime value = new(2024, 9, 17, 13, 45, 30);

		DateOnly result = value.ToDateOnly();

		Assert.AreEqual(new DateOnly(2024, 9, 17), result);
	}

	[TestMethod]
	[Description("Should keep the time component and discard the date component.")]
	public void ToTimeOnlyTest()
	{
		DateTime value = new(2024, 9, 17, 13, 45, 30);

		TimeOnly result = value.ToTimeOnly();

		Assert.AreEqual(new TimeOnly(13, 45, 30), result);
	}
}
#endif
