﻿// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Windows.Input;

namespace BB84.WinForms.Extensions.Tests;

[TestClass]
public sealed class ButtonExtensionsTests
{
	[TestMethod]
	public void WithCommandBindingTest()
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
	public void WithEnabledBindingTest()
	{
		Button button = new();

		button.WithEnabledBinding(new object(), nameof(button.Enabled));

		Assert.AreEqual(1, button.DataBindings.Count);
		Assert.AreEqual(nameof(button.Enabled), button.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithTextBindingTest()
	{
		Button button = new();

		button.WithTextBinding(new object(), nameof(button.Text));

		Assert.AreEqual(1, button.DataBindings.Count);
		Assert.AreEqual(nameof(button.Text), button.DataBindings[0].PropertyName);
	}

	[TestMethod]
	public void WithVisibleBindingTest()
	{
		Button button = new();

		button.WithVisibleBinding(new object(), nameof(button.Visible));

		Assert.AreEqual(1, button.DataBindings.Count);
		Assert.AreEqual(nameof(button.Visible), button.DataBindings[0].PropertyName);
	}

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
}
