// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class DateTimeExtensionTests
{
	[TestMethod]
	[DynamicData(nameof(GetUntilTestData))]
	public void UntilTest(DateTime startValue, DateTime endValue, int expected)
		=> Assert.HasCount(expected, startValue.Until(endValue));

	[TestMethod]
	[Description("Should validate the arguments when the method is called, not when the sequence is first enumerated.")]
	public void UntilShouldValidateArgumentsEagerly()
	{
		DateTime startValue = new(2024, 9, 17);
		DateTime endValue = new(2024, 9, 15);

		_ = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => _ = startValue.Until(endValue));
	}
}
