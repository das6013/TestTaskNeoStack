using System;
using System.Windows.Controls;

namespace TestTaskNeoStack.Converter
{
    class NumericTextBox:TextBox
    {
        void OnPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
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
