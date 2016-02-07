using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Test_Framework
{
    public class JsonData
    {
        public IList<FuelStations> fuel_stations { get; set; }
        //public string precision { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }


    }
    public class FuelStations
    {
        public string access_days_time { get; set; }
        // cards_accepted
        public string ev_network { get; set; }
        public string station_name { get; set; }
        public string id { get; set; }
        public string street_address { get; set; }
    }


    public static class Browser_ExPart2
    {
        static IWebDriver webdriver = new FirefoxDriver();

        public static void Goto(String url)
        {
            webdriver.Url = url;
        }

        public static bool Checktitle(String title)
        {
            return (webdriver.Title == title);
        }

        
        #region Excercise2
        /// <summary>
        /// returns station Id if station anme is found.
        /// </summary>
        /// <param name="stationName"></param>
        /// <returns></returns>
        public static string StationID(string stationName)
        {
            var json = webdriver.FindElement(By.TagName("body")).Text;

            JsonSerializer js = new JsonSerializer();
            // var jsonArray
            var deserializedProduct = JsonConvert.DeserializeObject<JsonData>(json);
            foreach (var station in deserializedProduct.fuel_stations)
            {
                if (station.station_name == stationName)
                {
                    return station.id;
                }
            }
            return string.Empty;

        }
        /// <summary>
        /// return the address if station id is found.
        /// </summary>
        /// <param name="stationID"></param>
        /// <returns></returns>
        public static string StationAddress(string stationID)
        {
            var json = webdriver.FindElement(By.TagName("body")).Text;

            JsonSerializer js = new JsonSerializer();
            // var jsonArray
            var deserializedProduct = JsonConvert.DeserializeObject<JsonData>(json);
            foreach (var station in deserializedProduct.fuel_stations)
            {
                if (station.id == stationID)
                {
                    return station.street_address;
                }
            }
            return string.Empty;

        }

        #endregion

        public static void close()
        {
            webdriver.Close();
        }
    }

}
