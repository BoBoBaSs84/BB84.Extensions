// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

[TestClass]
public sealed class ShortExtensionsTests
{
	[TestMethod]
	[Description("Should iterate over an short array.")]
	public void For()
	{
		short iterationCount = default;
		short value = 15;

		value.For(x => iterationCount++);

		Assert.AreEqual(value, iterationCount);
	}

	[TestMethod]
	[Description("Should determine whether a short is its default value (0).")]
	public void IsDefault()
	{
		short value = default;
		Assert.IsTrue(value.IsDefault());

		value = 15;
		Assert.IsFalse(value.IsDefault());
	}

	[TestMethod]
	[Description("Should determine whether a nullable short is its default value (null).")]
	public void IsDefaultNullable()
	{
		short? value = default;
		Assert.IsTrue(value.IsDefault());

		value = null;
		Assert.IsTrue(value.IsDefault());

		value = 15;
		Assert.IsFalse(value.IsDefault());
	}

	[TestMethod]
	[Description("Should determine whether a short is not its default value (0).")]
	public void IsNotDefault()
	{
		short value = default;
		Assert.IsFalse(value.IsNotDefault());

		value = 15;
		Assert.IsTrue(value.IsNotDefault());
	}

	[TestMethod]
	[Description("Should determine whether a nullable short is not its default value (null).")]
	public void IsNotDefaultNullable()
	{
		short? value = default;
		Assert.IsFalse(value.IsNotDefault());

		value = null;
		Assert.IsFalse(value.IsNotDefault());

		value = 15;
		Assert.IsTrue(value.IsNotDefault());
	}

	[TestMethod]
	[Description("Should determine whether a nullable short is null.")]
	public void IsNull()
	{
		short? value = default;
		Assert.IsTrue(value.IsNull());

		value = null;
		Assert.IsTrue(value.IsNull());

		value = 15;
		Assert.IsFalse(value.IsNull());
	}

	[TestMethod]
	[Description("Should determine whether a short is not null.")]
	public void IsNotNull()
	{
		short? value = default;
		Assert.IsFalse(value.IsNotNull());

		value = null;
		Assert.IsFalse(value.IsNotNull());

		value = 15;
		Assert.IsTrue(value.IsNotNull());
	}
}
