using System.Text;
using System.Xml;
using System.Xml.Serialization;

using BB84.Extensions.Serialization;

namespace BB84.ExtensionsTests.Serialization;

[TestClass]
public class XmlExtensionTests
{
	private const string XmlTextString = @"<Fancy Id=""348798ee-12f2-4a20-b030-756bb6a4134d""><Name>UnitTestName</Name><Description>UnitTestDescription</Description></Fancy>";

	private readonly XmlWriterSettings _writerSettings = new();
	private readonly XmlReaderSettings _readerSettings = new();

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

		Assert.IsTrue(xmlString.Contains("<Fancy Id="));
		Assert.IsTrue(xmlString.Contains("<Name>UnitTestName</Name>"));
		Assert.IsTrue(xmlString.Contains("<Description>UnitTestDescription</Description>"));
	}

	[DataTestMethod]
	[DataRow("utf-8"), DataRow("utf-16"), DataRow("utf-32")]
	public void EncodingTest(string encoding)
	{
		_writerSettings.Encoding = Encoding.GetEncoding(encoding);
		TestClass testClass = new() { Id = Guid.NewGuid(), Name = "UnitTestName", Description = "UnitTestDescription" };

		string xmlString = testClass.ToXml(settings: _writerSettings);

		Assert.IsTrue(xmlString.Contains($"encoding=\"{encoding}\""));
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
