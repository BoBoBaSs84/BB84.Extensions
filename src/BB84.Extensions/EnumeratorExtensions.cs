namespace BB84.Extensions;

/// <summary>
/// The enumerator extensions class.
/// </summary>
public static class EnumeratorExtensions
{
	/// <summary>
	/// Returns a list of all enumerators of the given type of enum.
	/// </summary>
	/// <typeparam name="T">The type of the enumerator.</typeparam>
	/// <param name="enumValue">The value of the enumerator.</param>
	/// <returns>A list of all enums of the provided type.</returns>
	public static IEnumerable<T> ToList<T>(this T enumValue) where T : Enum
		=> Enum.GetValues(enumValue.GetType()).Cast<T>().ToList();
}
