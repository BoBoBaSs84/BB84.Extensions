namespace BB84.Extensions;

/// <summary>
/// The integer extensions class.
/// </summary>
public static class IntegerExtensions
{
	/// <summary>
	/// Iterates over an integer array and executes an Action on each element.
	/// </summary>
	/// <param name="value">The value from which to iterate.</param>
	/// <param name="maxValue">The value up to which to iterate.</param>
	/// <param name="action">An Action to invoke on each integer.</param>
	public static void For(this int value, int maxValue, Action<int> action)
	{
		for (int i = value; i <= maxValue; i++)
			action(i);
	}

	/// <summary>
	/// Returns an array of integers starting from the <paramref name="value"/> to the <paramref name="maxValue"/>.
	/// </summary>
	/// <param name="value">The value to start from.</param>
	/// <param name="maxValue">The value to end with.</param>
	/// <returns>An array of integers.</returns>
	/// /// <exception cref="ArgumentOutOfRangeException"></exception>
	public static int[] ArrayUp(this int value, int maxValue)
	{
		if (value > maxValue)
			throw new ArgumentOutOfRangeException(nameof(maxValue), "Maximum value must be greater than the starting value.");

		int[] array = new int[maxValue + 1];
		for (int i = value; i <= maxValue; i++)
			array[i] = i;
		return array;
	}

	/// <summary>
	/// Returns an array of integers starting from the <paramref name="minValue"/> to the <paramref name="value"/>.
	/// </summary>
	/// <param name="value">The value to end with.</param>
	/// <param name="minValue">The value to start from.</param>
	/// <returns>An array of integers.</returns>
	public static int[] ArrayDown(this int value, int minValue)
	{
		if (value < minValue)
			throw new ArgumentOutOfRangeException(nameof(minValue), "Minimum value must be smaller than the starting value.");

		int[] array = new int[value + 1];
		for (int i = minValue; i <= value; i++)
			array[i] = i;
		return array;
	}
}
