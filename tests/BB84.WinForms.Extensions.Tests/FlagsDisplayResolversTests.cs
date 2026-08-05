// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.ComponentModel.DataAnnotations;

using BB84.WinForms.Extensions.Helpers;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class FlagsDisplayResolversTests
{
	[TestMethod]
	public void FromDescriptionAttributeShouldReturnTheDescription()
		=> Assert.AreEqual("The first one", FlagsDisplayResolvers.FromDescriptionAttribute(TestEnumerator.First));

	[TestMethod]
	public void FromDescriptionAttributeShouldFallBackToTheMemberName()
		=> Assert.AreEqual(nameof(TestEnumerator.Undecorated), FlagsDisplayResolvers.FromDescriptionAttribute(TestEnumerator.Undecorated));

	[TestMethod]
	public void FromDisplayAttributeShouldReturnTheDisplayName()
		=> Assert.AreEqual("First flag", FlagsDisplayResolvers.FromDisplayAttribute(TestEnumerator.First));

	[TestMethod]
	public void FromDisplayAttributeShouldFallBackToTheMemberName()
		=> Assert.AreEqual(nameof(TestEnumerator.Undecorated), FlagsDisplayResolvers.FromDisplayAttribute(TestEnumerator.Undecorated));

	[TestMethod]
	public void ResolversShouldFallBackToToStringForCombinedValues()
	{
		TestEnumerator combined = TestEnumerator.First | TestEnumerator.Undecorated;

		Assert.AreEqual(combined.ToString(), FlagsDisplayResolvers.FromDescriptionAttribute(combined));
		Assert.AreEqual(combined.ToString(), FlagsDisplayResolvers.FromDisplayAttribute(combined));
	}

	[TestMethod]
	public void RepeatedResolutionShouldReturnTheSameResult()
	{
		string first = FlagsDisplayResolvers.FromDescriptionAttribute(TestEnumerator.First);
		string second = FlagsDisplayResolvers.FromDescriptionAttribute(TestEnumerator.First);

		Assert.AreEqual(first, second);
	}

	[Flags]
	private enum TestEnumerator
	{
		None = 0,
		[System.ComponentModel.Description("The first one")]
		[Display(Name = "First flag")]
		First = 1,
		Undecorated = 2
	}
}
