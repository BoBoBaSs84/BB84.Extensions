using BB84.Extensions;

namespace BB84.ExtensionsTests;

public partial class ComparableExtensionsTests
{
	[DataRow(0, 0, true)]
	[DataRow(1, 0, true)]
	[DataRow(0, 1, false)]
	[DataRow(0, -1, true)]
	[DataRow(1, -1, true)]
	[DataRow(-10, -11, true)]
	[DataRow(100, 101, false)]
	[DataRow(102, 101, true)]
	[DataTestMethod]
	public void IsGreaterOrEqualThan(int value, int otherValue, bool expected)
		=> Assert.AreEqual(expected, value.IsGreaterOrEqualThan(otherValue));
}
