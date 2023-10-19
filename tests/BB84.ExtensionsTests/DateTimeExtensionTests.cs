using BB84.Extensions;

namespace BB84.ExtensionsTests;

[TestClass]
public class DateTimeExtensionTests
{
	[TestMethod]
	public void StartOfWeekTest()
	{
		DateTime today = new(2023, 9, 5);

		DateTime startOfWeek = today.StartOfWeek();

		Assert.AreEqual(new(2023, 9, 4), startOfWeek);
	}

	[TestMethod]
	public void EndOfWeekTest()
	{
		DateTime today = new(2023, 9, 5);

		DateTime endOfWeek = today.EndOfWeek();

		Assert.AreEqual(new(2023, 9, 10), endOfWeek);
	}

	[TestMethod]
	public void StartOfMonthTest()
	{
		DateTime today = new(2023, 9, 5);

		DateTime startOfMonth = today.StartOfMonth();

		Assert.AreEqual(new(2023, 9, 1), startOfMonth);
	}

	[TestMethod]
	public void EndOfMonthTest()
	{
		DateTime today = new(2023, 9, 5);

		DateTime endOfMonth = today.EndOfMonth();

		Assert.AreEqual(new(2023, 9, 30), endOfMonth);
	}
}
