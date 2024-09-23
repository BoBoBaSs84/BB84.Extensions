namespace BB84.Extensions;

public static partial class BooleanExtensions
{
	/// <summary>
	/// Checks if the provided <paramref name="value"/> is <see langword="true"/>.
	/// </summary>
	/// <param name="value">The <see cref="bool"/> value to work with.</param>
	/// <returns><see langword="true"/> if the <paramref name="value"/> is true, otherwise <see langword="false"/></returns>
	public static bool IsTrue(this bool value)
		=> value.Equals(true);

	/// <summary>
	/// Checks if the provided <paramref name="value"/> is <see langword="true"/>.
	/// </summary>
	/// <param name="value">The nullable <see cref="bool"/> value to work with.</param>
	/// <returns><see langword="true"/> if the <paramref name="value"/> is true, otherwise <see langword="false"/></returns>
	public static bool IsTrue(this bool? value)
		=> value.HasValue && value.Value.Equals(true);
}
