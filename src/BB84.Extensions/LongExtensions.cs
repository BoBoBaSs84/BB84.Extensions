namespace BB84.Extensions;

/// <summary>
/// Provides extension methods for working with nullable <see cref="long"/> values.
/// </summary>
/// <remarks>
/// This static class contains utility methods for common operations involving longs, such as creating
/// arrays of longs within a specified range, performing actions over a range of longs, and
/// determining whether nullable longs are null or non-null.
/// </remarks>
public static class LongExtensions
{
	/// <summary>
	/// Executes the specified action for each long from 0 to the specified value (exclusive).
	/// </summary>
	/// <remarks>
	/// This method iterates from 0 to <paramref name="value"/> - 1, invoking <paramref name="action"/>
	/// for each long.
	/// </remarks>
	/// <param name="value">The upper limit (exclusive) of the range.</param>
	/// <param name="action">The action to execute for each long in the range.</param>
	public static void For(this long value, Action<long> action)
	{
		for (long i = 0; i < value; i++)
			action(i);
	}

	/// <summary>
	/// Determines whether the specified long is equal to its default value (0).
	/// </summary>
	/// <param name="value">The long to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is equal to its default value (0);
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsDefault(this long value)
		=> value.Equals(default);

	/// <summary>
	/// Determines whether the specified nullable long is equal to its default value <see langword="null"/>.
	/// </summary>
	/// <param name="value">The nullable long to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is equal to its default value <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsDefault([NotNullWhen(false)] this long? value)
		=> value.Equals(default);

	/// <summary>
	/// Determines whether the specified long is not equal to its default value (0).
	/// </summary>
	/// <param name="value">The long to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is not equal to its default value (0);
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotDefault(this long value)
		=> value.Equals(default).Equals(false);

	/// <summary>
	/// Determines whether the specified long is not equal to its default value <see langword="null"/>.
	/// </summary>
	/// <param name="value">The long to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is not equal to its default value <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotDefault([NotNullWhen(true)] this long? value)
		=> value.Equals(default).Equals(false);

	/// <summary>
	/// Determines whether the specified nullable long has a null value.
	/// </summary>
	/// <param name="value">The nullable long to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNull([NotNullWhen(false)] this long? value)
		=> value.HasValue.Equals(false);

	/// <summary>
	/// Determines whether the specified nullable long has a non-null value.
	/// </summary>
	/// <param name="value">The nullable long to check.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="value"/> is not <see langword="null"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool IsNotNull([NotNullWhen(true)] this long? value)
		=> value.HasValue.Equals(true);
}
