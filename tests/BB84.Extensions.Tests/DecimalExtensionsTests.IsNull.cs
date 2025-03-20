namespace BB84.Extensions.Tests;

public sealed partial class DecimalExtensionsTests
{
	[TestMethod]
	public void IsNullTrueTest()
	{
		decimal? value = null;

		Assert.AreEqual(true, value.IsNull());
	}

	[TestMethod]
	public void IsNullFalseTest()
	{
		decimal? value = 13.753m;

		Assert.AreEqual(false, value.IsNull());
	}
}
