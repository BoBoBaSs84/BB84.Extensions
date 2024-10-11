using BB84.Extensions;

namespace BB84.ExtensionsTests;

[TestClass]
public sealed class HttpClientExtensionsTests
{
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
}
