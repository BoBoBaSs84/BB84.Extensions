// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Net.Http;
using System.Text;

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
	[DataRow("FancyUserName", "FancyPassword")]
	public void WithBasicAuthenticationTest(string username, string password)
	{
		using HttpClient client = new HttpClient()
			.WithBasicAuthentication(username, password);
		
		Assert.AreEqual("Basic", client.DefaultRequestHeaders.Authorization!.Scheme);
		Assert.AreEqual(Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")), client.DefaultRequestHeaders.Authorization.Parameter);
	}

	[DataTestMethod]
	[DataRow("FancyUserName", "FancyPassword")]
	public void WithBasicAuthenticationWithEncodingTest(string username, string password)
	{
		using HttpClient client = new HttpClient()
			.WithBasicAuthentication(username, password, Encoding.UTF8);

		Assert.AreEqual("Basic", client.DefaultRequestHeaders.Authorization!.Scheme);
		Assert.AreEqual(Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")), client.DefaultRequestHeaders.Authorization.Parameter);
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
