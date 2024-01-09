using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class DateTimeExtensionTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetStartOfWeekTestData), DynamicDataSourceType.Method)]
	public void StartOfWeekTest(DateTime value, DateTime expected)
		=> Assert.AreEqual(expected, value.StartOfWeek());
}
