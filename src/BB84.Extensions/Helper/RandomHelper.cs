// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Helper;

/// <summary>
/// The random helper class.
/// </summary>
internal static class RandomHelper
{
	private static readonly Lazy<Random> LazyRandom = new(() => new(Guid.NewGuid().GetHashCode()));

	/// <summary>
	/// The pseudo-random number generator instance.
	/// </summary>
	internal static Random Random => LazyRandom.Value;
}
