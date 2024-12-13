using System.Globalization;

using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class DateTimeExtensionTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetWeekOfYearTestData), DynamicDataSourceType.Method)]
	public void WeekOfYearTest(DateTime dateTime, int expected, CultureInfo culture)
		=> Assert.AreEqual(expected, dateTime.WeekOfYear(culture));
}
