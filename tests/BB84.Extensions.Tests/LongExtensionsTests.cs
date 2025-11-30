// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
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
	public void IsDefault()
	{
		long value = default;
		Assert.IsTrue(value.IsDefault());

		value = 15;
		Assert.IsFalse(value.IsDefault());
	}

	[TestMethod]
	[Description("Should determine whether a nullable long is its default value (null).")]
	public void IsDefaultNullable()
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
	public void IsNotDefault()
	{
		long value = default;
		Assert.IsFalse(value.IsNotDefault());

		value = 15;
		Assert.IsTrue(value.IsNotDefault());
	}

	[TestMethod]
	[Description("Should determine whether a nullable long is not its default value (null).")]
	public void IsNotDefaultNullable()
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

	[TestMethod]
	[Description("Should determine whether a long or nullable long is a negative value.")]
	public void IsNegativeTest()
	{
		long value = -1;
		Assert.IsTrue(value.IsNegative());

		value = 1;
		Assert.IsFalse(value.IsNegative());

		value = 0;
		Assert.IsFalse(value.IsNegative());

		long? nullableValue = -1;
		Assert.IsTrue(nullableValue.IsNegative());

		nullableValue = 1;
		Assert.IsFalse(nullableValue.IsNegative());

		nullableValue = null;
		Assert.IsFalse(nullableValue.IsNegative());

		nullableValue = 0;
		Assert.IsFalse(nullableValue.IsNegative());
	}

	[TestMethod]
	[Description("Should determine whether a long or nullable long is a non negative value.")]
	public void IsNonNegativeTest()
	{
		long value = -1;
		Assert.IsFalse(value.IsNonNegative());

		value = 1;
		Assert.IsTrue(value.IsNonNegative());

		value = 0;
		Assert.IsTrue(value.IsNonNegative());

		long? nullableValue = -1;
		Assert.IsFalse(nullableValue.IsNonNegative());

		nullableValue = 1;
		Assert.IsTrue(nullableValue.IsNonNegative());

		nullableValue = null;
		Assert.IsFalse(nullableValue.IsNonNegative());

		nullableValue = 0;
		Assert.IsTrue(nullableValue.IsNonNegative());
	}

	[TestMethod]
	[Description("Should determine whether a long or nullable long is a non positive value.")]
	public void IsNonPositiveTest()
	{
		long value = 1;
		Assert.IsFalse(value.IsNonPositive());

		value = -1;
		Assert.IsTrue(value.IsNonPositive());

		value = 0;
		Assert.IsTrue(value.IsNonPositive());

		long? nullableValue = -1;
		Assert.IsTrue(nullableValue.IsNonPositive());

		nullableValue = 1;
		Assert.IsFalse(nullableValue.IsNonPositive());

		nullableValue = null;
		Assert.IsFalse(nullableValue.IsNonPositive());

		nullableValue = 0;
		Assert.IsTrue(nullableValue.IsNonPositive());
	}

	[TestMethod]
	[Description("Should determine whether a long or nullable long is a positive value.")]
	public void IsPositiveTest()
	{
		long value = 1;
		Assert.IsTrue(value.IsPositive());

		value = -1;
		Assert.IsFalse(value.IsPositive());

		value = 0;
		Assert.IsFalse(value.IsPositive());

		long? nullableValue = -1;
		Assert.IsFalse(nullableValue.IsPositive());

		nullableValue = 1;
		Assert.IsTrue(nullableValue.IsPositive());

		nullableValue = null;
		Assert.IsFalse(nullableValue.IsPositive());

		nullableValue = 0;
		Assert.IsFalse(nullableValue.IsPositive());
	}
}
