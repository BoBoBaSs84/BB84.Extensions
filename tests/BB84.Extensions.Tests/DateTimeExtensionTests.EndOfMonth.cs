namespace BB84.Extensions.Tests;

public sealed partial class DateTimeExtensionTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetEndOfMonthTestData), DynamicDataSourceType.Method)]
	public void EndOfMonthTest(DateTime value, DateTime expected)
		=> Assert.AreEqual(expected, value.EndOfMonth());
}
