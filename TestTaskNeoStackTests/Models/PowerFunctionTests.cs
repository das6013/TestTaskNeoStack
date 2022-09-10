using Xunit;
using Simplified;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using TestTaskNeoStack.ViewModels;

namespace TestTaskNeoStack.Models.Tests
{
    public class PowerFunctionTests
    {
        [Fact()]
        public void TestConstructor()
        {
            PowerFunction TestFunction = new PowerFunction("Линейная",
               new List<double> { 1, 2, 3, 4, 5 },
               (a, b, c, x, y) => a * x + b * 1 + c);
            Assert.True(TestFunction != null, "This test needs an implementation");
        }

        [Fact()]

        public void TestSetFuction()
        {
            PowerFunction TestFunction = new PowerFunction("Линейная",
              new List<double> { 1, 2, 3, 4, 5 },
              (a, b, c, x, y) => a * x + b * 1 + c);
            TestFunction.A = 1;
            TestFunction.B = 1;
            TestFunction.C = 1;
            PowerFunctionRow powerFunctionRow=new PowerFunctionRow();
            powerFunctionRow.X = 1;
            powerFunctionRow.Y = 1;
            powerFunctionRow.SetFunction(TestFunction);
            Assert.True(powerFunctionRow.F==3 ,"This test needs an implementation");
        }

        [Fact()]
        public void TestColleacionMainWindowsViewModel()
        {
            MainWindowViewModel mainWindowViewModel=new MainWindowViewModel();
            Assert.True(mainWindowViewModel.Functions.Count==5, "This test needs an implementation");
        }

        [Fact()]

        public void TestLinearFunction()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            PowerFunction TestFunction = mainWindowViewModel.Functions[0];
            TestFunction.A = 2;
            TestFunction.B = 3;
            TestFunction.C = 5;
            PowerFunctionRow powerFunctionRow = new PowerFunctionRow();
            powerFunctionRow.X = 2;
            powerFunctionRow.Y = -100;
            powerFunctionRow.SetFunction(TestFunction);
            Assert.True(powerFunctionRow.F == 12, "This test needs an implementation");
        }

        [Fact()]

        public void TestQuadratureFunction()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            PowerFunction TestFunction = mainWindowViewModel.Functions[1];
            TestFunction.A = -2;
            TestFunction.B = 3;
            TestFunction.C = 10;
            PowerFunctionRow powerFunctionRow = new PowerFunctionRow();
            powerFunctionRow.X = 2;
            powerFunctionRow.Y = -6;
            powerFunctionRow.SetFunction(TestFunction);
            Assert.True(powerFunctionRow.F == -16, "This test needs an implementation");
        }

        [Fact()]

        public void TestСubicFunction()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            PowerFunction TestFunction = mainWindowViewModel.Functions[2];
            TestFunction.A = 4;
            TestFunction.B = -5;
            TestFunction.C = 100;
            PowerFunctionRow powerFunctionRow = new PowerFunctionRow();
            powerFunctionRow.X = -2;
            powerFunctionRow.Y = 7;
            powerFunctionRow.SetFunction(TestFunction);
            Assert.True(powerFunctionRow.F == -177, "This test needs an implementation");
        }

        [Fact()]

        public void Test4DegreeFunction()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            PowerFunction TestFunction = mainWindowViewModel.Functions[3];
            TestFunction.A = -4;
            TestFunction.B = -8;
            TestFunction.C = 1000;
            PowerFunctionRow powerFunctionRow = new PowerFunctionRow();
            powerFunctionRow.X = -2;
            powerFunctionRow.Y = -7;
            powerFunctionRow.SetFunction(TestFunction);
            Assert.True(powerFunctionRow.F == 3680, "This test needs an implementation");
        }

        [Fact()]

        public void Test5DegreeFunction()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            PowerFunction TestFunction = mainWindowViewModel.Functions[4];
            TestFunction.A = 4;
            TestFunction.B = 8;
            TestFunction.C = 10000;
            PowerFunctionRow powerFunctionRow = new PowerFunctionRow();
            powerFunctionRow.X = 7;
            powerFunctionRow.Y = 5;
            powerFunctionRow.SetFunction(TestFunction);
            Assert.True(powerFunctionRow.F == 82228, "This test needs an implementation");
        }

    }
}