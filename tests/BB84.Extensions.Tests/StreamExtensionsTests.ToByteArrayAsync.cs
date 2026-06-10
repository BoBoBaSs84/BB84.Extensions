// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class StreamExtensionsTests
{
	[TestMethod]
	[DynamicData(nameof(GetData))]
	public async Task ToByteArrayAsyncTest(byte[] buffer)
	{
		using CancellationTokenSource cts = new();
		MemoryStream stream = new(buffer);

		byte[] result = await stream
			.ToByteArrayAsync(cts.Token)
			.ConfigureAwait(false);

		Assert.IsTrue(result.SequenceEqual(buffer));
	}

	[TestMethod]
	public async Task ToByteArrayAsyncCancelledTest()
	{
		using CancellationTokenSource cts = new();
		cts.Cancel();

		MemoryStream stream = new([1, 2, 3]);

		await Assert.ThrowsAsync<OperationCanceledException>(
			() => stream.ToByteArrayAsync(cts.Token)).ConfigureAwait(false);
	}
}
