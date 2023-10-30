namespace BB84.Extensions;

public static partial class IntegerExtensions
{
	/// <summary>
	/// Iterates over an integer array and executes an Action on each element.
	/// </summary>
	/// <param name="value">The value until which to iterate.</param>
	/// <param name="action">An Action to invoke on each integer.</param>
	public static void For(this int value, Action<int> action)
	{
		for (int i = 0; i < value; i++)
			action(i);
	}
}
