// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Helper;

/// <summary>
/// Provides a thread-safe, lazily initialized instance of a pseudo-random number generator.
/// </summary>
/// <remarks>
/// This class ensures that the <see cref="Random"/> instance is initialized with a unique seed
/// based on a hash of a GUID, providing better randomness across application runs.
/// The <see cref="Random"/> property can be used to generate random numbers in a thread-safe manner.
/// </remarks>
internal static class RandomHelper
{
	private static readonly Lazy<Random> LazyRandom = new(() => new(Guid.NewGuid().GetHashCode()));

	/// <summary>
	/// The pseudo-random number generator instance.
	/// </summary>
	internal static Random Random => LazyRandom.Value;
}
