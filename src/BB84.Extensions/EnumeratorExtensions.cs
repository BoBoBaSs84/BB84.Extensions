namespace BB84.Extensions;

/// <summary>
/// The enumerator extensions class.
/// </summary>
public static class EnumeratorExtensions
{
	/// <summary>
	/// Returns the total number of the provided enumerator type.
	/// </summary>
	/// <typeparam name="T">The type of the enumerator.</typeparam>
	/// <param name="value">The value of the enumerator.</param>
	/// <returns>The total number of the provided enumerator type.</returns>
	public static int Count<T>(this T value) where T : Enum
		=> Enum.GetValues(value.GetType()).Length;

	/// <summary>
	/// Returns a list of all enumerators of the given type of enum.
	/// </summary>
	/// <typeparam name="T">The type of the enumerator.</typeparam>
	/// <param name="value">The value of the enumerator.</param>
	/// <returns>A list of all enumerators of the provided type.</returns>
	public static IEnumerable<T> ToList<T>(this T value) where T : Enum
		=> Enum.GetValues(value.GetType()).Cast<T>().ToList();

	/// <summary>
	/// Returns the integer value of an enumerator.
	/// </summary>
	/// <typeparam name="T">The type of the enumerator.</typeparam>
	/// <param name="value">The value of the enumerator.</param>
	/// <returns>The integer value of the enumerator.</returns>
	public static int ToInt<T>(this T value) where T : Enum
		=> (int)(object)value;
}
