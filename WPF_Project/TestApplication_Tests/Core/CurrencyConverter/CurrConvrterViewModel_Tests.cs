using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestApplication_Tests.Core.CurrencyConverter
{
    [TestClass]
    public class CurrConvrterViewModel_Tests
    {
        CurrencyConverterViewModel model;


        public CurrConvrterViewModel_Tests()
        {
            
        }

        /// <summary>
        /// Tests to get currency rates from the www.bank.lv web site 
        /// </summary>
        [TestInitialize()]
        public void TestInitialize()
        {
            model = ViewModelLocator.Instance.CurrencyConverterViewModel;
            model.SetInitialRates();
        }


        /// <summary>
        /// Tests to get currency rates from the www.bank.lv web site 
        /// </summary>
        [TestMethod()]
        public void CheckInternetTest()
        {
            var check = model.CheckInternetConnection();
            Assert.IsTrue(check);
        }

        /// <summary>
        /// Tests to get currency rates from the www.bank.lv web site 
        /// </summary>
        [TestMethod()]
        public void GetCurrencyRatesTest()
        {
            model.GetCurrenciesRates();
            Assert.IsNotNull(model.US_Rate);
            Assert.IsNotNull(model.UK_Rate);
            Assert.IsNotNull(model.RU_Rate);
            Assert.IsNotNull(model.EU_Rate);
        }

        [TestMethod()]
        public void GetCurrencyValuesTest()
        {
            model.GetCurrenciesRates();
            model.EU_Value = 2;
            Assert.IsNotNull(model.US_Value);
            Assert.IsNotNull(model.UK_Rate);
            Assert.IsNotNull(model.RU_Rate);


            model.UK_Value = 3;
            var pound = model.GetCurrenciesByPoundRate();
            Assert.AreEqual(model.EU_Value, Math.Round(pound * model.UK_Value, 2));
            Assert.AreEqual(model.US_Value, Math.Round(model.EU_Value * model.US_Rate, 2));
            Assert.AreEqual(model.RU_Value, Math.Round(model.EU_Value * model.RU_Rate, 2));

            model.US_Value = 5.6;
            var dollar = model.GetCurrenciesByDollarRate();
            Assert.AreEqual(model.EU_Value, Math.Round(dollar * model.US_Value, 2));
            Assert.AreEqual(model.UK_Value, Math.Round(model.EU_Value * model.UK_Rate, 2));
            Assert.AreEqual(model.RU_Value, Math.Round(model.EU_Value * model.RU_Rate, 2));

            model.RU_Value = 23.5;
            var ruble = model.GetCurrenciesByRubleRate();
            Assert.AreEqual(model.EU_Value, Math.Round(ruble * model.RU_Value, 2));
            Assert.AreEqual(model.UK_Value, Math.Round(model.EU_Value * model.UK_Rate, 2));
            Assert.AreEqual(model.US_Value, Math.Round(model.EU_Value * model.US_Rate, 2));

            model.EU_Value = 3;
            Assert.AreEqual(model.RU_Value, Math.Round(model.EU_Value * model.RU_Rate, 2));
            Assert.AreEqual(model.UK_Value, Math.Round(model.EU_Value * model.UK_Rate, 2));
            Assert.AreEqual(model.US_Value, Math.Round(model.EU_Value * model.US_Rate, 2));
        }
    }
}
