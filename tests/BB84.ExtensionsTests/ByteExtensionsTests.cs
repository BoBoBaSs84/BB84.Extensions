using BB84.Extensions;

namespace BB84.ExtensionsTests;

[TestClass]
public class ByteExtensionsTests
{
	[TestMethod]
	public void GetHexStringTest()
	{
		byte[] inputBuffer = { 255, 255 };

		string outputString = inputBuffer.GetHexString();

		Assert.AreEqual("FFFF", outputString);
	}
}
