using System;
using System.Collections.Generic;
using System.Linq;
using TestTaskNeoStack.ViewModels;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace TestTaskNeoStack.Models
{
    public class PowerFunction
    {
        private string _nameSelectedFunction;
        /// <summary>Названия Функции.</summary>
        public string FunctionName { get => _nameSelectedFunction; private set => _nameSelectedFunction = value; }

        /// <summary>Делегат Функции.</summary>
        public Func<double, double, double> Function { get; }

        /// <summary>Коэффициент A.</summary>
        public double A { get; set; }

        /// <summary>Коэффициент B.</summary>
        public double B { get; set; }

        /// <summary>Коэффициент C.</summary>
        public double C { get; set; }

        /// <summary>Список аргументов.</summary>
        public IReadOnlyList<double> Coefficients { get; }

        /// <summary>Строки вычисленных значений.</summary>
        public ObservableCollection<PowerFunctionRow> CalculatedFunctions { get; }
            = new ObservableCollection<PowerFunctionRow>();

        private void OnRowsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Добавление выбранной Функции в новую строку.
            if (e.Action == NotifyCollectionChangedAction.Add)
                foreach (PowerFunctionRow row in e.NewItems)
                {
                    row.SetFunction(this);
                }
        }

        /// <summary>Создаёт экземпляр <see cref="PowerFunction"/>.</summary>
        /// <param name="name">Имя Функции.</param>
        /// <param name="function">Делегат Функции.</param>
        /// <summary>Строки вычисленных значений.</summary>
        public PowerFunction(string name, IEnumerable<double> arguments, Func<double, double, double, double, double, double> function)
        {
            FunctionName = name;
            Coefficients = arguments.ToList().AsReadOnly();
            this.function = function ?? throw new ArgumentNullException(nameof(function));
            Function = Calculate;

            CalculatedFunctions.CollectionChanged += OnRowsChanged;
        }
        private readonly Func<double, double, double, double, double, double> function;
        private double Calculate(double x, double y)
            => function(A, B, C, x, y);
    }
}
