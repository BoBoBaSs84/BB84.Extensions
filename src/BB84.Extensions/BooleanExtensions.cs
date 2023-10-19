namespace BB84.Extensions;

/// <summary>
/// The boolean extensions class.
/// </summary>
public static class BooleanExtensions
{
	/// <summary>
	/// Checks if the provided value is true.
	/// </summary>
	/// <param name="value">The <see cref="bool"/> value to work with.</param>
	/// <returns><see langword="true"/> or <see langword="false"/></returns>
	public static bool IsTrue(this bool value)
		=> value.Equals(true);

	/// <summary>
	/// Checks if the provided value is false.
	/// </summary>
	/// <param name="boolValue">The <see cref="bool"/> value to work with.</param>
	/// <returns><see langword="true"/> or <see langword="false"/></returns>
	public static bool IsFalse(this bool boolValue)
		=> boolValue.Equals(false);
}
