namespace BB84.Extensions;

public static partial class DoubleExtensions
{
	/// <summary>
	/// Indicates whether the specified double value is <see langword="null"/> or not.
	/// </summary>
	/// <param name="value">The double value to test.</param>
	/// <returns><see langword="true"/> if the <paramref name="value"/>
	/// is <see langword="null"/>, otherwise <see langword="false"/>.</returns>
	public static bool IsNull(this double? value)
		=> value.HasValue.Equals(false);
}
