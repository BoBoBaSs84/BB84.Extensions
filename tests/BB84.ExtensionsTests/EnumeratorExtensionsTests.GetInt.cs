using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class EnumeratorExtensionsTests
{
	[TestMethod]
	public void GetIntTest()
	{
		TestType type = TestType.Two;

		int value = type.GetInt();

		Assert.AreEqual(2, value);
	}
}
