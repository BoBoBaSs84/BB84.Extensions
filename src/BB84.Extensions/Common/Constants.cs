namespace BB84.Extensions.Common;

/// <summary>
/// Provides a container for package wide constant values.
/// </summary>
internal static class Constants
{
	/// <summary>
	/// Provides constants for HTTP header names.
	/// </summary>
	internal static class HttpHeaders
	{
		/// <summary>
		/// Represents the authentication scheme used for Bearer tokens.
		/// </summary>
		internal const string BearerScheme = "Bearer";

		/// <summary>
		/// Represents the authentication scheme name for Basic Authentication.
		/// </summary>
		public const string BasicScheme = "Basic";
	}
}
