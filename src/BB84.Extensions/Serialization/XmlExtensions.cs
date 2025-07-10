// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Xml;
using System.Xml.Serialization;

using BB84.Extensions.Writers;

namespace BB84.Extensions.Serialization;

/// <summary>
/// Provides extension methods for serializing and deserializing objects to and from XML.
/// </summary>
/// <remarks>
/// This <see cref="XmlExtension"/> class includes methods for converting objects to their XML string
/// representation and for creating object instances from XML strings. It supports customization of
/// XML reader and writer settings, as well as XML namespaces, to accommodate various serialization
/// and deserialization scenarios.
/// </remarks>
public static class XmlExtension
{
	/// <summary>
	/// Gets the default <see cref="XmlWriterSettings"/> for creating an <see cref="XmlWriter"/> instance.
	/// </summary>
	private static XmlWriterSettings WriterSettings => new()
	{
		NamespaceHandling = NamespaceHandling.OmitDuplicates,
		OmitXmlDeclaration = true
	};

	/// <summary>
	/// Gets the default <see cref="XmlReaderSettings"/> for creating an <see cref="XmlReader"/> instance.
	/// </summary>
	private static XmlReaderSettings ReaderSettings => new()
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
	/// Serializes the specified object of type <typeparamref name="T"/> into an XML string.
	/// </summary>
	/// <remarks>
	/// This method uses the <see cref="XmlSerializer"/> class to perform the serialization.
	/// The caller can optionally provide custom namespaces and writer settings to control the output format.
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
}
