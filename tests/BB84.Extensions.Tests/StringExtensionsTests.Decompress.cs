namespace BB84.Extensions.Tests;

public partial class StringExtensionsTests
{
	[TestMethod]
	public void Uncompress()
	{
		string compressed = CompressedContent;

		string decompressed = compressed.Decompress();

		Assert.AreNotEqual(compressed, decompressed);
		Assert.AreEqual(DecompressedContent, decompressed);
	}
}
