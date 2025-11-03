// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

[TestClass]
public sealed partial class EnumerableExtensionsTests
{
	[TestMethod]
	public void IsEmptyWithEmptyCollectionReturnsTrue()
	{
		IEnumerable<int> collection = [];

		bool result = collection.IsEmpty();

		Assert.IsTrue(result);
	}

	[TestMethod]
	public void IsEmptyWithNonEmptyCollectionReturnsFalse()
	{
		IEnumerable<int> collection = [1, 2, 3];

		bool result = collection.IsEmpty();

		Assert.IsFalse(result);
	}

	[TestMethod]
	public void IsNotEmptyWithEmptyCollectionReturnsFalse()
	{
		IEnumerable<int> collection = [];

		bool result = collection.IsNotEmpty();

		Assert.IsFalse(result);
	}

	[TestMethod]
	public void IsNotEmptyWithNonEmptyCollectionReturnsTrue()
	{
		IEnumerable<int> collection = [1, 2, 3];

		bool result = collection.IsNotEmpty();

		Assert.IsTrue(result);
	}

	[TestMethod]
	public void IsNullOrEmptyWithNullCollectionReturnsTrue()
	{
		IEnumerable<int>? collection = null;

		bool result = collection.IsNullOrEmpty();

		Assert.IsTrue(result);
	}

	[TestMethod]
	public void IsNullOrEmptyWithEmptyCollectionReturnsTrue()
	{
		IEnumerable<int>? collection = [];

		bool result = collection.IsNullOrEmpty();

		Assert.IsTrue(result);
	}

	[TestMethod]
	public void IsNullOrEmptyWithNonEmptyCollectionReturnsFalse()
	{
		IEnumerable<int>? collection = [1, 2, 3];
		
		bool result = collection.IsNullOrEmpty();
		
		Assert.IsFalse(result);
	}

	[TestMethod]
	public void IsNotNullOrEmptyWithNullCollectionReturnsFalse()
	{
		IEnumerable<int>? collection = null;
		
		bool result = collection.IsNotNullOrEmpty();
		
		Assert.IsFalse(result);
	}

	[TestMethod]
	public void IsNotNullOrEmptyWithEmptyCollectionReturnsFalse()
	{
		IEnumerable<int>? collection = [];
		
		bool result = collection.IsNotNullOrEmpty();
		
		Assert.IsFalse(result);
	}

	[TestMethod]
	public void IsNotNullOrEmptyWithNonEmptyCollectionReturnsTrue()
	{
		IEnumerable<int>? collection = [1, 2, 3];
		
		bool result = collection.IsNotNullOrEmpty();
		
		Assert.IsTrue(result);
	}

	private sealed class TestClass
	{
		public int Value { get; set; }
	}
}
