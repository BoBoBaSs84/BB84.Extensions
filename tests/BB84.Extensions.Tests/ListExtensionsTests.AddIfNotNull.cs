namespace BB84.Extensions.Tests;

public sealed partial class ListExtensionsTests
{
	[TestMethod]
	public void AddIfNotNullTest()
	{
		IList<TestClass> target = new List<TestClass>();
		TestClass item = new();

		target.AddIfNotNull(item);

		Assert.AreEqual(1, target.Count);
	}

	[TestMethod]
	public void AddIfNotNullItemNullTest()
	{
		IList<TestClass> target = new List<TestClass>();
		TestClass item = default!;

		target.AddIfNotNull(item);

		Assert.AreEqual(0, target.Count);
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentNullException))]
	public void AddIfNotNullTargetNullTest()
	{
		IList<TestClass> target = default!;
		TestClass item = new();

		target.AddIfNotNull(item);
	}
}
