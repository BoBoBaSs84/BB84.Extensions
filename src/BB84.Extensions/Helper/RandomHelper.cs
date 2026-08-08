// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Helper;

/// <summary>
/// Provides the pseudo-random number generator used by the random helpers of this library.
/// </summary>
/// <remarks>
/// <see cref="Random"/> is not safe for concurrent use. Calling it from several threads corrupts
/// its internal state, after which it can return zero indefinitely. The instance returned here is
/// therefore never shared across threads: modern frameworks get <c>Random.Shared</c>,
/// older ones get a separate instance per thread, seeded from a GUID hash combined with the thread
/// identity so that two threads starting in the same tick do not produce the same sequence.
/// </remarks>
internal static class RandomHelper
{
#if !NET6_0_OR_GREATER
	[ThreadStatic]
	private static Random? _threadRandom;
#endif

	/// <summary>
	/// The pseudo-random number generator instance for the calling thread.
	/// </summary>
	internal static Random Random
#if NET6_0_OR_GREATER
		=> System.Random.Shared;
#else
		=> _threadRandom ??= new(Guid.NewGuid().GetHashCode() ^ Environment.CurrentManagedThreadId);
#endif
}
