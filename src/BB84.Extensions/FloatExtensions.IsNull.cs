namespace BB84.Extensions;

public static partial class FloatExtensions
{
	/// <summary>
	/// Indicates whether the specified float value is <see langword="null"/> or not.
	/// </summary>
	/// <param name="value">The float value to check.</param>
	/// <returns><see langword="true"/> if the <paramref name="value"/>
	/// is <see langword="null"/>, otherwise <see langword="false"/>.</returns>
	public static bool IsNull(this float? value)
		=> value.HasValue.Equals(false);
}
