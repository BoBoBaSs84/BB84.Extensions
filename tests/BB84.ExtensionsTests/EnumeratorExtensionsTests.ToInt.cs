using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class EnumeratorExtensionsTests
{
	[TestMethod]
	public void ToIntTest()
	{
		TestType type = TestType.Two;

		int value = type.ToInt();

		Assert.AreEqual(2, value);
	}
}
