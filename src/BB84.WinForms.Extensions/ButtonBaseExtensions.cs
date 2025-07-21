// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Windows.Input;

namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="ButtonBase"/> control to simplify data binding.
/// </summary>
public static class ButtonBaseExtensions
{
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
	/// </remarks>
	/// <param name="buttonBase">The <see cref="Button"/> to bind the command to.</param>
	/// <param name="command">The <see cref="ICommand"/> to bind to the button.</param>
	/// <returns>
	/// The <see cref="ButtonBase"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ButtonBase WithCommandBinding(this ButtonBase buttonBase, ICommand command)
	{
		void Click(object? sender, EventArgs args) => command.Execute(null);
		void CanExecuteChanged(object? sender, EventArgs args) => buttonBase.Enabled = command.CanExecute(null);

		buttonBase.Enabled = command.CanExecute(null);

		buttonBase.Click += Click;
		command.CanExecuteChanged += CanExecuteChanged;

		buttonBase.Disposed += (sender, args) =>
		{
			buttonBase.Click -= Click;
			command.CanExecuteChanged -= CanExecuteChanged;
		};

		return buttonBase;
	}
#if NET5_0_OR_GREATER

	/// <summary>
	/// Binds a command to a <see cref="ButtonBase"/>, enabling the button's click event to
	/// execute the command and dynamically updating the button's enabled state based on the
	/// command's executability.
	/// </summary>
	/// <param name="buttonBase">The <see cref="Button"/> to bind the command to.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ButtonBase"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ButtonBase WithCommandBinding(this ButtonBase buttonBase, object dataSource, string dataMember)
	{
		buttonBase.DataBindings.Add(nameof(buttonBase.Command), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return buttonBase;
	}

	/// <summary>
	/// Binds a command parameter to a <see cref="ButtonBase"/>, enabling the button's click event
	/// to execute the command and dynamically updating the button's enabled state based on the
	/// command's executability.
	/// </summary>
	/// <param name="buttonBase">The <see cref="Button"/> to bind the command to.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ButtonBase"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ButtonBase WithCommandParameterBinding(this ButtonBase buttonBase, object dataSource, string dataMember)
	{
		buttonBase.DataBindings.Add(nameof(buttonBase.CommandParameter), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return buttonBase;
	}
#endif
}
