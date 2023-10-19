using BB84.Extensions;

namespace BB84.ExtensionsTests;

[TestClass]
public class BooleanExtensionsTests
{
	[TestMethod]
	public void IsTrueTest()
	{
		bool value = true;

		bool result = value.IsTrue();

		Assert.IsTrue(result);
	}

	[TestMethod]
	public void IsFalseTest()
	{
		bool value = false;

		bool result = value.IsFalse();

		Assert.IsTrue(result);
	}
}
