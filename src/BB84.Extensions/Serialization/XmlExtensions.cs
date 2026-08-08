// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Collections.Concurrent;
using System.Xml;
using System.Xml.Serialization;

using BB84.Extensions.Writers;

namespace BB84.Extensions.Serialization;

/// <summary>
/// Provides extension methods for serializing and deserializing objects to and from XML.
/// </summary>
/// <remarks>
/// This <see cref="XmlExtensions"/> class includes methods for converting objects to their XML string
/// representation and for creating object instances from XML strings. It supports customization of
/// XML reader and writer settings, as well as XML namespaces, to accommodate various serialization
/// and deserialization scenarios.
/// </remarks>
public static class XmlExtensions
{
	/// <summary>
	/// Caches the <see cref="XmlSerializer"/> instances that are created from an <see cref="XmlRootAttribute"/>.
	/// </summary>
	/// <remarks>
	/// The <see cref="XmlSerializer"/> only caches its dynamically generated serialization assembly for the
	/// <see cref="XmlSerializer(Type)"/> and <see cref="XmlSerializer(Type, string)"/> constructors. Every other
	/// constructor generates a new assembly per call, which is never unloaded and therefore leaks memory. Hence
	/// serializers created from an <see cref="XmlRootAttribute"/> have to be cached by the caller.
	/// </remarks>
	private static readonly ConcurrentDictionary<XmlSerializerCacheKey, XmlSerializer> SerializerCache = new();

	/// <summary>
	/// Gets the default <see cref="XmlWriterSettings"/> for creating an <see cref="XmlWriter"/> instance.
	/// </summary>
	/// <remarks>
	/// A single shared instance is safe here because <see cref="XmlWriter.Create(TextWriter, XmlWriterSettings)"/>
	/// takes its own read-only copy, so a writer can never mutate what the next caller receives.
	/// </remarks>
	private static readonly XmlWriterSettings WriterSettings = new()
	{
		NamespaceHandling = NamespaceHandling.OmitDuplicates,
		OmitXmlDeclaration = true
	};

	/// <summary>
	/// Gets the default <see cref="XmlReaderSettings"/> for creating an <see cref="XmlReader"/> instance.
	/// </summary>
	/// <remarks>
	/// A single shared instance is safe here because <see cref="XmlReader.Create(TextReader, XmlReaderSettings)"/>
	/// takes its own read-only copy, so a reader can never mutate what the next caller receives.
	/// </remarks>
	private static readonly XmlReaderSettings ReaderSettings = new()
	{
		IgnoreComments = true
	};

	/// <summary>
	/// Deserializes the specified XML string into an object of type <typeparamref name="T"/>.
	/// </summary>
	/// <remarks>
	/// This method uses an <see cref="XmlSerializer"/> to perform the deserialization. Ensure that the
	/// type <typeparamref name="T"/> is compatible with XML serialization.
	/// </remarks>
	/// <typeparam name="T">The type of the object to deserialize. Must be a reference type.</typeparam>
	/// <param name="value">The XML string to deserialize.</param>
	/// <param name="settings">
	/// An optional <see cref="XmlReaderSettings"/> instance that specifies the settings for the XML reader.
	/// If <see langword="null"/>, the <see cref="ReaderSettings"/> are used.</param>
	/// <returns>An instance of type <typeparamref name="T"/> deserialized from the provided XML string.</returns>
	public static T FromXml<T>(this string value, XmlReaderSettings? settings = null) where T : class
	{
		settings ??= ReaderSettings;

		using StringReader stringReader = new(value);
		using XmlReader xmlReader = XmlReader.Create(stringReader, settings);
		XmlSerializer serializer = new(typeof(T));

		return (T)serializer.Deserialize(xmlReader)!;
	}

	/// <summary>
	/// Deserializes the specified XML string into an object of type <typeparamref name="T"/>.
	/// </summary>
	/// <remarks>
	/// This method uses an <see cref="XmlSerializer"/> to perform the deserialization. Ensure that the
	/// type <typeparamref name="T"/> is compatible with XML serialization. The created serializer is cached,
	/// because the <see cref="XmlSerializer"/> does not cache the assembly it generates for this constructor.
	/// </remarks>
	/// <typeparam name="T">The type of the object to deserialize. Must be a reference type.</typeparam>
	/// <param name="value">The XML string to deserialize.</param>
	/// <param name="rootAttribute">The <see cref="XmlRootAttribute"/> that specifies the root element
	/// name and namespace.</param>
	/// <param name="settings">An optional <see cref="XmlReaderSettings"/> instance that specifies the settings
	/// for the XML reader. If <see langword="null"/>, the <see cref="ReaderSettings"/> are used.</param>
	/// <returns>An instance of type <typeparamref name="T"/> deserialized from the provided XML string.</returns>
	public static T FromXml<T>(this string value, XmlRootAttribute rootAttribute, XmlReaderSettings? settings = null) where T : class
	{
		settings ??= ReaderSettings;

		using StringReader stringReader = new(value);
		using XmlReader xmlReader = XmlReader.Create(stringReader, settings);
		XmlSerializer serializer = GetSerializer(typeof(T), rootAttribute);

		return (T)serializer.Deserialize(xmlReader)!;
	}

	/// <summary>
	/// Serializes the specified object of type <typeparamref name="T"/> into an XML string.
	/// </summary>
	/// <remarks>
	/// This method uses the <see cref="XmlSerializer"/> class to perform the serialization.
	/// The caller can optionally provide custom namespaces and writer settings to control the output format.
	/// The <see cref="XmlSerializer(Type)"/> constructor is used, which caches its dynamically generated
	/// serialization assembly internally, so no additional caching is required here.
	/// </remarks>
	/// <typeparam name="T">The type of the object to serialize. Must be a reference type.</typeparam>
	/// <param name="value">The object to serialize.</param>
	/// <param name="namespaces">
	/// An optional <see cref="XmlSerializerNamespaces"/> instance that defines the XML namespaces to use
	/// during serialization. If <see langword="null"/>, a default namespace with no prefix is used.
	/// </param>
	/// <param name="settings">
	/// An optional <see cref="XmlWriterSettings"/> instance that specifies the settings for the XML writer.
	/// If <see langword="null"/>, the <see cref="WriterSettings"/> are used.</param>
	/// <returns>An XML string serialized from the provided object of type <typeparamref name="T"/>.</returns>
	public static string ToXml<T>(this T value, XmlSerializerNamespaces? namespaces = null, XmlWriterSettings? settings = null) where T : class
	{
		namespaces ??= new XmlSerializerNamespaces([XmlQualifiedName.Empty]);
		settings ??= WriterSettings;

		using StringWriterWithEncoding stream = new(settings.Encoding);
		using XmlWriter writer = XmlWriter.Create(stream, settings);
		XmlSerializer serializer = new(value.GetType());
		serializer.Serialize(writer, value, namespaces);

		return stream.ToString();
	}

	/// <summary>
	/// Returns a cached <see cref="XmlSerializer"/> for the provided <paramref name="type"/> and
	/// <paramref name="rootAttribute"/>, creating it on first use.
	/// </summary>
	/// <remarks>
	/// The <see cref="XmlRootAttribute"/> is not used as part of the cache key itself, because it does not
	/// implement value equality and is mutable. Its serialization relevant values are used instead and a
	/// defensive copy is handed to the <see cref="XmlSerializer"/>.
	/// </remarks>
	/// <param name="type">The type the serializer is created for.</param>
	/// <param name="rootAttribute">The <see cref="XmlRootAttribute"/> that specifies the root element
	/// name and namespace.</param>
	/// <returns>The cached <see cref="XmlSerializer"/> instance.</returns>
	internal static XmlSerializer GetSerializer(Type type, XmlRootAttribute rootAttribute)
		=> SerializerCache.GetOrAdd(
			new(type, rootAttribute.ElementName, rootAttribute.Namespace, rootAttribute.DataType, rootAttribute.IsNullable),
				static key => new XmlSerializer(key.Type, key.ToRootAttribute()));

	/// <summary>
	/// Represents the cache key for an <see cref="XmlSerializer"/> that is created from an
	/// <see cref="XmlRootAttribute"/>.
	/// </summary>
	/// <param name="Type">The type the serializer is created for.</param>
	/// <param name="ElementName">The name of the XML root element.</param>
	/// <param name="Namespace">The namespace of the XML root element.</param>
	/// <param name="DataType">The XSD data type of the XML root element.</param>
	/// <param name="IsNullable">Whether the XML root element can be <see langword="null"/>.</param>
	private readonly record struct XmlSerializerCacheKey(Type Type, string ElementName, string? Namespace, string DataType, bool IsNullable)
	{
		/// <summary>
		/// Creates a new <see cref="XmlRootAttribute"/> from the values of this key.
		/// </summary>
		/// <returns>The created <see cref="XmlRootAttribute"/> instance.</returns>
		internal readonly XmlRootAttribute ToRootAttribute() => new()
		{
			ElementName = ElementName,
			Namespace = Namespace,
			DataType = DataType,
			IsNullable = IsNullable
		};
	}
}
