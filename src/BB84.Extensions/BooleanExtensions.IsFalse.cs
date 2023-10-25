namespace BB84.Extensions;

public static partial class BooleanExtensions
{
	/// <summary>
	/// Checks if the provided value is false.
	/// </summary>
	/// <param name="boolValue">The <see cref="bool"/> value to work with.</param>
	/// <returns><see langword="true"/> or <see langword="false"/></returns>
	public static bool IsFalse(this bool boolValue)
		=> boolValue.Equals(false);
}
