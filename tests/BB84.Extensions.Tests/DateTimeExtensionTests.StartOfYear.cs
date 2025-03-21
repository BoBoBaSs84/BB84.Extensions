namespace BB84.Extensions.Tests;

public sealed partial class DateTimeExtensionTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetStartOfYearTestData), DynamicDataSourceType.Method)]
	public void StartOfYearTest(DateTime value, DateTime expected)
		=> Assert.AreEqual(expected, value.StartOfYear());
}
