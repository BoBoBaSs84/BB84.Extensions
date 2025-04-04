// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace BB84.Extensions;

/// <summary>
/// The extension methods for the <see cref="HttpClient"/> class.
/// </summary>
public static class HttpClientExtensions
{
	private const string BasicScheme = "Basic";
	private const string BearerScheme = "Bearer";

	/// <summary>
	/// Adds the specified <paramref name="baseAddress"/> to the http client configuration.
	/// </summary>
	/// <param name="client">The http client which should use the base address.</param>
	/// <param name="baseAddress">The base address to be used.</param>
	/// <returns>The same <see cref="HttpClient"/> instance so that multiple calls can be chained.</returns>
	public static HttpClient WithBaseAdress(this HttpClient client, string baseAddress)
	{
		client.WithBaseAdress(new Uri(baseAddress));
		return client;
	}

	/// <summary>
	/// Adds the specified <paramref name="baseAddress"/> to the http client configuration.
	/// </summary>
	/// <param name="client">The http client which should use the base address.</param>
	/// <param name="baseAddress">The base address to be used.</param>
	/// <returns>The same <see cref="HttpClient"/> instance so that multiple calls can be chained.</returns>
	public static HttpClient WithBaseAdress(this HttpClient client, Uri baseAddress)
	{
		client.BaseAddress = baseAddress;
		return client;
	}

	/// <summary>
	/// Adds basic authentication to the http client request header with the specified <paramref name="username"/> and <paramref name="password"/>.
	/// </summary>
	/// <param name="client">The http client which should use the basic authentication.</param>
	/// <param name="username">The username to be used.</param>
	/// <param name="password">The password to be used.</param>
	/// <param name="encoding">The encoding to be used for the username and password. Default is ASCII.</param>
	/// <returns>The same <see cref="HttpClient"/> instance so that multiple calls can be chained.</returns>
	public static HttpClient WithBasicAuthentication(this HttpClient client, string username, string password, Encoding? encoding = null)
	{
		encoding ??= Encoding.ASCII;
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(BasicScheme, Convert.ToBase64String(encoding.GetBytes($"{username}:{password}")));
		return client;
	}

	/// <summary>
	/// Adds the specified bearer <paramref name="token"/> to the http client request header.
	/// </summary>
	/// <param name="client">The http client which should use the token.</param>
	/// <param name="token">The bearer token to be used.</param>
	/// <returns>The same <see cref="HttpClient"/> instance so that multiple calls can be chained.</returns>
	public static HttpClient WithBearerToken(this HttpClient client, string token)
	{
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(BearerScheme, token);
		return client;
	}

	/// <summary>
	/// Adds the specified <paramref name="mediaType"/> the accept header for an HTTP request.
	/// </summary>
	/// <param name="client">The http client which should use the media type.</param>
	/// <param name="mediaType">The media type to be used.</param>
	/// <returns>The same <see cref="HttpClient"/> instance so that multiple calls can be chained.</returns>
	public static HttpClient WithMediaType(this HttpClient client, string mediaType)
	{
		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
		return client;
	}

	/// <summary>
	/// Adds the specified <paramref name="timeout"/> to the http client configuration.
	/// </summary>
	/// <param name="client">The http client which should use the time out.</param>
	/// <param name="timeout">The timespan to wait before the request times out.</param>
	/// <returns>The same <see cref="HttpClient"/> instance so that multiple calls can be chained.</returns>
	public static HttpClient WithTimeout(this HttpClient client, TimeSpan timeout)
	{
		client.Timeout = timeout;
		return client;
	}
}
