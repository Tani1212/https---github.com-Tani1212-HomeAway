using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test_Framework;

namespace Tests
{
    [TestClass]
    public class TestExPart2
    {
        static string Url = "https://api.data.gov/nrel/alt-fuel-stations/v1/nearest.json?api_key=859Zx7Sp1iyWKZHZmMN7ApS0E0hmfX6KDWrDRok7&location=Austn+Tx";
        
      
        [TestMethod]
        public void Exercise2TestCase1()
        {
            string nametoVerify = "Hyatt Regency - Tesla";
            string id = "68511";

            Browser_ExPart2.Goto(Url);
            Assert.IsTrue(id == Browser_ExPart2.StationID(nametoVerify));
        }
        [TestMethod]
        public void Exercise2TestCase2()
        {
            string id = "68511";
            string stationAddress = "208 Barton Springs Rd";

            Browser_ExPart2.Goto(Url);
            Assert.IsTrue(stationAddress == Browser_ExPart2.StationAddress(id));
        }
    
    }
}
