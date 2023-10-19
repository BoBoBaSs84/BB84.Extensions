using BB84.Extensions;

namespace BB84.ExtensionsTests;

[TestClass]
public class EnumerableExtensionsTests
{
	[TestMethod]
	public void ForEachTest()
	{
		IList<TestClass> list = new List<TestClass>();
		for (int i = 0; i < 10; i++)
			list.Add(new TestClass() { Value = i + 1 });

		int sumOne = list.Sum(x => x.Value);

		list.ForEach(x => ++x.Value);
		int sumTwo = list.Sum(x => x.Value);

		Assert.AreNotEqual(sumOne, sumTwo);
	}

	private class TestClass
	{
		public int Value { get; set; }
	}
}
