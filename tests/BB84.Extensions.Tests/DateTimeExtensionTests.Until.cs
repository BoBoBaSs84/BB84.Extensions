namespace BB84.Extensions.Tests;

public sealed partial class DateTimeExtensionTests
{
	[TestMethod]
	[DynamicData(nameof(GetUntilTestData))]
	public void UntilTest(DateTime startValue, DateTime endValue, int expected)
		=> Assert.HasCount(expected, startValue.Until(endValue));
}
