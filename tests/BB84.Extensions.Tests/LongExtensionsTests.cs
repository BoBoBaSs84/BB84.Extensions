namespace BB84.Extensions.Tests;

[TestClass]
public sealed class LongExtensionsTests
{
	[TestMethod]
	[Description("Should iterate over an long array.")]
	public void For()
	{
		long iterationCount = default;
		long value = 15;

		value.For(x => iterationCount++);

		Assert.AreEqual(value, iterationCount);
	}

	[TestMethod]
	[Description("Should determine whether a long is its default value (0).")]
	public void IsDefaultLong()
	{
		long value = default;
		Assert.IsTrue(value.IsDefault());

		value = 15;
		Assert.IsFalse(value.IsDefault());
	}

	[TestMethod]
	[Description("Should determine whether a nullable long is its default value (null).")]
	public void IsDefaultNullableLong()
	{
		long? value = default;
		Assert.IsTrue(value.IsDefault());

		value = null;
		Assert.IsTrue(value.IsDefault());

		value = 15;
		Assert.IsFalse(value.IsDefault());
	}

	[TestMethod]
	[Description("Should determine whether a long is not its default value (0).")]
	public void IsNotDefaultLong()
	{
		long value = default;
		Assert.IsFalse(value.IsNotDefault());

		value = 15;
		Assert.IsTrue(value.IsNotDefault());
	}

	[TestMethod]
	[Description("Should determine whether a nullable long is not its default value (null).")]
	public void IsNotDefaultNullableLong()
	{
		long? value = default;
		Assert.IsFalse(value.IsNotDefault());

		value = null;
		Assert.IsFalse(value.IsNotDefault());

		value = 15;
		Assert.IsTrue(value.IsNotDefault());
	}

	[TestMethod]
	[Description("Should determine whether a nullable long is null.")]
	public void IsNull()
	{
		long? value = default;
		Assert.IsTrue(value.IsNull());

		value = null;
		Assert.IsTrue(value.IsNull());

		value = 15;
		Assert.IsFalse(value.IsNull());
	}

	[TestMethod]
	[Description("Should determine whether a long is not null.")]
	public void IsNotNull()
	{
		long? value = default;
		Assert.IsFalse(value.IsNotNull());

		value = null;
		Assert.IsFalse(value.IsNotNull());

		value = 15;
		Assert.IsTrue(value.IsNotNull());
	}
}
