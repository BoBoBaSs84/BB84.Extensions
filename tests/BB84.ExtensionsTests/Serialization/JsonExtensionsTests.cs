using System.Text.Json.Serialization;

using BB84.Extensions.Serialization;

namespace BB84.ExtensionsTests.Serialization;

[TestClass]
public class JsonExtensionsTests
{
	private const string JsonTestString = @"{""Id"":""356e4b9a-09f9-4399-82c7-d78c02cefb48"",""Name"":""qkxTAlLXUs"",""Description"":""QGVaYoljjHDTHasFRlGhDfJSehDCUnLqLsqfFesN""}";

	[TestMethod()]
	public void FromJsonTest()
	{
		string jsonString = JsonTestString;

		TestClass testClass = jsonString.FromJson<TestClass>();

		Assert.AreEqual(Guid.Parse("356e4b9a-09f9-4399-82c7-d78c02cefb48"), testClass.Id);
		Assert.AreEqual("qkxTAlLXUs", testClass.Name);
		Assert.AreEqual("QGVaYoljjHDTHasFRlGhDfJSehDCUnLqLsqfFesN", testClass.Description);
	}

	[TestMethod()]
	public void ToJsonStringTest()
	{
		TestClass testClass = new() { Id = Guid.NewGuid(), Name = "TestName", Description = "TestDescription" };

		string jsonString = testClass.ToJsonString();

		Assert.IsTrue(jsonString.Contains($@"{nameof(testClass.Id)}"":""{testClass.Id}"));
		Assert.IsTrue(jsonString.Contains($@"{nameof(testClass.Name)}"":""{testClass.Name}"));
		Assert.IsTrue(jsonString.Contains($@"{nameof(testClass.Description)}"":""{testClass.Description}"));
	}

	private sealed class TestClass
	{
		[JsonPropertyName(nameof(Id))]
		public Guid Id { get; set; }
		[JsonPropertyName(nameof(Name))]
		public string? Name { get; set; }
		[JsonPropertyName(nameof(Description))]
		public string? Description { get; set; }
	}
}
