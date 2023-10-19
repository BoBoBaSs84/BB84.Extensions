using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class ListExtensionsTests
{
	[TestMethod]
	public void AddRangeIfNotNullTest()
	{
		IList<TestClass> target = new List<TestClass>();
		IEnumerable<TestClass> items = new List<TestClass>() { new(), default! };

		target.AddRangeIfNotNull(items);

		Assert.AreEqual(1, target.Count);
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentNullException))]
	public void AddRangeIfNotNullTargetNullTest()
	{
		IList<TestClass> target = default!;
		IEnumerable<TestClass> items = new List<TestClass>() { new() };

		target.AddRangeIfNotNull(items);
	}

	[TestMethod]
	public void AddRangeIfNotNullItemsNullTest()
	{
		IList<TestClass> target = new List<TestClass>();
		IEnumerable<TestClass> items = default!;

		target.AddRangeIfNotNull(items);

		Assert.AreEqual(0, target.Count);
	}

	[TestMethod]
	public void AddRangeIfNotNullItemsEmptyTest()
	{
		IList<TestClass> target = new List<TestClass>();
		IEnumerable<TestClass> items = new List<TestClass>();

		target.AddRangeIfNotNull(items);

		Assert.AreEqual(0, target.Count);
	}
}
