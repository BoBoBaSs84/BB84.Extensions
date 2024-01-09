using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class DateTimeExtensionTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetStartOfMonthTestData), DynamicDataSourceType.Method)]
	public void StartOfMonthTest(DateTime value, DateTime expected)
		=> Assert.AreEqual(expected, value.StartOfMonth());
}
