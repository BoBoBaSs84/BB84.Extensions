namespace BB84.Extensions.Tests;

public sealed partial class BooleanExtensionsTests
{
	[TestMethod]
	[Description("Should determine whether a bool is its default value (false).")]
	public void IsDefaultLong()
	{
		bool value = default;
		Assert.IsTrue(value.IsDefault());

		value = true;
		Assert.IsFalse(value.IsDefault());
	}

	[TestMethod]
	[Description("Should determine whether a nullable bool is its default value (null).")]
	public void IsDefaultNullableLong()
	{
		bool? value = default;
		Assert.IsTrue(value.IsDefault());

		value = null;
		Assert.IsTrue(value.IsDefault());

		value = false;
		Assert.IsFalse(value.IsDefault());

		value = true;
		Assert.IsFalse(value.IsDefault());
	}
}
