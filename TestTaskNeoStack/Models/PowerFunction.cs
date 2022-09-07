using System;
using System.Collections.Generic;
using System.Linq;

namespace TestTaskNeoStack.Models
{
    public class PowerFunction
    {
        /// <summary>Названия Функции.</summary>
        public string FunctionName { get; }

        /// <summary>Делегат Функции.</summary>
        public Func<double, double, double> Function { get; }

        /// <summary>Коэффициент A.</summary>
        public double A { get; set; }

        /// <summary>Коэффициент B.</summary>
        public double B { get; set; }

        /// <summary>Коэффициент C.</summary>
        public double C { get; set; }

        public IReadOnlyList<double> Coefficients { get; }

        /// <summary>Создаёт экземпляр <see cref="PowerFunction"/>.</summary>
        /// <param name="name">Имя Функции.</param>
        /// <param name="function">Делегат Функции.</param>
        public PowerFunction(string name, IEnumerable<double> coefficients, Func<double, double, double, double, double, double> function)
        {
            FunctionName = name;
            Coefficients = coefficients.ToList().AsReadOnly();
            this.function = function ?? throw new ArgumentNullException(nameof(function));
            Function = Calculate;
        }
        private readonly Func<double, double, double, double, double, double> function;
        private double Calculate(double x, double y)
            => function(A, B, C, x, y);
    }
}
