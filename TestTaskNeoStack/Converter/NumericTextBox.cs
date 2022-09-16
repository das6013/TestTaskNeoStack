using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestTaskNeoStack.Converter
{
    class NumericTextBox:TextBox
    {
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            try
            {
                Convert.ToDouble(e.Text);
            }
            catch
            {
                e.Handled = true;
            }
        }

    }
}
