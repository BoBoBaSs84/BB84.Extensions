using BB84.Extensions;

namespace BB84.ExtensionsTests;

[TestClass]
public sealed partial class StreamExtensionsTests
{
	private readonly static Random Random = new();

	[DataTestMethod]
	[DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
	public void ToByteArrayTest(byte[] buffer)
	{
		MemoryStream stream = new(buffer);

		byte[] result = stream.ToByteArray();

		Assert.IsTrue(result.SequenceEqual(buffer));
	}

	private static IEnumerable<object[]> GetData()
	{
		for (int i = 0; i < 10; i++)
		{
			byte[] buffer = new byte[10];
			Random.NextBytes(buffer);
			yield return new object[] { buffer };
		}
	}
}
