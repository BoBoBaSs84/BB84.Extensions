// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using BB84.Extensions.Serialization;

namespace BB84.Extensions.Tests.Serialization;

[TestClass]
public class XmlExtensionTests
{
	private const string XmlTextString = @"<Fancy Id=""348798ee-12f2-4a20-b030-756bb6a4134d""><Name>UnitTestName</Name><Description>UnitTestDescription</Description></Fancy>";

	private readonly XmlWriterSettings _writerSettings = new();

	[TestMethod]
	public void FromXmlTest()
	{
		string xmlString = XmlTextString;

		TestClass testClass = xmlString.FromXml<TestClass>();

		Assert.AreEqual(Guid.Parse("348798ee-12f2-4a20-b030-756bb6a4134d"), testClass.Id);
		Assert.AreEqual("UnitTestName", testClass.Name);
		Assert.AreEqual("UnitTestDescription", testClass.Description);
	}

	[TestMethod]
	public void ToXmlTest()
	{
		TestClass testClass = new() { Id = Guid.NewGuid(), Name = "UnitTestName", Description = "UnitTestDescription" };

		string xmlString = testClass.ToXml();

		Assert.Contains("<Fancy Id=", xmlString);
		Assert.Contains("<Name>UnitTestName</Name>", xmlString);
		Assert.Contains("<Description>UnitTestDescription</Description>", xmlString);
	}

	[TestMethod]
	[DataRow("utf-8"), DataRow("utf-16"), DataRow("utf-32")]
	public void EncodingTest(string encoding)
	{
		_writerSettings.Encoding = Encoding.GetEncoding(encoding);
		TestClass testClass = new() { Id = Guid.NewGuid(), Name = "UnitTestName", Description = "UnitTestDescription" };

		string xmlString = testClass.ToXml(settings: _writerSettings);

		Assert.Contains($"encoding=\"{encoding}\"", xmlString);
	}

	[XmlRoot("Fancy")]
	public sealed class TestClass
	{
		[XmlAttribute]
		public Guid Id { get; set; }
		[XmlElement]
		public string? Name { get; set; }
		[XmlElement]
		public string? Description { get; set; }
	}
}
