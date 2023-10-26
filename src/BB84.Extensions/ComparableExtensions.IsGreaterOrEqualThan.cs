namespace BB84.Extensions;

public static partial class ComparableExtensions
{
	/// <summary>
	/// Check if a value is greater or equal than another value.
	/// </summary>
	/// <typeparam name="T">The type that implements <see cref="IComparable"/>.</typeparam>
	/// <param name="value">The value to compare.</param>
	/// <param name="otherValue">The value to compare with.</param>
	/// <returns>True if the value is greater or equal than the othe value, otherwise false.</returns>
	public static bool IsGreaterOrEqualThan<T>(this T value, T otherValue) where T : IComparable
		=> value.CompareTo(otherValue) >= 0;
}
