namespace BB84.Extensions.Tests;

public sealed partial class IntegerExtensionsTests
{
	[TestMethod]
	[Description("Should create an array of integers to a given maximum.")]
	public void ArrayDown()
	{
		int value = 15;
		int minValue = 0;

		int[] array = value.ArrayDown(minValue);

		Assert.AreEqual(16, array.Length);
	}

	[TestMethod]
	[Description("Should throw an exception.")]
	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void ArrayDownException()
	{
		int value = 0;
		int minValue = 15;
		_ = value.ArrayDown(minValue);
	}
}
