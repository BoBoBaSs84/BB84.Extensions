namespace BB84.Extensions;

public static partial class BooleanExtensions
{
	/// <summary>
	/// Checks if the provided <paramref name="value"/> is <see langword="false"/>.
	/// </summary>
	/// <param name="value">The <see cref="bool"/> value to work with.</param>
	/// <returns><see langword="true"/> if the <paramref name="value"/> is false, otherwise <see langword="false"/></returns>
	public static bool IsFalse(this bool value)
		=> value.Equals(false);

	/// <summary>
	/// Checks if the provided <paramref name="value"/> is <see langword="false"/>.
	/// </summary>
	/// <param name="value">The nullable <see cref="bool"/> value to work with.</param>
	/// <returns><see langword="true"/> if the <paramref name="value"/> is false, otherwise <see langword="false"/></returns>
	public static bool IsFalse(this bool? value)
		=> value.HasValue && value.Value.Equals(false);
}
