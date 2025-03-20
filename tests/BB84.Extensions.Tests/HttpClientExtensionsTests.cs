using System.Net.Http;

namespace BB84.Extensions.Tests;

[TestClass]
public sealed class HttpClientExtensionsTests
{
	[DataTestMethod]
	[DataRow("https://example.com")]
	public void WithBaseAdressTest(string baseAddress)
	{
		using HttpClient client = new HttpClient()
			.WithBaseAdress(baseAddress);

		Assert.AreEqual($"{baseAddress}/", client.BaseAddress!.ToString());
	}

	[DataTestMethod]
	[DataRow("FancyToken")]
	[DataRow("")]
	public void WithBearerTokenTest(string token)
	{
		using HttpClient client = new HttpClient()
			.WithBearerToken(token);

		Assert.AreEqual(token, client.DefaultRequestHeaders.Authorization!.Parameter);
	}

	[DataTestMethod]
	[DataRow("application/json")]
	[DataRow("text/plain")]
	public void WithMediaTypeTest(string mediaType)
	{
		using HttpClient client = new HttpClient()
			.WithMediaType(mediaType);

		Assert.AreEqual(mediaType, client.DefaultRequestHeaders.Accept.First().MediaType);
	}

	[TestMethod]
	public void WithTimeout()
	{
		TimeSpan timeout = new(0, 0, 15);

		using HttpClient client = new HttpClient()
			.WithTimeout(timeout);

		Assert.AreEqual(timeout, client.Timeout);
	}
}
