// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public partial class ByteExtensionsTests
{
	[TestMethod]
	[DataRow("This is a long test string for testing stuff.", "AEBEC276E361BE89B5BB0597908754E1229B17C6E889D802A3B9D34DBE858F02F97DAD118BA4AB6BEC980AE935E5FB542518916102D641A1245D24622B3299D7")]
	[DataRow("This is another long test string for testing stuff.", "2F2B42A54E6BA48D203C93229957212B0654DC7B92DCECF16D621D580903AA88D73705F83345032AC6C3DE3A885707CB923006AD4AFF83CC6D75133B29D8F632")]
	public void GetSHA512StringTest(string input, string expected)
		=> Assert.AreEqual(expected, input.GetBytes().GetSHA512String());
}
