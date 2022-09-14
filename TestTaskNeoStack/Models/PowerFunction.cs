using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TestTaskNeoStack.ViewModels;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using Simplified;

namespace TestTaskNeoStack.Models
{
    public class PowerFunction : BaseInpc
    {
        private string _nameSelectedFunction;
        private double _a;
        private double _b;
        private double _c;
        /// <summary>Названия Функции.</summary>
        public string FunctionName { get => _nameSelectedFunction; private set => _nameSelectedFunction = value; }

        /// <summary>Делегат Функции.</summary>
        public Func<double, double, double> Function { get; }

        /// <summary>Коэффициент A.</summary>
        public double A 
        {
            get { return _a; }
            set { Set(ref _a, value); }
        }

/// <summary>Коэффициент B.</summary>
public double B
        {
            get { return _b; }
            set { Set(ref _b, value); }
        }

        /// <summary>Коэффициент C.</summary>
        public double C
        {
            get { return _c; }
            set { Set(ref _c, value); }
        }

        /// <summary>Список аргументов.</summary>
        public IReadOnlyList<double> Coefficients { get; }

        /// <summary>Строки вычисленных значений.</summary>
        public ObservableCollection<PowerFunctionRow> CalculatedFunctions { get; }
            = new ObservableCollection<PowerFunctionRow>();

        private void OnRowsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Добавление выбранной Функции в новую строку.
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (PowerFunctionRow row in e.NewItems)
                {
                    row.SetFunction(this);
                }             
            }
            foreach (PowerFunctionRow row in CalculatedFunctions)
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
        {
            return function(A, B, C, x, y);
        }

        //перенести комагды в view

        private RelayCommand _removeRow;
        public RelayCommand RemoveRow =>
            _removeRow ?? (_removeRow = new RelayCommand
        (
             () => { if (CalculatedFunctions.Count > 0)
                     CalculatedFunctions.RemoveAt(CalculatedFunctions.Count - 1); }
        ));

        private RelayCommand _addRow;
        public RelayCommand AddRow =>
            _addRow ?? (_addRow = new RelayCommand
        (
             () => { CalculatedFunctions.Add(new PowerFunctionRow()); }
        ));

        protected override void OnPropertyChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnPropertyChanged(propertyName, oldValue, newValue);

            if (propertyName == nameof(A) || propertyName == nameof(B) || propertyName == nameof(C))
                foreach (PowerFunctionRow row in CalculatedFunctions)
                {
                    row.SetFunction(this);
                }
        }
    }
}
