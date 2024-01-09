using System.Drawing;

namespace BB84.Extensions;

public static partial class ColorExtensions
{
	/// <summary>
	/// Retunrs the <see cref="Color"/> as ARGB hex representation (i.e. <b>#FF00FF00</b>)
	/// </summary>
	/// <param name="value">The color to convert.</param>
	/// <returns>The color as hex string.</returns>
	public static string ToARGBHexString(this Color value)
		=> $"#{value.A:X2}{value.R:X2}{value.G:X2}{value.B:X2}";
}
