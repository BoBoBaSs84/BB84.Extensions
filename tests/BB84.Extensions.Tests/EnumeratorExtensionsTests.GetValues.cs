using BB84.Extensions;

namespace BB84.Extensions.Tests;

public sealed partial class EnumeratorExtensionsTests
{
	[TestMethod]
	public void GetValuesTest()
	{
		TestType type = TestType.None;

		IEnumerable<TestType> list = type.GetValues();

		Assert.AreEqual(3, list.Count());
	}
}
