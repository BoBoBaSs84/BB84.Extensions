using System.Collections.Concurrent;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BB84.WinForms.Extensions.Helpers;

/// <summary>
/// Provides helpers that resolve friendly names for enum values used by the flags controls.
/// </summary>
/// <remarks>
/// This class uses caching to improve performance when resolving display names for enum values.
/// </remarks>
public static class FlagsDisplayResolvers
{
	private static readonly ConcurrentDictionary<(Type EnumType, string Name), string?> DescriptionCache = new();
	private static readonly ConcurrentDictionary<(Type EnumType, string Name), string?> DisplayCache = new();

	/// <summary>
	/// Resolves the display name of the supplied enum value using the <see cref="DescriptionAttribute"/>.
	/// </summary>
	/// <param name="value">The enum value whose description should be used.</param>
	/// <returns>The description text if found; otherwise the enum member name.</returns>
	public static string FromDescriptionAttribute(Enum value)
	{
		return value is not null
			? GetDescription(value) ?? value.ToString() ?? string.Empty
			: throw new ArgumentNullException(nameof(value));
	}

	/// <summary>
	/// Resolves the display name of the supplied enum value using the <see cref="DisplayAttribute"/>.
	/// </summary>
	/// <param name="value">The enum value whose display attribute should be used.</param>
	/// <returns>The attribute name if found; otherwise the enum member name.</returns>
	public static string FromDisplayAttribute(Enum value)
	{
		return value is not null
			? GetDisplayName(value) ?? value.ToString() ?? string.Empty
			: throw new ArgumentNullException(nameof(value));
	}

	private static string? GetDescription(Enum value)
	{
		(ConcurrentDictionary<(Type EnumType, string Name), string?> cache, (Type EnumType, string Name) key) setup;

		return !TryCreateKey(value, DescriptionCache, out setup)
			? null
			: setup.cache.GetOrAdd(setup.key,
			static staticKey => ResolveDescription(staticKey.EnumType, staticKey.Name));
	}

	private static string? GetDisplayName(Enum value)
	{
		(ConcurrentDictionary<(Type EnumType, string Name), string?> cache, (Type EnumType, string Name) key) setup;
		return !TryCreateKey(value, DisplayCache, out setup)
			? null
			: setup.cache.GetOrAdd(setup.key,
			static staticKey => ResolveDisplay(staticKey.EnumType, staticKey.Name));
	}

	private static bool TryCreateKey(Enum value, ConcurrentDictionary<(Type EnumType, string Name), string?> cache, out (ConcurrentDictionary<(Type EnumType, string Name), string?> cache, (Type EnumType, string Name) key) setup)
	{
		Type enumType = value.GetType();
		string? name = Enum.GetName(enumType, value);
		if (name is null)
		{
			setup = default;
			return false;
		}

		setup = (cache, (enumType, name));
		return true;
	}

	private static string? ResolveDescription(Type enumType, string name)
	{
		FieldInfo? field = enumType.GetField(name, BindingFlags.Public | BindingFlags.Static);
		DescriptionAttribute? attribute = field?.GetCustomAttribute<DescriptionAttribute>();
		return attribute?.Description;
	}

	private static string? ResolveDisplay(Type enumType, string name)
	{
		FieldInfo? field = enumType.GetField(name, BindingFlags.Public | BindingFlags.Static);
		DisplayAttribute? attribute = field?.GetCustomAttribute<DisplayAttribute>();
		return attribute?.GetName() ?? attribute?.Name;
	}
}
