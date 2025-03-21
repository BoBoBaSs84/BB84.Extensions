namespace BB84.Extensions.Tests;

public sealed partial class DateTimeExtensionTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetWeekOfYearTestData), DynamicDataSourceType.Method)]
	public void WeekOfYearTest(DateTime dateTime, int expected)
		=> Assert.AreEqual(expected, dateTime.WeekOfYear());
}
