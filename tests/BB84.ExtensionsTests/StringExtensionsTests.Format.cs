using System.Globalization;

using BB84.Extensions;

namespace BB84.ExtensionsTests;

public sealed partial class StringExtensionsTests
{
	[TestMethod]
	public void FormatInvariantSuccessTest()
	{
		DateTime dateTime = DateTime.Now;
		string testString = @"Today is: {0}";

		string result = testString.FormatInvariant(dateTime);

		Assert.IsTrue(result.Contains(dateTime.ToString(CultureInfo.InvariantCulture)));
	}

	[TestMethod]
	public void FormatSuccessTest()
	{
		DateTime dateTime = DateTime.Now;
		string testString = @"Today is: {0}";

		string result = testString.Format(CultureInfo.GetCultureInfo("de-DE"), dateTime);

		Assert.IsTrue(result.Contains(dateTime.ToString(CultureInfo.GetCultureInfo("de-DE"))));
	}
}
