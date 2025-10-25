// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

[TestClass]
public sealed partial class StreamExtensionsTests
{
	private readonly static Random Random = new();

	[TestMethod]
	[DynamicData(nameof(GetData))]
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
