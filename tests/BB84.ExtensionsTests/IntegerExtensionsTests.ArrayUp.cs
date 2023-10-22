using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class IntegerExtensionsTests
{
	[TestMethod]
	[Description("Should create an array of integers to a given maximum.")]
	public void ArrayUp()
	{
		int value = 0;
		int maxValue = 15;

		int[] array = value.ArrayUp(maxValue);

		Assert.AreEqual(16, array.Length);
	}

	[TestMethod]
	[Description("Should throw an exception.")]
	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void ArrayUpException()
	{
		int value = 15;
		int maxValue = 0;
		_ = value.ArrayUp(maxValue);
	}
}
