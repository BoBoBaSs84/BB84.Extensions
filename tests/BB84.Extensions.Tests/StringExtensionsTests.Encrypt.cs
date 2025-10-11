// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.Extensions.Tests;

public sealed partial class StringExtensionsTests
{
	[TestMethod]
	public void EncryptDecryptSuccessTest()
	{
		string original = "This is a test string for encryption.";
		string password = "StrongPassword123!";
		string encrypted = original.Encrypt(password);

		Assert.AreNotEqual(original, encrypted);

		string decrypted = encrypted.Decrypt(password);

		Assert.AreEqual(original, decrypted);
	}
}
