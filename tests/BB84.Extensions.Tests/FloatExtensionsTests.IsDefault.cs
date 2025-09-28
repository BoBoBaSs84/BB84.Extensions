namespace BB84.Extensions.Tests;

public sealed partial class FloatExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a float is its default value (0).")]
	public void IsDefaultLong()
	{
		float value = default;
		Assert.IsTrue(value.IsDefault());

		value = 15;
		Assert.IsFalse(value.IsDefault());
	}

	[TestMethod]
	[Description("Should determine whether a nullable float is its default value (null).")]
	public void IsDefaultNullableLong()
	{
		float? value = default;
		Assert.IsTrue(value.IsDefault());

		value = null;
		Assert.IsTrue(value.IsDefault());

		value = 15;
		Assert.IsFalse(value.IsDefault());
	}
}
