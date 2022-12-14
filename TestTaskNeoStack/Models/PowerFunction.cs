using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using TestTaskNeoStack.ViewModels;
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
        public string FunctionName 
        {
            get 
            { 
                return _nameSelectedFunction; 
            }
            private set 
            { 
                _nameSelectedFunction = value;
            }
        }

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


        private RelayCommand _removeRow;

        /// <summary>Команда удаления строки.</summary>
        public RelayCommand RemoveRow =>
            _removeRow ?? (_removeRow = new RelayCommand
        (
             () => { if (CalculatedFunctions.Count > 1)
                     CalculatedFunctions.RemoveAt(CalculatedFunctions.Count - 1); }
        ));

        private RelayCommand _addRow;

        /// <summary>Команда добавления строки.</summary>
        public RelayCommand AddRow =>
            _addRow ?? (_addRow = new RelayCommand
        (
             () => { CalculatedFunctions.Add(new PowerFunctionRow()); }
        ));

        protected override void OnPropertyChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnPropertyChanged(propertyName, oldValue, newValue);

            // Пересчёт значения Функции если изменилось значение A,B,C
            if (propertyName == nameof(A) || propertyName == nameof(B) || propertyName == nameof(C))
                foreach (PowerFunctionRow row in CalculatedFunctions)
                {
                    row.SetFunction(this);
                }
        }
    }
}
