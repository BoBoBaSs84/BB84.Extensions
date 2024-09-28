namespace BB84.Extensions;

public static partial class IntegerExtensions
{
	/// <summary>
	/// Indicates whether the specified integer value is <see langword="null"/> or not.
	/// </summary>
	/// <param name="value">The integer value to test.</param>
	/// <returns><see langword="true"/> if the <paramref name="value"/>
	/// is <see langword="null"/>, otherwise <see langword="false"/>.</returns>
	public static bool IsNull(this int? value)
		=> value.HasValue.Equals(false);
}
