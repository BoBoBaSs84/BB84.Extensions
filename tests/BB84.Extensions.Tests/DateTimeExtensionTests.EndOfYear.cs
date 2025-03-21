namespace BB84.Extensions.Tests;

public sealed partial class DateTimeExtensionTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetEndOfYearTestData), DynamicDataSourceType.Method)]
	public void EndOfYearTest(DateTime value, DateTime expected)
		=> Assert.AreEqual(expected, value.EndOfYear());
}
