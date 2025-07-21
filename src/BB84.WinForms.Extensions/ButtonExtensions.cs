// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Windows.Input;

namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="Button"/> control to simplify data binding.
/// </summary>
public static class ButtonExtensions
{
	/// <summary>
	/// Binds a command to a <see cref="Button"/>, enabling the button's click event to execute the command and dynamically
	/// updating the button's enabled state based on the command's executability.
	/// </summary>
	/// <remarks>
	/// This method attaches event handlers to the button and the command to ensure that:
	/// <list type="bullet">
	/// <item>The button's <see cref="Control.Click"/> event executes the command when clicked.</item>
	/// <item>The button's <see cref="Control.Enabled"/> property is updated dynamically based on the <see cref="ICommand.CanExecute"/> state.</item>
	/// </list>
	/// When the button is disposed, the event handlers are automatically detached to prevent memory leaks.
	/// </remarks>
	/// <param name="button">The <see cref="Button"/> to bind the command to.</param>
	/// <param name="command">The <see cref="ICommand"/> to bind to the button.</param>
	/// <returns>
	/// The <see cref="Button"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static Button WithCommandBinding(this Button button, ICommand command)
	{
		void Click(object? sender, EventArgs args) => command.Execute(null);
		void CanExecuteChanged(object? sender, EventArgs args) => button.Enabled = command.CanExecute(null);

		button.Enabled = command.CanExecute(null);

		button.Click += Click;
		command.CanExecuteChanged += CanExecuteChanged;

		button.Disposed += (sender, args) =>
		{
			button.Click -= Click;
			command.CanExecuteChanged -= CanExecuteChanged;
		};

		return button;
	}
}
