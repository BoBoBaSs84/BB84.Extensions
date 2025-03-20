namespace BB84.Extensions.Tests;

[TestClass]
public partial class ByteExtensionsTests
{
	[TestMethod]
	public void GetHexStringTest()
	{
		byte[] bytes = [255, 255];

		string result = bytes.GetHexString();

		Assert.AreEqual("FFFF", result);
	}
}
