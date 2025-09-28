namespace BB84.Extensions.Tests;

public sealed partial class DoubleExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a double is its default value (0).")]
	public void IsDefaultLong()
	{
		double value = default;
		Assert.IsTrue(value.IsDefault());

		value = 15;
		Assert.IsFalse(value.IsDefault());
	}

	[TestMethod]
	[Description("Should determine whether a nullable double is its default value (null).")]
	public void IsDefaultNullableLong()
	{
		double? value = default;
		Assert.IsTrue(value.IsDefault());

		value = null;
		Assert.IsTrue(value.IsDefault());

		value = 15;
		Assert.IsFalse(value.IsDefault());
	}
}
