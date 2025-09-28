// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Text.Json.Serialization;

using BB84.Extensions.Serialization;

namespace BB84.Extensions.Tests.Serialization;

[TestClass]
public class JsonExtensionsTests
{
	private const string JsonTestString = @"{""Id"":""356e4b9a-09f9-4399-82c7-d78c02cefb48"",""Name"":""qkxTAlLXUs"",""Description"":""QGVaYoljjHDTHasFRlGhDfJSehDCUnLqLsqfFesN""}";

	[TestMethod]
	public void FromJsonTest()
	{
		string jsonString = JsonTestString;

		TestClass testClass = jsonString.FromJson<TestClass>();

		Assert.AreEqual(Guid.Parse("356e4b9a-09f9-4399-82c7-d78c02cefb48"), testClass.Id);
		Assert.AreEqual("qkxTAlLXUs", testClass.Name);
		Assert.AreEqual("QGVaYoljjHDTHasFRlGhDfJSehDCUnLqLsqfFesN", testClass.Description);
	}

	[TestMethod]
	public void ToJsonTest()
	{
		TestClass testClass = new() { Id = Guid.NewGuid(), Name = "TestName", Description = "TestDescription" };

		string jsonString = testClass.ToJson();

		Assert.Contains($@"{nameof(testClass.Id)}"":""{testClass.Id}", jsonString);
		Assert.Contains($@"{nameof(testClass.Name)}"":""{testClass.Name}", jsonString);
		Assert.Contains($@"{nameof(testClass.Description)}"":""{testClass.Description}", jsonString);
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
