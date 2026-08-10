// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.Extensions.Tests.Common;

namespace BB84.Extensions.Tests;

/// <summary>
/// Covers the value predicates of <see cref="ShortExtensions"/>.
/// </summary>
[TestClass]
public sealed class ShortPredicateTests : NumericPredicateTestsBase<short>
{
	/// <inheritdoc/>
	protected override short Negative => -1;

	/// <inheritdoc/>
	protected override short Zero => 0;

	/// <inheritdoc/>
	protected override short Positive => 1;

	/// <inheritdoc/>
	protected override NumericPredicates<short> Predicates => new(
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
