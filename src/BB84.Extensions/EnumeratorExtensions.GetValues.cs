namespace BB84.Extensions;

public static partial class EnumeratorExtensions
{
	/// <summary>
	/// Returns an <see cref="IEnumerable{T}"/> of all enumerators of the given type of enum.
	/// </summary>
	/// <typeparam name="T">The type of the enumerator.</typeparam>
	/// <param name="value">The value of the enumerator.</param>
	/// <returns>An <see cref="IEnumerable{T}"/> of all enumerators of the provided type.</returns>
	public static IEnumerable<T> GetValues<T>(this T value) where T : struct, IComparable, IFormattable, IConvertible
		=> Enum.GetValues(value.GetType()).Cast<T>().ToArray();
}
