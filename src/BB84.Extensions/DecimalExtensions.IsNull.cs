namespace BB84.Extensions;

public static partial class DecimalExtensions
{
	/// <summary>
	/// Indicates whether the specified decimal value is <see langword="null"/> or not.
	/// </summary>
	/// <param name="value">The decimal value to test.</param>
	/// <returns><see langword="true"/> if the <paramref name="value"/>
	/// is <see langword="null"/>, otherwise <see langword="false"/>.</returns>
	public static bool IsNull(this decimal? value)
		=> value.HasValue.Equals(false);
}
