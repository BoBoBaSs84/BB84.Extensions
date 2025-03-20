namespace BB84.Extensions.Tests;

public sealed partial class DateTimeExtensionTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetStartOfWeekTestData), DynamicDataSourceType.Method)]
	public void StartOfWeekTest(DateTime value, DateTime expected)
		=> Assert.AreEqual(expected, value.StartOfWeek());
}
