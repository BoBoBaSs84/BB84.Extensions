// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class ObjectExtensionsTests
{
	[TestMethod(DisplayName = "Object to invariant short test")]
	public void ToInt16Invariant()
	{
		object value = short.MaxValue;

		short s = value.ToInt16Invariant();

		Assert.AreEqual(short.MaxValue, s);
	}
}
