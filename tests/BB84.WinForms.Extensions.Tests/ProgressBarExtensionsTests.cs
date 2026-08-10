// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.WinForms.Extensions.Tests.Common;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ProgressBarExtensionsTests
{
	[TestMethod]
	public void WithValueBindingTest()
	{
		var dataSource = new { Value = 50 };
		using ProgressBar progressBar = new();

		progressBar.WithValueBinding(dataSource, nameof(progressBar.Value));

		BindingAssert.IsSingleBinding(progressBar, nameof(progressBar.Value), dataSource);
	}
}
