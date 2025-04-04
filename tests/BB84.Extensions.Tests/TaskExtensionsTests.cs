// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

[TestClass]
public sealed partial class TaskExtensionsTests
{
	private static async Task<bool> BoolTask(bool throwException = false)
	{
		if (throwException)
		{
			await Task.Delay(50)
				.ConfigureAwait(true);

			throw new InvalidOperationException();
		}

		return true;
	}

	private static async Task AwaitableTask(bool throwException = false)
	{
		if (throwException)
		{
			await Task.Delay(50)
				.ConfigureAwait(true);

			throw new InvalidOperationException();
		}
	}
}
