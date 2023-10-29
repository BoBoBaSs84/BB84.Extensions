using BB84.Extensions;

namespace BB84.ExtensionsTests;

[TestClass]
public partial class ByteExtensionsTests
{
	[TestMethod]
	public void GetHexStringTest()
	{
		byte[] bytes = { 255, 255 };

		string result = bytes.GetHexString();

		Assert.AreEqual("FFFF", result);
	}
}
