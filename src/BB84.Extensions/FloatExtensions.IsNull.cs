namespace BB84.Extensions;

public static partial class FloatExtensions
{
	/// <summary>
	/// Indicates whether the specified float is null.
	/// </summary>
	/// <param name="value">The float value to test.</param>
	/// <returns><see langword="true"/> if the <paramref name="value"/>
	/// is <see langword="null"/>, otherwise <see langword="false"/>.</returns>
	public static bool IsNull(this float? value)
		=> value.HasValue.Equals(false);
}
