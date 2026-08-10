// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.Extensions.Tests.Common;

namespace BB84.Extensions.Tests;

/// <summary>
/// Covers the value predicates of <see cref="LongExtensions"/>.
/// </summary>
[TestClass]
public sealed class LongPredicateTests : NumericPredicateTestsBase<long>
{
	/// <inheritdoc/>
	protected override long Negative => -1;

	/// <inheritdoc/>
	protected override long Zero => 0;

	/// <inheritdoc/>
	protected override long Positive => 1;

	/// <inheritdoc/>
	protected override NumericPredicates<long> Predicates => new(
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
