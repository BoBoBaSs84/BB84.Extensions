using BB84.Extensions.Helper;

namespace BB84.Extensions;

public static partial class ArrayExtensions
{
	/// <summary>
	/// returns a randomly choosen item from a given array.
	/// </summary>
	/// <typeparam name="T">Type of objects in the array.</typeparam>
	/// <param name="values">The array of objects to choose from.</param>
	/// <returns>A random item from the array.</returns>
	public static T RandomChoice<T>(this T[] values)
		=> values[RandomHelper.Random.Next(0, values.Length)];
}
