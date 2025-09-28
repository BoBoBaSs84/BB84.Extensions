namespace BB84.Extensions.Tests;

public sealed partial class BooleanExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a bool is not its default value (false).")]
	public void IsNotDefaultLong()
	{
		bool value = default;
		Assert.IsFalse(value.IsNotDefault());

		value = true;
		Assert.IsTrue(value.IsNotDefault());
	}

	[TestMethod]
	[Description("Should determine whether a nullable bool is not its default value (null).")]
	public void IsNotDefaultNullableLong()
	{
		bool? value = default;
		Assert.IsFalse(value.IsNotDefault());

		value = null;
		Assert.IsFalse(value.IsNotDefault());

		value = true;
		Assert.IsTrue(value.IsNotDefault());

		value = false;
		Assert.IsTrue(value.IsNotDefault());
	}
}
