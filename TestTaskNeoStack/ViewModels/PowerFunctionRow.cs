using Simplified;
using System;
using TestTaskNeoStack.Models;

namespace TestTaskNeoStack.ViewModels
{
    /// <summary>Тип данных для одной строки таблицы.</summary>
    public class PowerFunctionRow :BaseInpc
    {
        private double _x;
        private double _y;
        private double? _f;

        /// <summary>Значение X.</summary>
        public double X 
        {
            get { return _x; }
            set { Set(ref _x, value); }
        }

        /// <summary>Значение Y.</summary>
        public double Y 
        { 
            get { return _y;}
            set { Set(ref _y, value);}
        }

        /// <summary>Значение Функции для текущих значений <see cref="X"/> и <see cref="Y"/>.</summary>
        public double? F 
        { 
            get { return _f; }
            private set { Set(ref _f, value); }
        }


        private PowerFunction function;

        /// <summary>Задаёт Функцию от двух аргументов.</summary>
        /// <param name="function">Функция от двух аргументов.</param>
        public void SetFunction(PowerFunction function)
        {
            this.function = function ?? throw new ArgumentNullException(nameof(function));
            F = function?.Function(X, Y);
        }


     

        protected override void OnPropertyChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnPropertyChanged(propertyName, oldValue, newValue);

            // Пересчёт значения Функции если изменилось значение X или Y.
            if (propertyName == nameof(X) || propertyName == nameof(Y))
                F = function?.Function(X, Y);
        }
    }
}
