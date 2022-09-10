using Xunit;
using TestTaskNeoStack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskNeoStack.Models.Tests
{
    public class PowerFunctionTests
    {
        [Fact()]
        public void PowerFunctionConsructorTest()
        {
            PowerFunction powerFunctionTest = new PowerFunction("Линейная",
                new List<double> { 1, 2, 3, 4, 5 },
                (a, b, c, x, y) => a * x + b * 1 + c);
            Assert.True(powerFunctionTest!=null, "This test needs an implementation");
        }

        [Fact()]

        public void MainWindowViewModelTest()
        {
            MainWindowViewModel mainWindowViewModelTest = new MainWindowViewModel();
            Assert.True(mainWindowViewModelTest.Functions.Count() == 5, "This test needs an implementation");
        }

        [Fact()]

        public void LinearFunctionTest()
        {
            MainWindowViewModel mainWindowViewModelTest = new MainWindowViewModel();
            PowerFunction powerFunctionTest = mainWindowViewModelTest.Functions[0];
            powerFunctionTest.A = 3;
            powerFunctionTest.B = 3;
            powerFunctionTest.C = 3;
            PowerFunctionRow powerFunctionRowTest = new PowerFunctionRow();
            powerFunctionRowTest.X = 2;
            powerFunctionRowTest.Y = 2;
            powerFunctionRowTest.SetFunction(powerFunctionTest);
            Assert.True(powerFunctionRowTest.F == 12, "This test needs an implementation");
        }

        [Fact()]

        public void QuadraticFunctionTest()
        {
            MainWindowViewModel mainWindowViewModelTest = new MainWindowViewModel();
            PowerFunction powerFunctionTest = mainWindowViewModelTest.Functions[1];
            powerFunctionTest.A = -3;
            powerFunctionTest.B = 5;
            powerFunctionTest.C = 10;
            PowerFunctionRow powerFunctionRowTest = new PowerFunctionRow();
            powerFunctionRowTest.X = 5;
            powerFunctionRowTest.Y = 6;
            powerFunctionRowTest.SetFunction(powerFunctionTest);
            Assert.True(powerFunctionRowTest.F == -35, "This test needs an implementation");
        }

        [Fact()]

        public void CubicFunctionTest()
        {
            MainWindowViewModel mainWindowViewModelTest = new MainWindowViewModel();
            PowerFunction powerFunctionTest = mainWindowViewModelTest.Functions[2];
            powerFunctionTest.A = -2;
            powerFunctionTest.B = -3;
            powerFunctionTest.C = 400;
            PowerFunctionRow powerFunctionRowTest = new PowerFunctionRow();
            powerFunctionRowTest.X = -8;
            powerFunctionRowTest.Y = 6;
            powerFunctionRowTest.SetFunction(powerFunctionTest);
            Assert.True(powerFunctionRowTest.F == 1316, "This test needs an implementation");
        }

        [Fact()]

        public void FourthDegreeFunctionTest()
        {
            MainWindowViewModel mainWindowViewModelTest = new MainWindowViewModel();
            PowerFunction powerFunctionTest = mainWindowViewModelTest.Functions[3];
            powerFunctionTest.A = -5;
            powerFunctionTest.B = -9;
            powerFunctionTest.C = 2000;
            PowerFunctionRow powerFunctionRowTest = new PowerFunctionRow();
            powerFunctionRowTest.X = -5;
            powerFunctionRowTest.Y = -9;
            powerFunctionRowTest.SetFunction(powerFunctionTest);
            Assert.True(powerFunctionRowTest.F == 5436, "This test needs an implementation");
        }

        [Fact()]

        public void FifthDegreeFunctionTest()
        {
            MainWindowViewModel mainWindowViewModelTest = new MainWindowViewModel();
            PowerFunction powerFunctionTest = mainWindowViewModelTest.Functions[4];
            powerFunctionTest.A = 23;
            powerFunctionTest.B = 78;
            powerFunctionTest.C = 50000;
            PowerFunctionRow powerFunctionRowTest = new PowerFunctionRow();
            powerFunctionRowTest.X = 56;
            powerFunctionRowTest.Y = 72;
            powerFunctionRowTest.SetFunction(powerFunctionTest);
            Assert.True(powerFunctionRowTest.F == 14763041616, "This test needs an implementation");
        }


    }
}