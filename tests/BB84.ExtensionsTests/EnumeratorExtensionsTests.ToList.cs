using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class EnumeratorExtensionsTests
{
	[TestMethod]
	public void ToListTest()
	{
		TestType type = TestType.None;

		IEnumerable<TestType> list = type.ToList();

		Assert.AreEqual(3, list.Count());
	}
}
