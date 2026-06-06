// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

using BB84.Extensions.Common;

namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for configuring and enhancing the behavior of <see cref="HttpClient"/>
/// instances.
/// </summary>
/// <remarks>
/// This class includes methods for setting common HTTP client configurations, such as base addresses,
/// authentication headers, media types, and timeouts. These methods are designed to simplify and streamline
/// the setup of <see cref="HttpClient"/> instances by enabling a fluent API style, allowing multiple
/// configurations to be chained together.
/// </remarks>
public static class HttpClientExtensions
{
	/// <summary>
	/// Adds the specified <paramref name="baseAddress"/> to the http client configuration.
	/// </summary>
	/// <param name="client">The http client which should use the base address.</param>
	/// <param name="baseAddress">The base address to be used.</param>
	/// <returns>The same <see cref="HttpClient"/> instance so that multiple calls can be chained.</returns>
	/// <exception cref="ArgumentNullException">If <paramref name="baseAddress"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentException">If <paramref name="baseAddress"/> is empty, whitespace, or not a valid absolute URI.</exception>
	public static HttpClient WithBaseAddress(this HttpClient client, string baseAddress)
		=> client.WithBaseAddress(baseAddress, UriKind.Absolute);

	/// <summary>
	/// Adds the specified <paramref name="baseAddress"/> to the http client configuration.
	/// </summary>
	/// <param name="client">The http client which should use the base address.</param>
	/// <param name="baseAddress">The base address to be used.</param>
	/// <param name="uriKind">Specifies whether the URI string is relative, absolute, or indeterminate.</param>
	/// <returns>The same <see cref="HttpClient"/> instance so that multiple calls can be chained.</returns>
	/// <exception cref="ArgumentNullException">If <paramref name="baseAddress"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentException">If <paramref name="baseAddress"/> is empty, whitespace, or not a valid URI for the given <paramref name="uriKind"/>.</exception>
	public static HttpClient WithBaseAddress(this HttpClient client, string baseAddress, UriKind uriKind)
	{
#if NET6_0_OR_GREATER
		ArgumentNullException.ThrowIfNull(baseAddress);
#else
		if (baseAddress is null)
			throw new ArgumentNullException(nameof(baseAddress));
#endif
		if (string.IsNullOrWhiteSpace(baseAddress))
			throw new ArgumentException("The base address must not be empty or whitespace.", nameof(baseAddress));
		if (!Uri.TryCreate(baseAddress, uriKind, out Uri? uri))
			throw new ArgumentException($"'{baseAddress}' is not a valid URI.", nameof(baseAddress));
		return client.WithBaseAddress(uri);
	}

	/// <summary>
	/// Adds the specified <paramref name="baseAddress"/> to the http client configuration.
	/// </summary>
	/// <param name="client">The http client which should use the base address.</param>
	/// <param name="baseAddress">The base address to be used.</param>
	/// <returns>The same <see cref="HttpClient"/> instance so that multiple calls can be chained.</returns>
	public static HttpClient WithBaseAddress(this HttpClient client, Uri baseAddress)
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
#if NET6_0_OR_GREATER
		ArgumentNullException.ThrowIfNull(username);
		ArgumentNullException.ThrowIfNull(password);
#else
		if (username is null)
			throw new ArgumentNullException(nameof(username));
		if (password is null)
			throw new ArgumentNullException(nameof(password));
#endif
		if (string.IsNullOrWhiteSpace(username))
			throw new ArgumentException("The username must not be empty or whitespace.", nameof(username));
		encoding ??= Encoding.ASCII;
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.HttpHeaders.BasicScheme, Convert.ToBase64String(encoding.GetBytes($"{username}:{password}")));
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
#if NET6_0_OR_GREATER
		ArgumentNullException.ThrowIfNull(token);
#else
		if (token is null)
			throw new ArgumentNullException(nameof(token));
#endif
		if (string.IsNullOrEmpty(token))
			throw new ArgumentException("The token must not be empty.", nameof(token));
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.HttpHeaders.BearerScheme, token);
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
		if (!client.DefaultRequestHeaders.Accept.Any(h => h.MediaType == mediaType))
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
