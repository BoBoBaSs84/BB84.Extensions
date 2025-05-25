using System.Net.Http;
using System.Net.Http.Headers;

namespace BB84.Extensions;

/// <summary>
/// The extension methods for the <see cref="HttpRequestMessage"/> class.
/// </summary>
public static class HttpRequestMessageExtensions
{
	private const string BearerScheme = "Bearer";

	/// <summary>
	/// Adds the specified <paramref name="token"/> to the http request message header as a bearer token.
	/// </summary>
	/// <param name="httpRequestMessage">The HTTP request message to which the bearer token should be added.</param>
	/// <param name="token">The bearer token to be used.</param>
	/// <returns></returns>
	public static HttpRequestMessage WithBearerToken(this HttpRequestMessage httpRequestMessage, string token)
	{
		httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue(BearerScheme, token);
		return httpRequestMessage;
	}

	/// <summary>
	/// Adds the specified <paramref name="mediaType"/> to the HTTP request message's accept header.
	/// </summary>
	/// <param name="httpRequestMessage">The HTTP request message to which the media type should be added.</param>
	/// <param name="mediaType">The media type to be added to the accept header, e.g., "<c>application/json</c>".</param>
	/// <returns></returns>
	public static HttpRequestMessage WithMediaType(this HttpRequestMessage httpRequestMessage, string mediaType)
	{
		httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
		return httpRequestMessage;
	}
}
