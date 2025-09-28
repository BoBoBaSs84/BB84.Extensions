namespace BB84.Extensions.Tests;

public sealed partial class DecimalExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a decimal is not its default value (0).")]
	public void IsNotDefaultLong()
	{
		decimal value = default;
		Assert.IsFalse(value.IsNotDefault());

		value = 15;
		Assert.IsTrue(value.IsNotDefault());
	}

	[TestMethod]
	[Description("Should determine whether a nullable decimal is not its default value (null).")]
	public void IsNotDefaultNullableLong()
	{
		decimal? value = default;
		Assert.IsFalse(value.IsNotDefault());

		value = null;
		Assert.IsFalse(value.IsNotDefault());

		value = 15;
		Assert.IsTrue(value.IsNotDefault());
	}
}
