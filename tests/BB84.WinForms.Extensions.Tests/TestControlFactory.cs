// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Reflection;

namespace BB84.WinForms.Extensions.Tests;

/// <summary>
/// Supplies every instantiable component of a given base type as test data.
/// </summary>
internal static class TestControlFactory
{
	/// <summary>
	/// Yields one row per instantiable type assignable to <typeparamref name="T"/>.
	/// </summary>
	internal static IEnumerable<object[]> TestData<T>() where T : class
	{
		foreach (T control in GetControls<T>())
			yield return [control];
	}

	private static List<T> GetControls<T>() where T : class
	{
		IEnumerable<Type> types = typeof(T).Assembly.GetTypes()
			.Where(type => typeof(T).IsAssignableFrom(type) && !type.IsAbstract);

		List<T> controls = [];

		foreach (Type type in types)
		{
			try
			{
				if (Activator.CreateInstance(type) is T control)
					controls.Add(control);
			}
			catch (Exception ex)
			{
				// Not every type in the assembly has a usable parameterless constructor.
				Console.WriteLine($"Could not create instance of {type.Name}: {ex.Message}");
			}
		}

		return controls;
	}
}
