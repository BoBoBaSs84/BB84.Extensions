using System.Globalization;

namespace BB84.Extensions;

/// <summary>
/// The integer extensions class.
/// </summary>
public static class IntegerExtensions
{
	/// <summary>
	/// Converts the value of the specified object to a 32-bit signed integer, using invariant culture formatting information.
	/// </summary>
	/// <param name="value">An object that implements the <see cref="IConvertible"/> interface.</param>
	/// <returns>A 32-bit signed integer that is equivalent to value, or zero if value is null.</returns>
	public static int ToInt32Invariant(this object? value)
		=> Convert.ToInt32(value, CultureInfo.InvariantCulture);
}
