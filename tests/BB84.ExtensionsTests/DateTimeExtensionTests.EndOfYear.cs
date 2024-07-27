using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class DateTimeExtensionTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetEndOfYearTestData), DynamicDataSourceType.Method)]
	public void EndOfYearTest(DateTime value, DateTime expected)
		=> Assert.AreEqual(expected, value.EndOfYear());
}
