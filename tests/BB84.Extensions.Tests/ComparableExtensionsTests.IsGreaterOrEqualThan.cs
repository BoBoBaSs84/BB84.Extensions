namespace BB84.Extensions.Tests;

public partial class ComparableExtensionsTests
{
	[DataRow(0, 0, true)]
	[DataRow(1, 0, true)]
	[DataRow(0, 1, false)]
	[DataTestMethod]
	public void IsGreaterOrEqualThan(int value, int otherValue, bool expected)
		=> Assert.AreEqual(expected, value.IsGreaterOrEqualThan(otherValue));
}
