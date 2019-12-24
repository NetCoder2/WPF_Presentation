using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public class WindowPath
    {
        #region Windows

        /// <summary>
        /// The window with the calculator
        /// </summary>
        public static string CalculatorWindow
        {
            get { return "/Calculator.xaml"; }
        }

        /// <summary>
        /// The window with the currency converter
        /// </summary>
        public static string CurrencyConverterWindow
        {
            get { return "/CurrencyConverter.xaml"; }
        }

        /// <summary>
        /// The window with the C# test
        /// </summary>
        public static string CSharpTestWindow
        {
            get { return "/CSharpTestWindow.xaml"; }
        }


        /// <summary>
        /// The main window for the application
        /// </summary>
        public static string MainWindow
        {
            get { return "MainWindow.xaml"; }
        }

        /// <summary>
        /// The window with message
        /// </summary>
        public static string MessageWindow
        {
            get { return "/UI;component/Windows/MessageWindow.xaml"; }
        }


        #endregion

    }
}
