using BB84.Extensions;

namespace BB84.ExtensionsTests;

[TestClass]
public sealed class HttpClientExtensionsTests
{
	[DataTestMethod]
	[DataRow("FancyToken")]
	[DataRow("")]
	public void AddBearerTokenTest(string token)
	{
		using HttpClient client = new HttpClient()
			.AddBearerToken(token);

		Assert.AreEqual(token, client.DefaultRequestHeaders.Authorization!.Parameter);
	}

	[DataTestMethod]
	[DataRow("application/json")]
	[DataRow("text/plain")]
	public void AddMediaTypeTest(string mediaType)
	{
		using HttpClient client = new HttpClient()
			.AddMediaType(mediaType);

		Assert.AreEqual(mediaType, client.DefaultRequestHeaders.Accept.First().MediaType);
	}
}
