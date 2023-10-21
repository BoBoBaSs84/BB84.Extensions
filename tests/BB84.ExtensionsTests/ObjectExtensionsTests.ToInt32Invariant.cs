﻿using BB84.Extensions;

namespace BB84.ExtensionsTests;
public sealed partial class ObjectExtensionsTests
{
	[TestMethod("Object to invariant int test")]
	public void ToInt32Invariant()
	{
		object obj = 5;

		int i = obj.ToInt32Invariant();

		Assert.AreEqual(5, i);
	}
}
