namespace BB84.Extensions.Tests;

[TestClass]
public sealed partial class ListExtensionsTests
{
	private sealed class TestClass
	{
		public Guid Id { get; } = Guid.NewGuid();
	}
}
