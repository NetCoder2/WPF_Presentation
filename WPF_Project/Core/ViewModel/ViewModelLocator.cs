using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers.Animation;

namespace Core
{
    public class ViewModelLocator
    {
        /// <summary>
        /// Singleton instance of the View Models locator
        /// </summary>
        private static ViewModelLocator instance = new ViewModelLocator();

        #region Public Properties

        /// <summary>
        /// Singleton instance of the locator
        /// </summary>
        public static ViewModelLocator Instance
        {
            get { return instance; }
            private set { instance = value; }
        }



        /// <summary>
        /// The BaseViewModel view model
        /// </summary>
        public BaseViewModel BaseViewModel { get { return CreateViewModel<BaseViewModel>(); } }

        /// <summary>
        /// The calculator view model
        /// </summary>
        public CalculatorViewModel CalculatorViewModel { get { return CreateViewModel<CalculatorViewModel>(); } }

        /// <summary>
        /// The currency converter view model
        /// </summary>
        public CurrencyConverterViewModel CurrencyConverterViewModel { get { return CreateViewModel<CurrencyConverterViewModel>(); } }

        /// <summary>
        /// The C# test view model
        /// </summary>
        public CSharpTestViewModel CSharpTestViewModel { get { return CreateViewModel<CSharpTestViewModel>(); } }

        /// <summary>
        /// The DialogInfo view model
        /// </summary>
        public DialogInfoViewModel DialogInfoViewModel
        {
            get
            {

                var dialog = CreateViewModel<DialogInfoViewModel>();
                dialog.PanelContext.PanelLoadAnimation = WindowAnimation.ShowScaleAndFadeIn;
                dialog.PanelContext.PanelUnloadAnimation = WindowAnimation.HideScaleAndFadeOut;
                return dialog;
            }
        }
        protected T CreateViewModel<T>() where T : new()
        {
            return new T();
        }

        #endregion
    }
}
