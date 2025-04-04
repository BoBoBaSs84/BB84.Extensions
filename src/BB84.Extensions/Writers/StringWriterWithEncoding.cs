// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Globalization;
using System.Text;

namespace BB84.Extensions.Writers;

/// <summary>
/// The string writer with encoding class.
/// </summary>
/// <remarks>
/// Overrides the base <see cref="StringWriter"/> class to accept a different character encoding type.
/// </remarks>
internal sealed class StringWriterWithEncoding : StringWriter
{
	private readonly Encoding? _encoding;

	/// <summary>
	/// Overrides the default encoding type (UTF-16).
	/// </summary>
	/// <inheritdoc/>
	public override Encoding Encoding
		=> _encoding ?? base.Encoding;

	/// <summary>
	/// Intializes a new instance of the <see cref="StringWriterWithEncoding"/> class.
	/// </summary>
	internal StringWriterWithEncoding() : base(CultureInfo.InvariantCulture)
	{ }

	/// <summary>
	/// Intializes a new instance of the <see cref="StringWriterWithEncoding"/> class.
	/// </summary>
	/// <param name="encoding">The character encoding type to use.</param>
	internal StringWriterWithEncoding(Encoding encoding) : this()
		=> _encoding = encoding;
}
