// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for working with nullable <see cref="short"/> values.
/// </summary>
/// <remarks>
/// This class includes utility methods to simplify common operations on nullable short
/// values, such as checking for null or non-null states. These methods are designed to
/// improve code readability and reduce boilerplate when working with nullable floats.
/// </remarks>
public static class ShortExtensions
{
	/// <summary>
	/// Executes the specified action for each short from 0 to the specified value (exclusive).
	/// </summary>
	/// <remarks>
	/// This method iterates from 0 to <paramref name="value"/> - 1, invoking <paramref name="action"/>
	/// for each short.
	/// </remarks>
	/// <param name="value">The upper limit (exclusive) of the range.</param>
	/// <param name="action">The action to execute for each short in the range.</param>
	public static void For(this short value, Action<short> action)
	{
		for (short i = 0; i < value; i++)
			action(i);
	}

	/// <summary>
	/// Determines whether the specified short is equal to its default value (0).
	/// </summary>
	/// <param name="value">The short to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is equal to its default value (0);
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsDefault(this short value)
		=> value.Equals(default);

	/// <summary>
	/// Determines whether the specified nullable short is equal to its default value <see langword="null"/>.
	/// </summary>
	/// <param name="value">The nullable short to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is equal to its default value <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsDefault([NotNullWhen(false)] this short? value)
		=> value.Equals(default);

	/// <summary>
	/// Determines whether the specified short is not equal to its default value (0).
	/// </summary>
	/// <param name="value">The short to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is not equal to its default value (0);
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotDefault(this short value)
		=> value.Equals(default).Equals(false);

	/// <summary>
	/// Determines whether the specified short is not equal to its default value <see langword="null"/>.
	/// </summary>
	/// <param name="value">The short to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is not equal to its default value <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotDefault([NotNullWhen(true)] this short? value)
		=> value.Equals(default).Equals(false);

	/// <summary>
	/// Determines whether the specified nullable short has a null value.
	/// </summary>
	/// <param name="value">The nullable short to check.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNull([NotNullWhen(false)] this short? value)
		=> value.HasValue.Equals(false);

	/// <summary>
	/// Determines whether the specified nullable short has a value.
	/// </summary>
	/// <param name="value">The nullable short to check.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is not <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotNull([NotNullWhen(true)] this short? value)
		=> value.HasValue.Equals(true);
}
