namespace BB84.ExtensionsTests;

[TestClass]
public sealed partial class DateTimeExtensionTests
{
	public static IEnumerable<object[]> GetStartOfWeekTestData()
	{
		yield return new object[] { new DateTime(2023, 9, 5), new DateTime(2023, 9, 4) };
		yield return new object[] { new DateTime(2023, 9, 6), new DateTime(2023, 9, 4) };
		yield return new object[] { new DateTime(2023, 9, 7), new DateTime(2023, 9, 4) };
		yield return new object[] { new DateTime(2023, 9, 8), new DateTime(2023, 9, 4) };
		yield return new object[] { new DateTime(2023, 9, 9), new DateTime(2023, 9, 4) };
	}

	public static IEnumerable<object[]> GetEndOfWeekTestData()
	{
		yield return new object[] { new DateTime(2023, 9, 5), new DateTime(2023, 9, 10) };
		yield return new object[] { new DateTime(2023, 9, 6), new DateTime(2023, 9, 10) };
		yield return new object[] { new DateTime(2023, 9, 7), new DateTime(2023, 9, 10) };
		yield return new object[] { new DateTime(2023, 9, 8), new DateTime(2023, 9, 10) };
		yield return new object[] { new DateTime(2023, 9, 9), new DateTime(2023, 9, 10) };
	}

	public static IEnumerable<object[]> GetStartOfMonthTestData()
	{
		yield return new object[] { new DateTime(2023, 9, 5), new DateTime(2023, 9, 1) };
		yield return new object[] { new DateTime(2023, 9, 6), new DateTime(2023, 9, 1) };
		yield return new object[] { new DateTime(2023, 9, 7), new DateTime(2023, 9, 1) };
		yield return new object[] { new DateTime(2023, 9, 8), new DateTime(2023, 9, 1) };
		yield return new object[] { new DateTime(2023, 9, 9), new DateTime(2023, 9, 1) };
	}

	public static IEnumerable<object[]> GetEndOfMonthTestData()
	{
		yield return new object[] { new DateTime(2023, 9, 5), new DateTime(2023, 9, 30) };
		yield return new object[] { new DateTime(2023, 9, 6), new DateTime(2023, 9, 30) };
		yield return new object[] { new DateTime(2023, 9, 7), new DateTime(2023, 9, 30) };
		yield return new object[] { new DateTime(2023, 9, 8), new DateTime(2023, 9, 30) };
		yield return new object[] { new DateTime(2023, 9, 9), new DateTime(2023, 9, 30) };
	}
}
