using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BB84.Extensions.Serialization;

/// <summary>
/// The json extensions class.
/// </summary>
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
	/// Creates an object instance from the specified JSON string.
	/// </summary>
	/// <typeparam name="T">The Type of the object we are operating on.</typeparam>
	/// <param name="jsonValue">The JSON string to deserialize.</param>
	/// <param name="options">The json serializer options to use.</param>
	/// <returns>An object instance.</returns>
	public static T FromJson<T>(this string jsonValue, JsonSerializerOptions? options = null) where T : class
	{
		options ??= SerializerOptions;

		T obj = JsonSerializer.Deserialize<T>(jsonValue, options)!;
		return (T)Convert.ChangeType(obj, typeof(T), CultureInfo.InvariantCulture);
	}


	/// <summary>
	/// Converts an object to its serialized JSON format.
	/// </summary>
	/// <typeparam name="T">The type of object we are operating on.</typeparam>
	/// <param name="value">The object we are operating on.</param>
	/// <param name="options">The json serializer options to use.</param>
	/// <returns>The JSON string representation of the object <typeparamref name="T"/>.</returns>
	public static string ToJson<T>(this T value, JsonSerializerOptions? options = null) where T : class
	{
		options ??= SerializerOptions;

		return JsonSerializer.Serialize(value, options);
	}
}
