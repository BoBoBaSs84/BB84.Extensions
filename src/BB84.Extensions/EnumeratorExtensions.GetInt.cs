namespace BB84.Extensions;

public static partial class EnumeratorExtensions
{
	/// <summary>
	/// Returns the integer value of an enumerator.
	/// </summary>
	/// <typeparam name="T">The type of the enumerator.</typeparam>
	/// <param name="value">The value of the enumerator.</param>
	/// <returns>The integer value of the enumerator.</returns>
	public static int GetInt<T>(this T value) where T : struct, IComparable, IFormattable, IConvertible
		=> (int)(object)value;
}
