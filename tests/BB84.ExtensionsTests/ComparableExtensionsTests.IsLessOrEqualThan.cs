using BB84.Extensions;

namespace BB84.ExtensionsTests;

public partial class ComparableExtensionsTests
{
	[DataRow(0, 0, false)]
	[DataRow(1, 0, false)]
	[DataRow(0, 1, true)]
	[DataRow(0, -1, false)]
	[DataRow(1, -1, false)]
	[DataRow(-1, 1, true)]
	[DataRow(-11, -10, true)]
	[DataRow(100, 101, true)]
	[DataRow(101, 102, true)]
	[DataTestMethod]
	public void IsLessOrEqualThan(int value, int otherValue, bool expected)
		=> Assert.AreEqual(expected, value.IsLessThan(otherValue));
}
