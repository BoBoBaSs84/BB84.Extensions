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
/// The XML extension class.
/// </summary>
public static class XmlExtension
{
	/// <summary>
	/// The standard XML writer settings.
	/// </summary>
	private static XmlWriterSettings WriterSettings => new()
	{
		NamespaceHandling = NamespaceHandling.OmitDuplicates,
		OmitXmlDeclaration = true
	};

	/// <summary>
	/// The standard XML reader settings.
	/// </summary>
	private static XmlReaderSettings ReaderSettings => new()
	{
		IgnoreComments = true
	};

	/// <summary>
	/// Creates an object instance from the specified XML string.
	/// </summary>
	/// <typeparam name="T">The Type of the object we are operating on</typeparam>
	/// <param name="xmlValue">The XML string to deserialize.</param>
	/// <param name="settings">The xml reader settings to use.</param>
	/// <returns>An object instance</returns>
	public static T FromXml<T>(this string xmlValue, XmlReaderSettings? settings = null) where T : class
	{
		settings ??= ReaderSettings;

		using StringReader stringReader = new(xmlValue);
		using XmlReader xmlReader = XmlReader.Create(stringReader, settings);
		XmlSerializer serializer = new(typeof(T));
		return (T)serializer.Deserialize(xmlReader)!;
	}

	/// <summary>
	/// Converts an object to its serialized XML format.
	/// </summary>
	/// <typeparam name="T">The type of object we are operating on.</typeparam>
	/// <param name="value">The object we are operating on.</param>
	/// <param name="namespaces">The xml namespace to use.</param>
	/// <param name="settings">The xml writer settings to use.</param>
	/// <returns>The XML string representation of the object <typeparamref name="T"/>.</returns>
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
