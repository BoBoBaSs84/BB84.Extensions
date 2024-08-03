using System.Globalization;

using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class DateTimeExtensionTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetWeekOfYearTestData), DynamicDataSourceType.Method)]
	public void WeekOfYearTest(int expected, CultureInfo culture)
	{
		DateTime today = DateTime.Today;
		CultureInfo.CurrentCulture = culture;

		int result = today.WeekOfYear();

		Assert.AreEqual(expected, result);
	}
}
