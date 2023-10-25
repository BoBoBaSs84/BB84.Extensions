namespace BB84.Extensions;

public static partial class EnumeratorExtensions
{
	/// <summary>
	/// Returns the total number of the provided enumerator type.
	/// </summary>
	/// <typeparam name="T">The type of the enumerator.</typeparam>
	/// <param name="value">The value of the enumerator.</param>
	/// <returns>The total number of the provided enumerator type.</returns>
	public static int Count<T>(this T value) where T : struct, IComparable, IFormattable, IConvertible
		=> Enum.GetValues(value.GetType()).Length;
}
