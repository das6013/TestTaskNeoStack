using System;
using System.Windows.Markup;

namespace WpfMvvm.Converters
{
    /// <summary>Предоставляет экземпляр <see cref="BooleanNotConverter"/> из <see cref="BooleanNotConverter.Instance"/>.</summary>
    [MarkupExtensionReturnType(typeof(BooleanNotConverter))]
    public class BooleanNotConverterExtension : MarkupExtension
    {
        /// <summary>Возвращает экземпляр конвертера из <see cref="BooleanNotConverter.Instance"/>.</summary>
        /// <param name="serviceProvider">Вспомогательный объект поставщика служб,
        /// способный предоставлять службы для расширения разметки.<para/>
        /// Не используется.</param>
        /// <returns>Экземпляр из <see cref="BooleanNotConverter.Instance"/>.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
            => BooleanNotConverter.Instance;

        /// <summary>Создаёт экземпляр <see cref="BooleanNotConverterExtension"/>.</summary>
        public BooleanNotConverterExtension() { }
    }
}