using System.Net.Http;

namespace BB84.Extensions.Tests;

[TestClass]
public sealed class HttpRequestMessageExtensionsTests
{
	[TestMethod]
	public void WithBearerTokenTest()
	{
		string token = "test_token";
		HttpRequestMessage httpRequestMessage = new();

		httpRequestMessage.WithBearerToken(token);

		Assert.IsNotNull(httpRequestMessage.Headers.Authorization);
		Assert.AreEqual("Bearer", httpRequestMessage.Headers.Authorization.Scheme);
		Assert.AreEqual(token, httpRequestMessage.Headers.Authorization.Parameter);
	}

	[TestMethod]
	public void WithMediaTypeTest()
	{
		string mediaType = "application/json";
		HttpRequestMessage httpRequestMessage = new();

		httpRequestMessage.WithMediaType(mediaType);

		Assert.IsTrue(httpRequestMessage.Headers.Accept.Any(h => h.MediaType == mediaType));
	}
}
