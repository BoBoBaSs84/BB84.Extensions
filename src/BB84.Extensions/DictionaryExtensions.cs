// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for working with <see cref="IDictionary{TKey, TValue}"/> objects,
/// enabling safe value retrieval, conditional insertion, and null-state checks.
/// </summary>
public static class DictionaryExtensions
{
	/// <summary>
	/// Returns the value associated with the specified key, or <paramref name="defaultValue"/> if
	/// the key is not found.
	/// </summary>
	/// <typeparam name="TKey">The type of the dictionary keys.</typeparam>
	/// <typeparam name="TValue">The type of the dictionary values.</typeparam>
	/// <param name="dict">The dictionary to search.</param>
	/// <param name="key">The key to locate.</param>
	/// <param name="defaultValue">The value to return when the key is not found.</param>
	/// <returns>
	/// The value associated with <paramref name="key"/>, or <paramref name="defaultValue"/> if the
	/// key is not present.
	/// </returns>
	/// <exception cref="ArgumentNullException">
	/// Thrown when <paramref name="dict"/> is <see langword="null"/>.
	/// </exception>
	public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue defaultValue = default!)
	{
#if NET6_0_OR_GREATER
		ArgumentNullException.ThrowIfNull(dict);
#else
		if (dict is null)
			throw new ArgumentNullException(nameof(dict));
#endif
		return dict.TryGetValue(key, out TValue? value) ? value : defaultValue;
	}

	/// <summary>
	/// Returns the value associated with the specified key, or adds and returns a new value
	/// created by <paramref name="valueFactory"/> if the key is not found.
	/// </summary>
	/// <typeparam name="TKey">The type of the dictionary keys.</typeparam>
	/// <typeparam name="TValue">The type of the dictionary values.</typeparam>
	/// <param name="dict">The dictionary to search or update.</param>
	/// <param name="key">The key to locate or add.</param>
	/// <param name="valueFactory">
	/// A factory function that creates the value to add when the key is not found.
	/// </param>
	/// <returns>
	/// The existing value for <paramref name="key"/>, or the newly added value produced by
	/// <paramref name="valueFactory"/>.
	/// </returns>
	/// <exception cref="ArgumentNullException">
	/// Thrown when <paramref name="dict"/> or <paramref name="valueFactory"/> is <see langword="null"/>.
	/// </exception>
	public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, Func<TKey, TValue> valueFactory)
	{
#if NET6_0_OR_GREATER
		ArgumentNullException.ThrowIfNull(dict);
		ArgumentNullException.ThrowIfNull(valueFactory);
#else
		if (dict is null)
			throw new ArgumentNullException(nameof(dict));
		if (valueFactory is null)
			throw new ArgumentNullException(nameof(valueFactory));
#endif
		if (!dict.TryGetValue(key, out TValue? value))
		{
			value = valueFactory(key);
			dict[key] = value;
		}

		return value;
	}

	/// <summary>
	/// Adds a key/value pair to the dictionary if the key does not already exist, or updates the
	/// existing value using <paramref name="updateFactory"/> if it does.
	/// </summary>
	/// <typeparam name="TKey">The type of the dictionary keys.</typeparam>
	/// <typeparam name="TValue">The type of the dictionary values.</typeparam>
	/// <param name="dict">The dictionary to update.</param>
	/// <param name="key">The key to add or update.</param>
	/// <param name="addValue">The value to add when the key is not present.</param>
	/// <param name="updateFactory">
	/// A factory function that computes the updated value from the key and its current value.
	/// </param>
	/// <returns>
	/// The value that was added or the updated value produced by <paramref name="updateFactory"/>.
	/// </returns>
	/// <exception cref="ArgumentNullException">
	/// Thrown when <paramref name="dict"/> or <paramref name="updateFactory"/> is <see langword="null"/>.
	/// </exception>
	public static TValue AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue addValue, Func<TKey, TValue, TValue> updateFactory)
	{
#if NET6_0_OR_GREATER
		ArgumentNullException.ThrowIfNull(dict);
		ArgumentNullException.ThrowIfNull(updateFactory);
#else
		if (dict is null)
			throw new ArgumentNullException(nameof(dict));
		if (updateFactory is null)
			throw new ArgumentNullException(nameof(updateFactory));
#endif
		TValue result = dict.TryGetValue(key, out TValue? existing)
			? updateFactory(key, existing)
			: addValue;

		dict[key] = result;

		return result;
	}

	/// <summary>
	/// Determines whether the specified dictionary is <see langword="null"/> or contains no entries.
	/// </summary>
	/// <typeparam name="TKey">The type of the dictionary keys.</typeparam>
	/// <typeparam name="TValue">The type of the dictionary values.</typeparam>
	/// <param name="dict">The dictionary to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="dict"/> is <see langword="null"/> or empty;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNullOrEmpty<TKey, TValue>(this IDictionary<TKey, TValue>? dict)
		=> dict is null || dict.Count == 0;

	/// <summary>
	/// Determines whether the specified dictionary is not <see langword="null"/> and contains at
	/// least one entry.
	/// </summary>
	/// <typeparam name="TKey">The type of the dictionary keys.</typeparam>
	/// <typeparam name="TValue">The type of the dictionary values.</typeparam>
	/// <param name="dict">The dictionary to evaluate.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="dict"/> is not <see langword="null"/> and not empty;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotNullOrEmpty<TKey, TValue>(this IDictionary<TKey, TValue>? dict)
		=> !dict.IsNullOrEmpty();
}
