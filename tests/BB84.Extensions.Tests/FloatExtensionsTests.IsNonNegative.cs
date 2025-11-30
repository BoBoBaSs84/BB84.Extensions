namespace BB84.Extensions.Tests;

public sealed partial class FloatExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a float or nullable float is a non negative value.")]
	public void IsNonNegativeTest()
	{
		float value = -1;
		Assert.IsFalse(value.IsNonNegative());

		value = 1;
		Assert.IsTrue(value.IsNonNegative());

		value = 0;
		Assert.IsTrue(value.IsNonNegative());

		float? nullableValue = -1;
		Assert.IsFalse(nullableValue.IsNonNegative());

		nullableValue = 1;
		Assert.IsTrue(nullableValue.IsNonNegative());

		nullableValue = null;
		Assert.IsFalse(nullableValue.IsNonNegative());

		nullableValue = 0;
		Assert.IsTrue(nullableValue.IsNonNegative());
	}
}
