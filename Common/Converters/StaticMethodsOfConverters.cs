using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;

namespace WpfMvvm.Converters
{
    /// <summary>Статический класс с методами для различных конвертеров.</summary>
    public static partial class StaticMethodsOfConverters
    {
        /// <summary>Конвертация <see cref="bool"/> в заданный тип.</summary>
        /// <param name="value">Конвертируемое значение.</param>
        /// <param name="targetType">Тип в который должно быть конвертировано значение.</param>
        /// <param name="culture">Культура используемая при преобразовании в строку.</param>
        /// <returns><see cref="string"/> если целевой тип совместим с <see cref="string"/>,
        /// <see cref="bool"/> для всех остальных типов.</returns>
        public static object ConvertToType(this bool value, Type targetType, CultureInfo culture)
        {
            if (typeof(string).IsAssignableFrom(targetType))
                return value.ToString(culture);

            return value;
        }

        /// <summary>Конвертация <see cref="Visibility"/> в заданный тип.</summary>
        /// <param name="value">Конвертируемое значение.</param>
        /// <param name="targetType">Тип в который должно быть конвертировано значение.</param>
        /// <returns><see cref="string"/> если целевой тип совместим с <see cref="string"/>,
        /// <see cref="Visibility"/> для всех остальных типов.</returns>
        public static object ConvertToType(this Visibility value, Type targetType)
        {
            if (typeof(string).IsAssignableFrom(targetType))
                return value.ToString();

            return value;
        }

        /// <summary>Приводит <see cref="object"/> к <see cref="bool"/>.</summary>
        /// <param name="value"><see cref="bool"/> или <see cref="string"/>.</param>
        /// <param name="result">Полученное значение после приведения или конвертации.</param>
        /// <returns><see langword="true"/> для <see cref="bool"/> и <see cref="string"/>, конвертируемого в bool.</returns>
        public static bool TryParse(this object value, out bool result)
        {
            if (value is bool val)
            {
                result = val;
                return true;
            }

            if (value is string str && bool.TryParse(str, out val))
            {
                result = val;
                return true;
            }

            result = false;
            return false;

        }

        /// <summary>Приводит <see cref="object"/> к <see cref="Visibility"/>.</summary>
        /// <param name="value"><see cref="Visibility"/> или <see cref="string"/>.</param>
        /// <param name="result">Полученное значение после приведения или конвертации.</param>
        /// <returns><see cref="Visibility"/>.</returns>
        public static bool TryParse(this object value, out Visibility result)
        {
            if (value is Visibility visibility)
            {
                result = visibility;
                return true;
            }

            if (value is string str && Enum.TryParse(str, true, out visibility))
            {
                result = visibility;
                return true;
            }

            result = Visibility.Visible;
            return false;
        }

        /// <summary>Преобразование в строку.</summary>
        /// <param name="value">Преобразуемое значение.</param>
        /// <param name="culture">Используемая культура.</param>
        /// <returns>для <paramref name="value"/>=<see langword="null"/> - "null";<br/>
        /// для <see cref="string"/> - значение в кавычках <c>$"\"{<paramref name="value"/>}\""</c>;<br/>
        /// для остальных - <see cref="TypeConverter.ConvertToString(ITypeDescriptorContext, CultureInfo, object)"/> с <see cref="ITypeDescriptorContext"/>=<see langword="null"/>.</returns>
        public static string ToString(object value, CultureInfo culture)
        {
            if (value == null)
                return "null";

            Type type = value.GetType();
            if (type == typeof(string))
                return $"\"{value}\"";


            TypeConverter converter = GetConverter(type);
            return converter.ConvertToString(null, culture, value);

        }

        /// <summary>Словарь используемых <see cref="TypeConverter"/>.</summary>
        private static readonly Dictionary<Type, TypeConverter> converters = new Dictionary<Type, TypeConverter>();

        /// <summary>Получение <see cref="TypeConverter"/> типа.</summary>
        /// <param name="type">Тип для которого нужен конвертер.</param>
        /// <returns><see cref="TypeConverter"/> для указанного типа.</returns>
        private static TypeConverter GetConverter(Type type)
        {
            if (!converters.TryGetValue(type, out TypeConverter converter))
            {
                converter = TypeDescriptor.GetConverter(type);
                converters.Add(type, converter);
            }

            return converter;
        }
    }
}