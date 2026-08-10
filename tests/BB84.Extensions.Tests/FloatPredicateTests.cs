// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.Extensions.Tests.Common;

namespace BB84.Extensions.Tests;

/// <summary>
/// Covers the value predicates of <see cref="FloatExtensions"/>.
/// </summary>
[TestClass]
public sealed class FloatPredicateTests : NumericPredicateTestsBase<float>
{
	/// <inheritdoc/>
	protected override float Negative => -1;

	/// <inheritdoc/>
	protected override float Zero => 0;

	/// <inheritdoc/>
	protected override float Positive => 1;

	/// <inheritdoc/>
	protected override float? NotANumber => float.NaN;

	/// <inheritdoc/>
	protected override NumericPredicates<float> Predicates => new(
		value => value.IsDefault(),
		value => value.IsDefault(),
		value => value.IsNotDefault(),
		value => value.IsNotDefault(),
		value => value.IsNull(),
		value => value.IsNotNull(),
		value => value.IsPositive(),
		value => value.IsPositive(),
		value => value.IsNegative(),
		value => value.IsNegative(),
		value => value.IsNonNegative(),
		value => value.IsNonNegative(),
		value => value.IsNonPositive(),
		value => value.IsNonPositive());
}
