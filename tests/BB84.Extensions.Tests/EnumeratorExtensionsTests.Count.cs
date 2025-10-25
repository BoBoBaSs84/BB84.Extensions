// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class EnumeratorExtensionsTests
{
	[TestMethod(DisplayName = "Should return the total number of enums of the givent type.")]
	public void Count()
	{
		TestType type = TestType.None;

		int i = type.Count();

		Assert.AreEqual(3, i);
	}
}
