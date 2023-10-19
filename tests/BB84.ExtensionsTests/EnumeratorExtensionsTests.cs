using BB84.Extensions;

namespace BB84.ExtensionsTests;

[TestClass]
public class EnumeratorExtensionsTests
{
	[TestMethod]
	public void ToListTest()
	{
		TestType type = TestType.None;

		IEnumerable<TestType> list = type.ToList();

		Assert.AreEqual(3, list.Count());
	}

	[TestMethod]
	public void ToIntTest()
	{
		TestType type = TestType.Two;

		int value = type.ToInt();

		Assert.AreEqual(2, value);
	}

	private enum TestType
	{
		None,
		One,
		Two
	}
}
