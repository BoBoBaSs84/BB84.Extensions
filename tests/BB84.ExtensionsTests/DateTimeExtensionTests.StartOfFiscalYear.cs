using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class DateTimeExtensionTests
{
	[DataTestMethod]
	[DynamicData(nameof(GetStartOfFiscalYearTestData), DynamicDataSourceType.Method)]
	public void StartOfFiscalYearTest(DateTime value, int startMonth, DateTime expected)
		=> Assert.AreEqual(expected, value.StartOfFiscalYear(startMonth));

	[TestMethod]
	[DataTestMethod, DataRow(0), DataRow(13)]
	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void StartOfFiscalYearExceptionTest(int startMonth)
		=> new DateTime(2000, 1, 1).StartOfFiscalYear(startMonth);
}
