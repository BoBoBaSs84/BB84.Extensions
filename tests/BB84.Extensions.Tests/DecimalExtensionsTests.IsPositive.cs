namespace BB84.Extensions.Tests;

public sealed partial class DecimalExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a decimal or nullable decimal is a positive value.")]
	public void IsPositiveTest()
	{
		decimal value = 1;
		Assert.IsTrue(value.IsPositive());

		value = -1;
		Assert.IsFalse(value.IsPositive());

		value = 0;
		Assert.IsFalse(value.IsPositive());

		decimal? nullableValue = -1;
		Assert.IsFalse(nullableValue.IsPositive());

		nullableValue = 1;
		Assert.IsTrue(nullableValue.IsPositive());

		nullableValue = null;
		Assert.IsFalse(nullableValue.IsPositive());

		nullableValue = 0;
		Assert.IsFalse(nullableValue.IsPositive());
	}
}
