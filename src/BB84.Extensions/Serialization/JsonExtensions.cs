// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BB84.Extensions.Serialization;

/// <summary>
/// Provides extension methods for serializing and deserializing objects to and from JSON.
/// </summary>
/// <remarks>
/// This class includes methods for converting objects to JSON strings and creating objects
/// from JSON strings. It uses default JSON serialization options, such as camel-cased property
/// names and ignoring null values, unless custom options are provided.
/// </remarks>
public static class JsonExtensions
{
	/// <summary>
	/// The standard JSON serializer options.
	/// </summary>
	private static JsonSerializerOptions SerializerOptions => new()
	{
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase
	};

	/// <summary>
	/// Deserializes the specified JSON string into an object of type <typeparamref name="T"/>.
	/// </summary>
	/// <typeparam name="T">The type of the object to deserialize. Must be a reference type.</typeparam>
	/// <param name="value">The JSON string to deserialize. Cannot be <see langword="null"/> or empty.</param>
	/// <param name="options">
	/// Optional <see cref="JsonSerializerOptions"/> to customize the deserialization process.
	/// If not provided, default options are used.
	/// </param>
	/// <returns>An object of type <typeparamref name="T"/> deserialized from the JSON string.</returns>
	public static T FromJson<T>(this string value, JsonSerializerOptions? options = null) where T : class
	{
		options ??= SerializerOptions;
		T obj = JsonSerializer.Deserialize<T>(value, options)!;
		return (T)Convert.ChangeType(obj, typeof(T), CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// Converts the specified object of type <typeparamref name="T"/> to its JSON string representation.
	/// </summary>
	/// <typeparam name="T">The type of the object to serialize. Must be a reference type.</typeparam>
	/// <param name="value">The object to serialize.</param>
	/// <param name="options">
	/// Optional <see cref="JsonSerializerOptions"/> to customize the deserialization process.
	/// If not provided, default options are used.
	/// </param>
	/// <returns>A JSON string representation of the specified object.</returns>
	public static string ToJson<T>(this T value, JsonSerializerOptions? options = null) where T : class
	{
		options ??= SerializerOptions;
		return JsonSerializer.Serialize(value, options);
	}
}
