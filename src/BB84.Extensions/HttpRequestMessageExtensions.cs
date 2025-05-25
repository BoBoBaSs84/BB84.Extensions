using System.Net.Http;
using System.Net.Http.Headers;

using BB84.Extensions.Common;

namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for <see cref="HttpRequestMessage"/> to simplify common header modifications.
/// </summary>
/// <remarks>
/// This class includes methods for adding bearer tokens and media types to HTTP request headers, 
/// enabling a more fluent and readable approach to configuring <see cref="HttpRequestMessage"/> instances.
/// </remarks>
public static class HttpRequestMessageExtensions
{
	/// <summary>
	/// Adds a Bearer token to the Authorization header of the specified HTTP request message.
	/// </summary>
	/// <remarks>
	/// This method sets the Authorization header of the provided <see cref="HttpRequestMessage"/> to use
	/// the Bearer scheme with the specified token.
	/// </remarks>
	/// <param name="httpRequestMessage">The <see cref="HttpRequestMessage"/> to which the Bearer token will be added.</param>
	/// <param name="token">The Bearer token to include in the Authorization header.</param>
	/// <returns>The same <see cref="HttpRequestMessage"/> instance, allowing for method chaining.</returns>
	public static HttpRequestMessage WithBearerToken(this HttpRequestMessage httpRequestMessage, string token)
	{
		httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue(Constants.HttpHeaders.BearerScheme, token);
		return httpRequestMessage;
	}


	/// <summary>
	/// Adds the specified media type to the Accept header of the HTTP request message.
	/// </summary>
	/// <remarks>
	/// This method modifies the Accept header of the provided <see cref="HttpRequestMessage"/> by appending the
	/// specified media type. It is useful for specifying the desired response format when making HTTP requests.
	/// </remarks>
	/// <param name="httpRequestMessage">The <see cref="HttpRequestMessage"/> to which the media type will be added.</param>
	/// <param name="mediaType">The media type to add to the Accept header. For example, "application/json" or "text/plain".</param>
	/// <returns>The same <see cref="HttpRequestMessage"/> instance, allowing for method chaining.</returns>
	public static HttpRequestMessage WithMediaType(this HttpRequestMessage httpRequestMessage, string mediaType)
	{
		httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
		return httpRequestMessage;
	}
}
