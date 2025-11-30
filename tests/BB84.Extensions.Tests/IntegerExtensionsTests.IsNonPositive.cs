namespace BB84.Extensions.Tests;

public sealed partial class IntegerExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a integer or nullable integer is a non positive value.")]
	public void IsNonPositiveTest()
	{
		int value = 1;
		Assert.IsFalse(value.IsNonPositive());

		value = -1;
		Assert.IsTrue(value.IsNonPositive());

		value = 0;
		Assert.IsTrue(value.IsNonPositive());

		int? nullableValue = -1;
		Assert.IsTrue(nullableValue.IsNonPositive());

		nullableValue = 1;
		Assert.IsFalse(nullableValue.IsNonPositive());

		nullableValue = null;
		Assert.IsFalse(nullableValue.IsNonPositive());

		nullableValue = 0;
		Assert.IsTrue(nullableValue.IsNonPositive());
	}
}
