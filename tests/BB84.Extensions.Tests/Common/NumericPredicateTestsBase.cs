// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests.Common;

/// <summary>
/// Covers the value predicates that every numeric extension class exposes.
/// </summary>
/// <remarks>
/// The class is abstract and carries no test class attribute, so the cases run once per numeric type
/// instead of being discovered on their own. This replaces one file per type and predicate, which were
/// identical apart from the type keyword.
/// <para>
/// The predicates are extension methods on the concrete types rather than generic members, so a
/// derived class hands them over as delegates. The lambdas bind at compile time, which means each
/// type's real public API is exercised and not a generic stand-in for it.
/// </para>
/// </remarks>
/// <typeparam name="T">The numeric type under test.</typeparam>
public abstract class NumericPredicateTestsBase<T> where T : struct
{
	/// <summary>
	/// A value below zero.
	/// </summary>
	protected abstract T Negative { get; }

	/// <summary>
	/// The zero value, which is also the default of <typeparamref name="T"/>.
	/// </summary>
	protected abstract T Zero { get; }

	/// <summary>
	/// A value above zero.
	/// </summary>
	protected abstract T Positive { get; }

	/// <summary>
	/// The not-a-number value, for the types that have one.
	/// </summary>
	/// <remarks>
	/// <see cref="IComparable{T}"/> orders <c>NaN</c> below zero, which the floating point extensions
	/// deliberately do not follow. Types without a <c>NaN</c> leave this <see langword="null"/> and the
	/// corresponding cases are skipped.
	/// </remarks>
	protected virtual T? NotANumber => null;

	/// <summary>
	/// The predicates of the extension class under test.
	/// </summary>
	protected abstract NumericPredicates<T> Predicates { get; }

	[TestMethod]
	[Description("Should determine whether a value is its default value.")]
	public void IsDefaultTest()
	{
		Assert.IsTrue(Predicates.IsDefault(default));
		Assert.IsTrue(Predicates.IsDefault(Zero));
		Assert.IsFalse(Predicates.IsDefault(Positive));
		Assert.IsFalse(Predicates.IsDefault(Negative));
	}

	[TestMethod]
	[Description("Should treat the default of a nullable value as null rather than as zero.")]
	public void IsDefaultNullableTest()
	{
		Assert.IsTrue(Predicates.IsDefaultNullable(default));
		Assert.IsTrue(Predicates.IsDefaultNullable(null));
		Assert.IsFalse(Predicates.IsDefaultNullable(Zero));
		Assert.IsFalse(Predicates.IsDefaultNullable(Positive));
	}

	[TestMethod]
	[Description("Should determine whether a value differs from its default value.")]
	public void IsNotDefaultTest()
	{
		Assert.IsFalse(Predicates.IsNotDefault(Zero));
		Assert.IsTrue(Predicates.IsNotDefault(Positive));
		Assert.IsTrue(Predicates.IsNotDefault(Negative));
	}

	[TestMethod]
	[Description("Should treat any nullable value that has a value as not default.")]
	public void IsNotDefaultNullableTest()
	{
		Assert.IsFalse(Predicates.IsNotDefaultNullable(null));
		Assert.IsTrue(Predicates.IsNotDefaultNullable(Zero));
		Assert.IsTrue(Predicates.IsNotDefaultNullable(Positive));
	}

	[TestMethod]
	[Description("Should determine whether a nullable value is null.")]
	public void IsNullTest()
	{
		Assert.IsTrue(Predicates.IsNull(null));
		Assert.IsFalse(Predicates.IsNull(Zero));
		Assert.IsFalse(Predicates.IsNull(Positive));
	}

	[TestMethod]
	[Description("Should determine whether a nullable value is not null.")]
	public void IsNotNullTest()
	{
		Assert.IsFalse(Predicates.IsNotNull(null));
		Assert.IsTrue(Predicates.IsNotNull(Zero));
		Assert.IsTrue(Predicates.IsNotNull(Positive));
	}

	[TestMethod]
	[Description("Should determine whether a value or nullable value is greater than zero.")]
	public void IsPositiveTest()
	{
		Assert.IsTrue(Predicates.IsPositive(Positive));
		Assert.IsFalse(Predicates.IsPositive(Zero));
		Assert.IsFalse(Predicates.IsPositive(Negative));

		Assert.IsTrue(Predicates.IsPositiveNullable(Positive));
		Assert.IsFalse(Predicates.IsPositiveNullable(Zero));
		Assert.IsFalse(Predicates.IsPositiveNullable(Negative));
		Assert.IsFalse(Predicates.IsPositiveNullable(null));

		if (NotANumber is not T nan)
			return;

		Assert.IsFalse(Predicates.IsPositive(nan));
		Assert.IsFalse(Predicates.IsPositiveNullable(nan));
	}

	[TestMethod]
	[Description("Should determine whether a value or nullable value is less than zero.")]
	public void IsNegativeTest()
	{
		Assert.IsTrue(Predicates.IsNegative(Negative));
		Assert.IsFalse(Predicates.IsNegative(Zero));
		Assert.IsFalse(Predicates.IsNegative(Positive));

		Assert.IsTrue(Predicates.IsNegativeNullable(Negative));
		Assert.IsFalse(Predicates.IsNegativeNullable(Zero));
		Assert.IsFalse(Predicates.IsNegativeNullable(Positive));
		Assert.IsFalse(Predicates.IsNegativeNullable(null));

		if (NotANumber is not T nan)
			return;

		Assert.IsFalse(Predicates.IsNegative(nan));
		Assert.IsFalse(Predicates.IsNegativeNullable(nan));
	}

	[TestMethod]
	[Description("Should determine whether a value or nullable value is greater than or equal to zero.")]
	public void IsNonNegativeTest()
	{
		Assert.IsTrue(Predicates.IsNonNegative(Positive));
		Assert.IsTrue(Predicates.IsNonNegative(Zero));
		Assert.IsFalse(Predicates.IsNonNegative(Negative));

		Assert.IsTrue(Predicates.IsNonNegativeNullable(Positive));
		Assert.IsTrue(Predicates.IsNonNegativeNullable(Zero));
		Assert.IsFalse(Predicates.IsNonNegativeNullable(Negative));
		Assert.IsFalse(Predicates.IsNonNegativeNullable(null));
	}

	[TestMethod]
	[Description("Should determine whether a value or nullable value is less than or equal to zero.")]
	public void IsNonPositiveTest()
	{
		Assert.IsTrue(Predicates.IsNonPositive(Negative));
		Assert.IsTrue(Predicates.IsNonPositive(Zero));
		Assert.IsFalse(Predicates.IsNonPositive(Positive));

		Assert.IsTrue(Predicates.IsNonPositiveNullable(Negative));
		Assert.IsTrue(Predicates.IsNonPositiveNullable(Zero));
		Assert.IsFalse(Predicates.IsNonPositiveNullable(Positive));
		Assert.IsFalse(Predicates.IsNonPositiveNullable(null));
	}
}

/// <summary>
/// Bundles the value predicates of one numeric extension class.
/// </summary>
/// <typeparam name="T">The numeric type the predicates apply to.</typeparam>
/// <param name="isDefault">Determines whether a value equals the default of its type.</param>
/// <param name="isDefaultNullable">Determines whether a nullable value has no value.</param>
/// <param name="isNotDefault">Determines whether a value differs from the default of its type.</param>
/// <param name="isNotDefaultNullable">Determines whether a nullable value has a value.</param>
/// <param name="isNull">Determines whether a nullable value is null.</param>
/// <param name="isNotNull">Determines whether a nullable value is not null.</param>
/// <param name="isPositive">Determines whether a value is greater than zero.</param>
/// <param name="isPositiveNullable">Determines whether a nullable value is greater than zero.</param>
/// <param name="isNegative">Determines whether a value is less than zero.</param>
/// <param name="isNegativeNullable">Determines whether a nullable value is less than zero.</param>
/// <param name="isNonNegative">Determines whether a value is greater than or equal to zero.</param>
/// <param name="isNonNegativeNullable">Determines whether a nullable value is greater than or equal to zero.</param>
/// <param name="isNonPositive">Determines whether a value is less than or equal to zero.</param>
/// <param name="isNonPositiveNullable">Determines whether a nullable value is less than or equal to zero.</param>
public sealed class NumericPredicates<T>(
	Func<T, bool> isDefault,
	Func<T?, bool> isDefaultNullable,
	Func<T, bool> isNotDefault,
	Func<T?, bool> isNotDefaultNullable,
	Func<T?, bool> isNull,
	Func<T?, bool> isNotNull,
	Func<T, bool> isPositive,
	Func<T?, bool> isPositiveNullable,
	Func<T, bool> isNegative,
	Func<T?, bool> isNegativeNullable,
	Func<T, bool> isNonNegative,
	Func<T?, bool> isNonNegativeNullable,
	Func<T, bool> isNonPositive,
	Func<T?, bool> isNonPositiveNullable) where T : struct
{
	public Func<T, bool> IsDefault { get; } = isDefault;
	public Func<T?, bool> IsDefaultNullable { get; } = isDefaultNullable;
	public Func<T, bool> IsNotDefault { get; } = isNotDefault;
	public Func<T?, bool> IsNotDefaultNullable { get; } = isNotDefaultNullable;
	public Func<T?, bool> IsNull { get; } = isNull;
	public Func<T?, bool> IsNotNull { get; } = isNotNull;
	public Func<T, bool> IsPositive { get; } = isPositive;
	public Func<T?, bool> IsPositiveNullable { get; } = isPositiveNullable;
	public Func<T, bool> IsNegative { get; } = isNegative;
	public Func<T?, bool> IsNegativeNullable { get; } = isNegativeNullable;
	public Func<T, bool> IsNonNegative { get; } = isNonNegative;
	public Func<T?, bool> IsNonNegativeNullable { get; } = isNonNegativeNullable;
	public Func<T, bool> IsNonPositive { get; } = isNonPositive;
	public Func<T?, bool> IsNonPositiveNullable { get; } = isNonPositiveNullable;
}
