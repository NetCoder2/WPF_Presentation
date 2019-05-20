using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Core
{
    public class CurrencyConverterViewModel : WindowModel
    {
        private bool isUKChanged = false;
        private bool isEURChanged = true;
        private bool isUSChanged = false;
        private bool isRUChanged = false;
        private const string webLink = "https://www.bank.lv/";

        private const string flag_EU = "/UI;component/Images/Flags/Flag_EU.png";
        private const string flag_GB = "/UI;component/Images/Flags/Flag_UK.png";
        private const string flag_RU = "/UI;component/Images/Flags/Flag_Ru.png";
        private const string flag_US = "/UI;component/Images/Flags/Flag_US.jpg";

        private double uk_Value;
        private double eu_Value;
        private double us_Value;
        private double ru_Value;

        public string Flag_EU { get; set; } = flag_EU;
        public string Flag_UK { get; set; } = flag_GB;
        public string Flag_Ru { get; set; } = flag_RU;
        public string Flag_US { get; set; } = flag_US;

        public double UK_Rate { get; set; }
        public double US_Rate { get; set; }
        public double RU_Rate { get; set; }
        public double EU_Rate { get; set; } = 1;

        /// <summary>
        /// Gets/Sets value of euro and sets values for others currencies
        /// </summary>
        public double EU_Value
        {
            get { return eu_Value; }
            set
            {
                eu_Value = value;

                if (!isUKChanged && !isUSChanged && !isRUChanged)
                {
                    isEURChanged = true;
                    GetCurrenciesByEuroRate();
                    isEURChanged = false;
                }

            }
        }

        /// <summary>
        /// Calculates curencies values by euro rate
        /// </summary>
        public void GetCurrenciesByEuroRate()
        {
            UK_Value = Math.Round(EU_Value * UK_Rate, 2);
            US_Value = Math.Round(EU_Value * US_Rate, 2);
            RU_Value = Math.Round(EU_Value * RU_Rate, 2);
        }

        /// <summary>
        /// Gets/Sets value of pound and sets values for others currencies
        /// </summary>
        public double UK_Value
        {
            get { return uk_Value; }
            set {

                uk_Value = value;

                if (!isEURChanged && !isUSChanged && !isRUChanged)
                {
                    isUKChanged = true;
                    GetCurrenciesByPoundRate();
                    isUKChanged = false;
                }
            }
        }

        /// <summary>
        /// Calculates curencies values by pound rate
        /// </summary>
        /// <returns>The price per one pound by rate</returns>
        public double GetCurrenciesByPoundRate()
        {
            var pound = 1 / UK_Rate;
            EU_Value = Math.Round(pound * UK_Value, 2);
            US_Value = Math.Round(EU_Value * US_Rate, 2);
            RU_Value = Math.Round(EU_Value * RU_Rate, 2);
            return pound;
        }

        /// <summary>
        /// Gets/Sets value of dollar and sets values for others currencies
        /// </summary>
        public double US_Value
        {
            get { return us_Value; }
            set
            {

                us_Value = value;

                if (!isEURChanged && !isUKChanged && !isRUChanged)
                {
                    isUSChanged = true;
                    GetCurrenciesByDollarRate();
                    isUSChanged = false;
                }
            }
        }

        /// <summary>
        /// Calculates curencies values by dollar rate
        /// </summary>
        /// <returns>The price per one dollar by rate</returns>
        public double GetCurrenciesByDollarRate()
        {
            var dollar = 1 / US_Rate;
            EU_Value = Math.Round(dollar * US_Value, 2);
            UK_Value = Math.Round(EU_Value * UK_Rate, 2);
            RU_Value = Math.Round(EU_Value * RU_Rate, 2);
            return dollar;
        }

        /// <summary>
        /// Gets/Sets value of ruble and sets values for others currencies
        /// </summary>
        public double RU_Value {
            get { return ru_Value; }
            set
            {

                ru_Value = value;

                if (!isEURChanged && !isUKChanged && !isUSChanged)
                {
                    isRUChanged = true;
                    GetCurrenciesByRubleRate();
                    isRUChanged = false;
                }
            }
        }

        /// <summary>
        /// Calculates curencies values by ruble rate
        /// </summary>
        /// <returns>The price per one ruble by rate</returns>
        public double GetCurrenciesByRubleRate()
        {
            var ruble = 1 / RU_Rate;
            EU_Value = Math.Round(ruble * RU_Value, 2);
            UK_Value = Math.Round(EU_Value * UK_Rate, 2);
            US_Value = Math.Round(EU_Value * US_Rate, 2);
            return ruble;
        }

        /// <summary>
        /// Gets currencies rates from the www.bank.lv site
        /// </summary>
        public void GetCurrenciesRates()
        {
            DateTime dateCurrency;
            WebClient client;
            XDocument xmlDocument;

            if (CheckInternetConnection())
            {
                dateCurrency = DateTime.Now;

                var stringMonth = dateCurrency.Month.ToString();
                //adds zero to the month
                if (dateCurrency.Month < 10)
                {
                    stringMonth = "0" + dateCurrency.Month;
                }

                var stringDay = dateCurrency.Day.ToString();
                //adds zero to the day
                if (dateCurrency.Day < 10)
                {
                    stringDay = "0" + dateCurrency.Day;
                }

                client = new WebClient();

                string downloadString = client.DownloadString(webLink + "vk/ecb.xml?date=" +
                    dateCurrency.Year + stringMonth + stringDay);

                var cRateString = "<CRates";

                int indexRate = downloadString.IndexOf(cRateString);
                var begingStr = downloadString.Substring(0, indexRate + cRateString.Length) + ">";
                int indexDate = downloadString.IndexOf("<Date>");
                var endStr = downloadString.Substring(indexDate, downloadString.Length - indexDate);

                var xmlString = begingStr + endStr;


                xmlDocument = XDocument.Parse(xmlString);

                var data = from d in xmlDocument.Descendants("Currency")
                           select new
                           {
                               CurrencyName = d.Element("ID").Value,
                               Rate = d.Element("Rate").Value
                           };

                //Applies currencies rates
                foreach (var row in data.ToList())
                {
                    if (row.CurrencyName == "USD")
                    {
                        US_Rate = Convert.ToDouble(row.Rate);
                    }

                    if (row.CurrencyName == "GBP")
                    {
                        UK_Rate = Convert.ToDouble(row.Rate);
                    }

                    if (row.CurrencyName == "RUB")
                    {
                        RU_Rate = Convert.ToDouble(row.Rate);
                    }
                }
            }
        }


        public bool CheckInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead(webLink))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }



        public CurrencyConverterViewModel()
        {

        }

        public void SetInitialRates()
        {
            GetCurrenciesRates();

            EU_Value = 1;
            UK_Value = UK_Rate;
            US_Value = US_Rate;
            RU_Value = RU_Rate;
        }
    }
}
