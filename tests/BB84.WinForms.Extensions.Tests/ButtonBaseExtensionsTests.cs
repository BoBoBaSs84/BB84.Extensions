// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Reflection;
using System.Windows.Input;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ButtonBaseExtensionsTests
{
	[TestMethod]
	public void WithCommandBindingShouldBindSimpleCommand()
	{
		bool isCommandExecuted = false;
		bool canCommandExecute = true;
		ICommand command = new TestCommand(() => isCommandExecuted = true, () => canCommandExecute);
		using Button button = new();

		button.WithCommandBinding(command);
		button.PerformClick();

		Assert.IsTrue(isCommandExecuted, "The command should have been executed when the button was clicked.");
		Assert.IsTrue(button.Enabled, "The button should be enabled when the command can execute.");
	}
#if NET5_0_OR_GREATER

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithCommandBindingShouldBindCommand(ButtonBase buttonBase)
	{
		var dataSource = new { Command = new TestCommand(() => { }, () => true) };

		buttonBase.WithCommandBinding(dataSource, nameof(dataSource.Command));

		Assert.AreEqual(1, buttonBase.DataBindings.Count);
		Assert.AreEqual(nameof(buttonBase.Command), buttonBase.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, buttonBase.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, buttonBase.DataBindings[0].DataSourceUpdateMode);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithCommandParameterBindingShouldBindCommandParameter(ButtonBase buttonBase)
	{
		var dataSource = new { CommandParameter = new object() };

		buttonBase.WithCommandParameterBinding(dataSource, nameof(dataSource.CommandParameter));

		Assert.AreEqual(1, buttonBase.DataBindings.Count);
		Assert.AreEqual(nameof(buttonBase.CommandParameter), buttonBase.DataBindings[0].PropertyName);
		Assert.AreEqual(dataSource, buttonBase.DataBindings[0].DataSource);
		Assert.AreEqual(DataSourceUpdateMode.OnPropertyChanged, buttonBase.DataBindings[0].DataSourceUpdateMode);
	}
#endif

	private sealed class TestCommand(Action execute, Func<bool>? canExecute) : ICommand
	{
		public event EventHandler? CanExecuteChanged;
		public bool CanExecute(object? parameter) => canExecute?.Invoke() ?? true;
		public void Execute(object? parameter)
		{
			if (CanExecute(parameter))
			{
				execute.Invoke();
				CanExecuteChanged?.Invoke(this, EventArgs.Empty);
			}
		}
	}

	private static List<ButtonBase> GetControls()
	{
		Assembly assembly = typeof(ButtonBase).Assembly;

		IEnumerable<Type> types = assembly.GetTypes()
			.Where(t => typeof(ButtonBase).IsAssignableFrom(t) && !t.IsAbstract);

		List<ButtonBase> controls = [];

		foreach (Type type in types)
		{
			try
			{
				if (Activator.CreateInstance(type) is ButtonBase control)
					controls.Add(control);
			}
			catch (Exception ex)
			{
				// Handle exceptions for types that cannot be instantiated
				Console.WriteLine($"Could not create instance of {type.Name}: {ex.Message}");
			}
		}

		return controls;
	}

	private static IEnumerable<object[]> TestData()
	{
		foreach (Control control in GetControls())
			yield return new object[] { control };
	}
}
