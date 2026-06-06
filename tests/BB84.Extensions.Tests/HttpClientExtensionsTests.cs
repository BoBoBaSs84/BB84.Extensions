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
	[TestMethod]
	[DataRow("https://example.com")]
	public void WithBaseAddressShouldSetBaseAddress(string baseAddress)
	{
		using HttpClient client = new HttpClient()
			.WithBaseAddress(baseAddress);

		Assert.AreEqual($"{baseAddress}/", client.BaseAddress!.ToString());
	}

	[TestMethod]
	[DataRow("https://example.com")]
	public void WithBaseAddressWithUriKindShouldSetBaseAddress(string baseAddress)
	{
		using HttpClient client = new HttpClient()
			.WithBaseAddress(baseAddress, UriKind.Absolute);

		Assert.AreEqual($"{baseAddress}/", client.BaseAddress!.ToString());
	}

	[TestMethod]
	[DataRow(null)]
	public void WithBaseAddressWithNullShouldThrowArgumentNullException(string? baseAddress)
	{
		using HttpClient client = new();

		Assert.Throws<ArgumentNullException>(() => client.WithBaseAddress(baseAddress!));
	}

	[TestMethod]
	[DataRow("")]
	[DataRow("   ")]
	public void WithBaseAddressWithEmptyOrWhitespaceShouldThrowArgumentException(string baseAddress)
	{
		using HttpClient client = new();

		Assert.Throws<ArgumentException>(() => client.WithBaseAddress(baseAddress));
	}

	[TestMethod]
	[DataRow("not a uri")]
	public void WithBaseAddressWithInvalidUriShouldThrowArgumentException(string baseAddress)
	{
		using HttpClient client = new();

		Assert.Throws<ArgumentException>(() => client.WithBaseAddress(baseAddress));
	}

	[TestMethod]
	[DataRow("FancyUserName", "FancyPassword")]
	public void WithBasicAuthenticationShouldSetAuthorizationHeader(string username, string password)
	{
		using HttpClient client = new HttpClient()
			.WithBasicAuthentication(username, password);

		Assert.AreEqual("Basic", client.DefaultRequestHeaders.Authorization!.Scheme);
		Assert.AreEqual(Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")), client.DefaultRequestHeaders.Authorization.Parameter);
	}

	[TestMethod]
	[DataRow("FancyUserName", "FancyPassword")]
	public void WithBasicAuthenticationWithEncodingShouldSetAuthorizationHeader(string username, string password)
	{
		using HttpClient client = new HttpClient()
			.WithBasicAuthentication(username, password, Encoding.UTF8);

		Assert.AreEqual("Basic", client.DefaultRequestHeaders.Authorization!.Scheme);
		Assert.AreEqual(Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")), client.DefaultRequestHeaders.Authorization.Parameter);
	}

	[TestMethod]
	[DataRow(null, "password")]
	public void WithBasicAuthenticationWithNullUsernameShouldThrowArgumentNullException(string? username, string password)
	{
		using HttpClient client = new();

		Assert.Throws<ArgumentNullException>(() => client.WithBasicAuthentication(username!, password));
	}

	[TestMethod]
	[DataRow("", "password")]
	[DataRow("   ", "password")]
	public void WithBasicAuthenticationWithEmptyOrWhitespaceUsernameShouldThrowArgumentException(string username, string password)
	{
		using HttpClient client = new();

		Assert.Throws<ArgumentException>(() => client.WithBasicAuthentication(username, password));
	}

	[TestMethod]
	[DataRow("username", null)]
	public void WithBasicAuthenticationWithNullPasswordShouldThrowArgumentNullException(string username, string? password)
	{
		using HttpClient client = new();

		Assert.Throws<ArgumentNullException>(() => client.WithBasicAuthentication(username, password!));
	}

	[TestMethod]
	[DataRow("FancyToken")]
	public void WithBearerTokenShouldSetAuthorizationHeader(string token)
	{
		using HttpClient client = new HttpClient()
			.WithBearerToken(token);

		Assert.AreEqual(token, client.DefaultRequestHeaders.Authorization!.Parameter);
	}

	[TestMethod]
	[DataRow(null)]
	public void WithBearerTokenWithNullShouldThrowArgumentNullException(string? token)
	{
		using HttpClient client = new();

		Assert.Throws<ArgumentNullException>(() => client.WithBearerToken(token!));
	}

	[TestMethod]
	[DataRow("")]
	public void WithBearerTokenWithEmptyShouldThrowArgumentException(string token)
	{
		using HttpClient client = new();

		Assert.Throws<ArgumentException>(() => client.WithBearerToken(token));
	}

	[TestMethod]
	[DataRow("application/json")]
	[DataRow("text/plain")]
	public void WithMediaTypeShouldAddMediaTypeToAcceptHeader(string mediaType)
	{
		using HttpClient client = new HttpClient()
			.WithMediaType(mediaType);

		Assert.AreEqual(mediaType, client.DefaultRequestHeaders.Accept.First().MediaType);
	}

	[TestMethod]
	[DataRow("application/json")]
	public void WithMediaTypeCalledTwiceShouldNotDuplicateEntry(string mediaType)
	{
		using HttpClient client = new HttpClient()
			.WithMediaType(mediaType)
			.WithMediaType(mediaType);

		Assert.HasCount(1, client.DefaultRequestHeaders.Accept);
	}

	[TestMethod]
	public void WithTimeoutShouldSetTimeout()
	{
		TimeSpan timeout = new(0, 0, 15);

		using HttpClient client = new HttpClient()
			.WithTimeout(timeout);

		Assert.AreEqual(timeout, client.Timeout);
	}
}

