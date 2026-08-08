// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Runtime.CompilerServices;

namespace BB84.Extensions.Common;

/// <summary>
/// Provides the argument checks used across the library.
/// </summary>
/// <remarks>
/// The package targets frameworks that predate <c>ArgumentNullException.ThrowIfNull</c> and its
/// siblings. Routing every check through this class keeps the conditional compilation in one
/// place instead of repeating it at every call site, and gives all guards the same exception shape.
/// <para>
/// The file is shared by source with <c>BB84.WinForms.Extensions</c>, which ships as an independent
/// package and therefore cannot reference this assembly.
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

	/// <summary>
	/// Throws if <paramref name="argument"/> is <see langword="null"/> or an empty string.
	/// </summary>
	/// <param name="argument">The argument to check.</param>
	/// <param name="paramName">The name of the argument, captured by the compiler.</param>
	/// <exception cref="ArgumentNullException">
	/// Thrown if <paramref name="argument"/> is <see langword="null"/>.
	/// </exception>
	/// <exception cref="ArgumentException">
	/// Thrown if <paramref name="argument"/> is an empty string.
	/// </exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void ThrowIfNullOrEmpty([NotNull] string? argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
	{
#if NET8_0_OR_GREATER
		ArgumentException.ThrowIfNullOrEmpty(argument, paramName);
#else
		ThrowIfNull(argument, paramName);

		if (argument.Length == 0)
			throw new ArgumentException("The value cannot be an empty string.", paramName);
#endif
	}

	/// <summary>
	/// Throws if <paramref name="argument"/> is <see langword="null"/>, empty or white-space only.
	/// </summary>
	/// <param name="argument">The argument to check.</param>
	/// <param name="paramName">The name of the argument, captured by the compiler.</param>
	/// <exception cref="ArgumentNullException">
	/// Thrown if <paramref name="argument"/> is <see langword="null"/>.
	/// </exception>
	/// <exception cref="ArgumentException">
	/// Thrown if <paramref name="argument"/> is empty or consists only of white-space characters.
	/// </exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void ThrowIfNullOrWhiteSpace([NotNull] string? argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
	{
#if NET8_0_OR_GREATER
		ArgumentException.ThrowIfNullOrWhiteSpace(argument, paramName);
#else
		ThrowIfNull(argument, paramName);

		if (string.IsNullOrWhiteSpace(argument))
			throw new ArgumentException("The value cannot be an empty string or composed entirely of whitespace.", paramName);
#endif
	}
}
