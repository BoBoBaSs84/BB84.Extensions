// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Runtime.CompilerServices;
using System.Windows.Input;

using BB84.WinForms.Extensions.Common;

namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="ButtonBase"/> control to simplify data binding.
/// </summary>
public static class ButtonBaseExtensions
{
	private static readonly ConditionalWeakTable<ButtonBase, CommandSubscription> Subscriptions = new();

	/// <summary>
	/// Binds a command to a <see cref="ButtonBase"/>, enabling the button's click event to execute the command and dynamically
	/// updating the button's enabled state based on the command's executability.
	/// </summary>
	/// <remarks>
	/// This method attaches event handlers to the button and the command to ensure that:
	/// <list type="bullet">
	/// <item>The button's <see cref="Control.Click"/> event executes the command when clicked.</item>
	/// <item>The button's <see cref="Control.Enabled"/> property is updated dynamically based on the <see cref="ICommand.CanExecute"/> state.</item>
	/// </list>
	/// When the button is disposed, the event handlers are automatically detached to prevent memory leaks.
	/// Calling this method again on the same button replaces the previous command binding, so the button
	/// never executes more than one command per click.
	/// </remarks>
	/// <param name="buttonBase">The <see cref="ButtonBase"/> to bind the command to.</param>
	/// <param name="command">The <see cref="ICommand"/> to bind to the button.</param>
	/// <returns>
	/// The <see cref="ButtonBase"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ButtonBase WithCommandBinding(this ButtonBase buttonBase, ICommand command)
	{
		DetachCommandSubscription(buttonBase);

		void Click(object? sender, EventArgs args) => command.Execute(null);
		void CanExecuteChanged(object? sender, EventArgs args) => buttonBase.Enabled = command.CanExecute(null);
		void Disposed(object? sender, EventArgs args) => DetachCommandSubscription(buttonBase);

		buttonBase.Enabled = command.CanExecute(null);

		buttonBase.Click += Click;
		command.CanExecuteChanged += CanExecuteChanged;
		buttonBase.Disposed += Disposed;

		Subscriptions.Add(buttonBase, new CommandSubscription(command, Click, CanExecuteChanged, Disposed));

		return buttonBase;
	}

	private static void DetachCommandSubscription(ButtonBase buttonBase)
	{
		if (!Subscriptions.TryGetValue(buttonBase, out CommandSubscription? subscription))
			return;

		buttonBase.Click -= subscription.Click;
		subscription.Command.CanExecuteChanged -= subscription.CanExecuteChanged;
		buttonBase.Disposed -= subscription.Disposed;

		_ = Subscriptions.Remove(buttonBase);
	}

	private sealed class CommandSubscription(ICommand command, EventHandler click, EventHandler canExecuteChanged, EventHandler disposed)
	{
		internal ICommand Command { get; } = command;
		internal EventHandler Click { get; } = click;
		internal EventHandler CanExecuteChanged { get; } = canExecuteChanged;
		internal EventHandler Disposed { get; } = disposed;
	}
#if NET5_0_OR_GREATER

	/// <summary>
	/// Binds a command to a <see cref="ButtonBase"/>, enabling the button's click event to
	/// execute the command and dynamically updating the button's enabled state based on the
	/// command's executability.
	/// </summary>
	/// <param name="buttonBase">The <see cref="ButtonBase"/> to bind the command to.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ButtonBase"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ButtonBase WithCommandBinding(this ButtonBase buttonBase, object dataSource, string dataMember)
		=> BindingHelper.Bind(buttonBase, nameof(buttonBase.Command), dataSource, dataMember);

	/// <summary>
	/// Binds a command parameter to a <see cref="ButtonBase"/>, enabling the button's click event
	/// to execute the command and dynamically updating the button's enabled state based on the
	/// command's executability.
	/// </summary>
	/// <param name="buttonBase">The <see cref="ButtonBase"/> to bind the command to.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ButtonBase"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ButtonBase WithCommandParameterBinding(this ButtonBase buttonBase, object dataSource, string dataMember)
		=> BindingHelper.Bind(buttonBase, nameof(buttonBase.CommandParameter), dataSource, dataMember);
#endif
}
