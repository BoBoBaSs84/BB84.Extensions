// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Runtime.CompilerServices;

namespace BB84.WinForms.Extensions.Common;

/// <summary>
/// Provides the argument checks used across the library.
/// </summary>
/// <remarks>
/// The package targets frameworks that predate <c>ArgumentNullException.ThrowIfNull</c>.
/// Routing every check through this class keeps the conditional compilation in one place instead of
/// repeating it at every call site, and gives all guards the same exception shape.
/// <para>
/// <c>BB84.Extensions</c> carries an equivalent type. The two are deliberately not shared, because
/// the packages ship independently and neither references the other.
/// </para>
/// </remarks>
internal static class Guard
{
	/// <summary>
	/// Throws an <see cref="ArgumentNullException"/> if <paramref name="argument"/> is <see langword="null"/>.
	/// </summary>
	/// <param name="argument">The argument to check.</param>
	/// <param name="paramName">The name of the argument, captured by the compiler.</param>
	/// <exception cref="ArgumentNullException">
	/// Thrown if <paramref name="argument"/> is <see langword="null"/>.
	/// </exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void ThrowIfNull([NotNull] object? argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
	{
#if NET6_0_OR_GREATER
		ArgumentNullException.ThrowIfNull(argument, paramName);
#else
		if (argument is null)
			throw new ArgumentNullException(paramName);
#endif
	}
}
