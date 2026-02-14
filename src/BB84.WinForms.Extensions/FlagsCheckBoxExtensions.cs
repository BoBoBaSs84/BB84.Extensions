using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using BB84.WinForms.Extensions.Controls;
using BB84.WinForms.Extensions.Helpers;

namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for binding and working with the <see cref="FlagsCheckBox"/> control.
/// </summary>
public static class FlagsCheckBoxExtensions
{
	/// <summary>
	/// Sets the <see cref="FlagsCheckBox.DisplayNameResolver"/> of the specified <see cref="FlagsCheckBox"/>
	/// to a resolver that retrieves display names from the <see cref="DescriptionAttribute"/> of enum values.
	/// </summary>
	/// <param name="checkBox">The <see cref="FlagsCheckBox"/> to configure.</param>
	/// <returns>
	/// The same <see cref="FlagsCheckBox"/> instance, so that additional configuration can be chained fluently.
	/// </returns>
	public static FlagsCheckBox WithDescriptionName(this FlagsCheckBox checkBox)
	{
		checkBox.WithDisplayNameResolver(FlagsDisplayResolvers.FromDescriptionAttribute);
		return checkBox;
	}

	/// <summary>
	/// Sets the <see cref="FlagsCheckBox.DisplayNameResolver"/> of the specified <see cref="FlagsCheckBox"/>
	/// to a resolver that retrieves display names from the <see cref="DisplayAttribute"/> of enum values.
	/// </summary>
	/// <param name="checkBox">The <see cref="FlagsCheckBox"/> to configure.</param>
	/// <returns>
	/// The same <see cref="FlagsCheckBox"/> instance, so that additional configuration can be chained fluently.
	/// </returns>
	public static FlagsCheckBox WithDisplayName(this FlagsCheckBox checkBox)
	{
		checkBox.WithDisplayNameResolver(FlagsDisplayResolvers.FromDisplayAttribute);
		return checkBox;
	}

	/// <summary>
	/// Sets the <see cref="FlagsCheckBox.DisplayNameResolver"/> used to provide user-friendly captions.
	/// </summary>
	/// <param name="checkBox">The <see cref="FlagsCheckBox"/> to configure.</param>
	/// <param name="resolver">The delegate that resolves a display name for each flag value.</param>
	/// <returns>
	/// The same <see cref="FlagsCheckBox"/> instance, so that additional configuration can be chained fluently.
	/// </returns>
	public static FlagsCheckBox WithDisplayNameResolver(this FlagsCheckBox checkBox, Func<Enum, string> resolver)
	{
		checkBox.DisplayNameResolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
		return checkBox;
	}

	/// <summary>
	/// Sets the <see cref="FlagsCheckBox.FlowDirection"/> property of the specified <see cref="FlagsCheckBox"/>
	/// to the given <see cref="FlowDirection"/> value.
	/// </summary>
	/// <param name="checkBox">The <see cref="FlagsCheckBox"/> to modify.</param>
	/// <param name="direction">The <see cref="FlowDirection"/> value to set.</param>
	/// <returns>
	/// The same <see cref="FlagsCheckBox"/> instance, so that additional configuration can be chained fluently.
	/// </returns>
	public static FlagsCheckBox WithFlowDirection(this FlagsCheckBox checkBox, FlowDirection direction)
	{
		checkBox.FlowDirection = direction;
		return checkBox;
	}

	/// <summary>
	/// Binds the <see cref="FlagsCheckBox.SelectedValue"/> property of the specified <see cref="FlagsCheckBox"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="FlagsCheckBox.SelectedValue"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="checkBox">The <see cref="FlagsCheckBox"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="FlagsCheckBox"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static FlagsCheckBox WithSelectedValueBinding(this FlagsCheckBox checkBox, object dataSource, string dataMember)
	{
		checkBox.DataBindings.Add(nameof(checkBox.SelectedValue), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return checkBox;
	}
}
