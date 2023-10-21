using BB84.Extensions.Helper;

namespace BB84.ExtensionsTests.Helper;

[TestClass]
public sealed class StringWriterWithEncodingTests
{
	[TestMethod("String writer with encoding empty constructor test")]
	public void EmptyConstructor()
	{
		StringWriterWithEncoding stringWriter;

		stringWriter = new();

		Assert.IsNotNull(stringWriter);
		Assert.IsNotNull(stringWriter.Encoding);
	}
}
