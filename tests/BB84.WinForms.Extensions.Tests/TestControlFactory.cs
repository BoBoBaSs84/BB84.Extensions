// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
namespace BB84.WinForms.Extensions.Tests;

/// <summary>
/// Supplies every instantiable component of a given base type as test data.
/// </summary>
/// <remarks>
/// The rows carry the type, not an instance. Data rows are enumerated once, before any test runs, so
/// yielding instances handed the same object to every row that used it and left all of them
/// undisposed. Creating the control inside the test keeps each case independent and lets the test
/// dispose what it made.
/// </remarks>
internal static class TestControlFactory
{
	/// <summary>
	/// Yields one row per instantiable type assignable to <typeparamref name="T"/>.
	/// </summary>
	/// <typeparam name="T">The base type whose implementations should be returned.</typeparam>
	/// <returns>One row per instantiable type.</returns>
	internal static IEnumerable<object[]> TestData<T>() where T : class
	{
		foreach (Type type in GetControlTypes<T>())
			yield return [type];
	}

	/// <summary>
	/// Creates an instance of the specified control type.
	/// </summary>
	/// <typeparam name="T">The type to return the instance as.</typeparam>
	/// <param name="type">The concrete type to instantiate.</param>
	/// <returns>The newly created control.</returns>
	internal static T Create<T>(Type type) where T : class
		=> (T)Activator.CreateInstance(type)!;

	private static List<Type> GetControlTypes<T>() where T : class
	{
		IEnumerable<Type> types = typeof(T).Assembly.GetTypes()
			.Where(type => typeof(T).IsAssignableFrom(type) && !type.IsAbstract);

		List<Type> usableTypes = [];

		foreach (Type type in types)
		{
			try
			{
				// Creating and discarding one instance is the only reliable way to tell whether the
				// type can actually be constructed, which is what the rows promise.
				using (Activator.CreateInstance(type) as IDisposable)
				{
					usableTypes.Add(type);
				}
			}
			catch (Exception ex)
			{
				// Not every type in the assembly has a usable parameterless constructor.
				Console.WriteLine($"Could not create instance of {type.Name}: {ex.Message}");
			}
		}

		return usableTypes;
	}
}
