// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Windows.Input;

using BB84.WinForms.Extensions.Tests.Common;

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

	[TestMethod]
	public void BindingACommandTwiceShouldNotExecuteItTwicePerClick()
	{
		int executions = 0;
		ICommand command = new TestCommand(() => executions++, () => true);
		using Button button = new();

		button.WithCommandBinding(command);
		button.WithCommandBinding(command);
		button.PerformClick();

		Assert.AreEqual(1, executions, "Rebinding should replace the previous subscription, not add to it.");
	}

	[TestMethod]
	public void RebindingADifferentCommandShouldOnlyExecuteTheNewOne()
	{
		int firstExecutions = 0;
		int secondExecutions = 0;
		ICommand first = new TestCommand(() => firstExecutions++, () => true);
		ICommand second = new TestCommand(() => secondExecutions++, () => true);
		using Button button = new();

		button.WithCommandBinding(first);
		button.WithCommandBinding(second);
		button.PerformClick();

		Assert.AreEqual(0, firstExecutions);
		Assert.AreEqual(1, secondExecutions);
	}
#if NET5_0_OR_GREATER

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithCommandBindingShouldBindCommand(Type type)
	{
		using ButtonBase buttonBase = TestControlFactory.Create<ButtonBase>(type);
		var dataSource = new { Command = new TestCommand(() => { }, () => true) };

		buttonBase.WithCommandBinding(dataSource, nameof(dataSource.Command));

		BindingAssert.IsSingleBinding(buttonBase, nameof(buttonBase.Command), dataSource);
	}

	[TestMethod]
	[DynamicData(nameof(TestData))]
	public void WithCommandParameterBindingShouldBindCommandParameter(Type type)
	{
		using ButtonBase buttonBase = TestControlFactory.Create<ButtonBase>(type);
		var dataSource = new { CommandParameter = new object() };

		buttonBase.WithCommandParameterBinding(dataSource, nameof(dataSource.CommandParameter));

		BindingAssert.IsSingleBinding(buttonBase, nameof(buttonBase.CommandParameter), dataSource);
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

	private static IEnumerable<object[]> TestData()
		=> TestControlFactory.TestData<ButtonBase>();
}
