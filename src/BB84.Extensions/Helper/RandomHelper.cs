namespace BB84.Extensions.Helper;

/// <summary>
/// The random helper class.
/// </summary>
internal static class RandomHelper
{
	private static readonly Lazy<Random> LazyRandom = new(() => new(Guid.NewGuid().GetHashCode()));

	/// <summary>
	/// The pseudo-random number generator instance.
	/// </summary>
	public static Random Random => LazyRandom.Value;
}
