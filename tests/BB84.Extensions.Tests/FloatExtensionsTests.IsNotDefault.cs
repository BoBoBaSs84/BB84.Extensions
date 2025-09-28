namespace BB84.Extensions.Tests;

public sealed partial class FloatExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a float is not its default value (0).")]
	public void IsNotDefaultLong()
	{
		float value = default;
		Assert.IsFalse(value.IsNotDefault());

		value = 15;
		Assert.IsTrue(value.IsNotDefault());
	}

	[TestMethod]
	[Description("Should determine whether a nullable float is not its default value (null).")]
	public void IsNotDefaultNullableLong()
	{
		float? value = default;
		Assert.IsFalse(value.IsNotDefault());

		value = null;
		Assert.IsFalse(value.IsNotDefault());

		value = 15;
		Assert.IsTrue(value.IsNotDefault());
	}
}
