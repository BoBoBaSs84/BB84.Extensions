namespace BB84.Extensions;

public static partial class BooleanExtensions
{
	/// <summary>
	/// Indicates whether the specified boolean is null.
	/// </summary>
	/// <param name="value">The boolean value to test.</param>
	/// <returns><see langword="true"/> if the <paramref name="value"/>
	/// is <see langword="null"/>, otherwise <see langword="false"/>.</returns>
	public static bool IsNull(this bool? value)
		=> value.HasValue.Equals(false);
}
