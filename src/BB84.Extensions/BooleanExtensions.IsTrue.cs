namespace BB84.Extensions;

public static partial class BooleanExtensions
{
	/// <summary>
	/// Checks if the provided value is true.
	/// </summary>
	/// <param name="value">The <see cref="bool"/> value to work with.</param>
	/// <returns><see langword="true"/> or <see langword="false"/></returns>
	public static bool IsTrue(this bool value)
		=> value.Equals(true);
}
