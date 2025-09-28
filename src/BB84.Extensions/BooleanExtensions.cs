// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for working with <see cref="bool"/> and nullable <see cref="bool"/> values.
/// </summary>
/// <remarks>
/// This class includes utility methods to simplify common operations on <see cref="bool"/> and nullable
/// <see cref="bool"/> values,  such as checking for <see langword="true"/>, <see langword="false"/> or
/// <see langword="null"/> states. These methods are designed to improve code readability and reduce
/// boilerplate logic when working with Boolean values.
/// </remarks>
public static class BooleanExtensions
{
	/// <summary>
	/// Determines whether the specified bool is equal to its default value (false).
	/// </summary>
	/// <param name="value">The bool to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is equal to its default value (false);
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsDefault(this bool value)
		=> value.Equals(default);

	/// <summary>
	/// Determines whether the specified nullable bool is equal to its default value <see langword="null"/>.
	/// </summary>
	/// <param name="value">The nullable bool to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is equal to its default value <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsDefault([NotNullWhen(false)] this bool? value)
		=> value.Equals(default);

	/// <summary>
	/// Determines whether the specified bool is not equal to its default value (false).
	/// </summary>
	/// <param name="value">The bool to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is not equal to its default value (false);
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotDefault(this bool value)
		=> value.Equals(default).Equals(false);

	/// <summary>
	/// Determines whether the specified bool is not equal to its default value <see langword="null"/>.
	/// </summary>
	/// <param name="value">The bool to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is not equal to its default value <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotDefault([NotNullWhen(true)] this bool? value)
		=> value.Equals(default).Equals(false);

	/// <summary>
	/// Determines whether the specified boolean value is false.
	/// </summary>
	/// <param name="value">The boolean value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is <see langword="false"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsFalse(this bool value)
		=> value.Equals(false);

	/// <summary>
	/// Determines whether the specified nullable boolean value is false.
	/// </summary>
	/// <param name="value">The nullable boolean value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is not <see langword="null"/> and
	/// equals <see langword="false"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsFalse([NotNullWhen(true)] this bool? value)
		=> value.HasValue && value.Value.Equals(false);

	/// <summary>
	/// Determines whether the specified nullable boolean has a null value.
	/// </summary>
	/// <param name="value">The nullable boolean to check.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNull([NotNullWhen(false)] this bool? value)
		=> value.HasValue.Equals(false);

	/// <summary>
	/// Determines whether the specified nullable boolean has a non-null value.
	/// </summary>
	/// <param name="value">The nullable boolean to check.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is not <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotNull([NotNullWhen(true)] this bool? value)
		=> value.HasValue.Equals(true);

	/// <summary>
	/// Determines whether the specified boolean value is true.
	/// </summary>
	/// <param name="value">The <see langword="bool"/> value to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is <see langword="true"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsTrue(this bool value)
		=> value.Equals(true);

	/// <summary>
	/// Determines whether the specified nullable boolean value is true.
	/// </summary>
	/// <param name="value">The nullable boolean to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> is not <see langword="null"/> and
	/// equals <see langword="true"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsTrue([NotNullWhen(true)] this bool? value)
		=> value.HasValue && value.Value.Equals(true);
}
