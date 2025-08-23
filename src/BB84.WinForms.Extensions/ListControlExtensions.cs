// Copyright: 2023 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Collections;

namespace BB84.WinForms.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="ListControl"/> class to simplify data binding.
/// </summary>
/// <remarks>
/// This class includes methods to bind common properties of a <see cref="ListControl"/> class, such as
/// <see cref="ListControl.DataSource"/>.
/// These methods return the same <see cref="ListControl"/> instance, allowing for method chaining.
/// </remarks>
public static class ListControlExtensions
{
	/// <summary>
	/// Binds the <see cref="ListControl.DataSource"/> property of the specified <see cref="ListControl"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <param name="listControl">The <see cref="ListControl"/> to bind.</param>
	/// <param name="dataSource">
	/// The data source to bind to the <see cref="ListControl.DataSource"/>. Can be any object that
	/// implements <see cref="IEnumerable"/> or other supported data source types.
	/// </param>
	/// <returns>
	/// The <see cref="ListControl"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ListControl WithDataSourceBinding(this ListControl listControl, object dataSource)
	{
		listControl.DataSource = dataSource;
		return listControl;
	}

	/// <summary>
	/// Binds the <see cref="ListControl.SelectedValue"/> property of the specified <see cref="ListControl"/>
	/// to a property on the provided data source.
	/// </summary>
	/// <remarks>
	/// The binding is configured to update the data source whenever the <see cref="ListControl.SelectedValue"/> 
	/// property changes, using <see cref="DataSourceUpdateMode.OnPropertyChanged"/>.
	/// </remarks>
	/// <param name="listControl">The <see cref="ListControl"/> to bind.</param>
	/// <param name="dataSource">The data source containing the property to bind to.</param>
	/// <param name="dataMember">The name of the property on the data source to bind to.</param>
	/// <returns>
	/// The <see cref="ListControl"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ListControl WithSelectedValueBinding(this ListControl listControl, object dataSource, string dataMember)
	{
		listControl.DataBindings.Add(nameof(listControl.SelectedValue), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
		return listControl;
	}

	/// <summary>
	/// Sets the <see cref="ListControl.DisplayMember"/> property of the specified <see cref="ListControl"/>.
	/// </summary>
	/// <param name="listControl">The <see cref="ListControl"/> to set the display member for.</param>
	/// <param name="displayMember">The name of the property to display for each item in the list.</param>
	/// <returns>
	/// The <see cref="ListControl"/> control with the display member set, allowing for method chaining.
	/// </returns>
	public static ListControl WithDisplayMember(this ListControl listControl, string displayMember)
	{
		listControl.DisplayMember = displayMember;
		return listControl;
	}

	/// <summary>
	/// Sets the <see cref="ListControl.ValueMember"/> property of the specified <see cref="ListControl"/>.
	/// </summary>
	/// <param name="listControl">The <see cref="ListControl"/> to set the value member for.</param>
	/// <param name="valueMember">The name of the property to use as the actual value for each item in the list.</param>
	/// <returns>
	/// The <see cref="ListControl"/> control with the value member set, allowing for method chaining.
	/// </returns>
	public static ListControl WithValueMember(this ListControl listControl, string valueMember)
	{
		listControl.ValueMember = valueMember;
		return listControl;
	}

	/// <summary>
	/// Binds the <see cref="ListControl.DataSource"/> property of the specified <see cref="ListControl"/>
	/// to an enumeration of type <typeparamref name="T"/>.
	/// </summary>
	/// <typeparam name="T">The enumeration type to bind to the <see cref="ListControl.DataSource"/>.</typeparam>
	/// <param name="listControl">The <see cref="ListControl"/> to bind.</param>
	/// <param name="value">The enumeration value used to determine the type <typeparamref name="T"/>.</param>
	/// <returns>
	/// The <see cref="ListControl"/> control with the binding applied, allowing for method chaining.
	/// </returns>
	public static ListControl WithEnumeratorBinding<T>(this ListControl listControl, T value)
		where T : struct, IComparable, IFormattable, IConvertible
	{
		List<KeyValuePair<T, string>> datasource = [.. Enum.GetValues(value.GetType())
			.OfType<T>()
			.ToDictionary(key => key, value => $"{value}")];

		listControl.WithDisplayMember(nameof(KeyValuePair<T, string>.Value))
			.WithValueMember(nameof(KeyValuePair<T, string>.Key))
			.WithDataSourceBinding(datasource);

		return listControl;
	}
}
