namespace BB84.Extensions.Tests;

public sealed partial class DecimalExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a decimal or nullable decimal is a non positive value.")]
	public void IsNonPositiveTest()
	{
		decimal value = 1;
		Assert.IsFalse(value.IsNonPositive());

		value = -1;
		Assert.IsTrue(value.IsNonPositive());

		value = 0;
		Assert.IsTrue(value.IsNonPositive());

		decimal? nullableValue = -1;
		Assert.IsTrue(nullableValue.IsNonPositive());

		nullableValue = 1;
		Assert.IsFalse(nullableValue.IsNonPositive());

		nullableValue = null;
		Assert.IsFalse(nullableValue.IsNonPositive());

		nullableValue = 0;
		Assert.IsTrue(nullableValue.IsNonPositive());
	}
}
