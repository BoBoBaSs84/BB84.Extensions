namespace BB84.Extensions.Tests;

public sealed partial class DateTimeExtensionTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetEndOfWeekTestData), DynamicDataSourceType.Method)]
	public void EndOfWeekTest(DateTime value, DateTime expected)
		=> Assert.AreEqual(expected, value.EndOfWeek());
}
