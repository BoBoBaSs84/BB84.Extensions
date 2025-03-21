namespace BB84.Extensions.Tests;

public sealed partial class EnumeratorExtensionsTests
{
	[TestMethod("Should return the total number of enums of the givent type.")]
	public void Count()
	{
		TestType type = TestType.None;

		int i = type.Count();

		Assert.AreEqual(3, i);
	}
}
