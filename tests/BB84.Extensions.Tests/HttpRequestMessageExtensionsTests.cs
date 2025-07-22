// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
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
